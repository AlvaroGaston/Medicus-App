using Medicus.BLL;
using Medicus.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Medicus.UX
{
    public partial class frmTableroTurnos : Form
    {
        private TurnoBLL bllTurno = new TurnoBLL();
        private MedicoBLL bllMedico = new MedicoBLL(); // <-- Agregamos BLL de Médicos
        private SeguridadBLL bllSeguridad = new SeguridadBLL();
        private int idTurnoSeleccionado = 0;

        public frmTableroTurnos()
        {
            InitializeComponent();
        }

        private void frmTableroTurnos_Load(object sender, EventArgs e)
        {
            bllSeguridad.AplicarSeguridadGranular(this, "frmTableroTurnos");

            // 1. Configuramos el filtro de Estados
            cmbFiltroEstado.Items.Add("Todos los estados");
            cmbFiltroEstado.Items.Add("Programado");
            cmbFiltroEstado.Items.Add("Asistió");
            cmbFiltroEstado.Items.Add("Cancelado");
            cmbFiltroEstado.SelectedIndex = 0;

            // 2. Configuramos el filtro de Especialidades dinámicamente
            cmbFiltroEspecialidad.Items.Add("Todas las especialidades");
            var especialidades = bllMedico.ListarMedicos()
                .Where(m => !string.IsNullOrWhiteSpace(m.Especialidad))
                .Select(m => m.Especialidad.Trim().ToUpper())
                .Distinct()
                .ToList();

            foreach (var esp in especialidades)
            {
                cmbFiltroEspecialidad.Items.Add(esp);
            }
            cmbFiltroEspecialidad.SelectedIndex = 0;

            dtpFechaFiltro.Value = DateTime.Today;
        }

        // ==========================================
        // EVENTOS DE LOS FILTROS
        // ==========================================
        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            CargarGrillaDelDia();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrillaDelDia();
        }

        private void cmbFiltroEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrillaDelDia();
        }

        private void txtBuscarTurno_TextChanged(object sender, EventArgs e)
        {
            CargarGrillaDelDia();
        }

        // ==========================================
        // LÓGICA DE CARGA Y FILTRADO
        // ==========================================
        private void CargarGrillaDelDia()
        {
            idTurnoSeleccionado = 0;

            // 1. Filtro OBLIGATORIO: Fecha
            var turnosFiltrados = bllTurno.ListarTurnos()
                .Where(t => t.FechaTurno.Date == dtpFechaFiltro.Value.Date);

            // 2. Filtro: Estado
            if (cmbFiltroEstado.SelectedIndex > 0)
            {
                string estadoSeleccionado = cmbFiltroEstado.SelectedItem.ToString();
                turnosFiltrados = turnosFiltrados.Where(t => t.Estado == estadoSeleccionado);
            }

            // 3. Filtro NUEVO: Especialidad
            if (cmbFiltroEspecialidad.SelectedIndex > 0)
            {
                string espSeleccionada = cmbFiltroEspecialidad.SelectedItem.ToString();

                // Buscamos los IDs de los doctores que tienen esta especialidad
                var idsMedicosPermitidos = bllMedico.ListarMedicos()
                    .Where(m => m.Especialidad.ToUpper() == espSeleccionada)
                    .Select(m => m.IdMedico)
                    .ToList();

                // Filtramos los turnos dejando solo los que pertenezcan a esos doctores
                turnosFiltrados = turnosFiltrados.Where(t => idsMedicosPermitidos.Contains(t.IdMedico));
            }

            var listaFinal = turnosFiltrados.OrderBy(t => t.HoraTurno).ToList();

            // 4. Filtro: Texto (Buscador general)
            string textoBusqueda = txtBuscarTurno.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                listaFinal = listaFinal.Where(t =>
                    (t.Motivo != null && t.Motivo.ToLower().Contains(textoBusqueda)) ||
                    (t.Estado != null && t.Estado.ToLower().Contains(textoBusqueda))
                ).ToList();
            }

            dgvTurnosDelDia.DataSource = listaFinal;

            if (dgvTurnosDelDia.Columns["IdTurno"] != null) dgvTurnosDelDia.Columns["IdTurno"].Visible = false;
            if (dgvTurnosDelDia.Columns["IdMedico"] != null) dgvTurnosDelDia.Columns["IdMedico"].Visible = false;
            if (dgvTurnosDelDia.Columns["IdPaciente"] != null) dgvTurnosDelDia.Columns["IdPaciente"].Visible = false;

            AplicarColoresPorEstado();
        }

        private void AplicarColoresPorEstado()
        {
            foreach (DataGridViewRow row in dgvTurnosDelDia.Rows)
            {
                string estado = row.Cells["Estado"].Value?.ToString() ?? "";

                if (estado == "Cancelado")
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.DimGray;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Strikeout);
                }
                else if (estado == "Asistió")
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dgvTurnosDelDia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idTurnoSeleccionado = Convert.ToInt32(dgvTurnosDelDia.Rows[e.RowIndex].Cells["IdTurno"].Value);
            }
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            using (frmTurnos frm = new frmTurnos())
            {
                frm.ShowDialog();
            }
            CargarGrillaDelDia();
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (idTurnoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un turno de la lista para cancelar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea cancelar este turno?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bllTurno.CambiarEstado(idTurnoSeleccionado, "Cancelado");
                BitacoraBLL.RegistrarMovimiento($"Canceló el turno ID: {idTurnoSeleccionado}", "Recepción");
                CargarGrillaDelDia();
            }
        }

        private void btnAsistio_Click(object sender, EventArgs e)
        {
            if (idTurnoSeleccionado == 0) return;

            bllTurno.CambiarEstado(idTurnoSeleccionado, "Asistió");
            BitacoraBLL.RegistrarMovimiento($"Marcó asistencia del turno ID: {idTurnoSeleccionado}", "Recepción");
            CargarGrillaDelDia();
        }
    }
}