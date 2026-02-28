using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Medicus.BLL;
using Medicus.Entidades;


namespace Medicus.UX
{
    public partial class frmTableroTurnos : Form
    {
        private TurnoBLL bllTurno = new TurnoBLL();
        private SeguridadBLL bllSeguridad = new SeguridadBLL();
        private int idTurnoSeleccionado = 0;

        public frmTableroTurnos()
        {
            InitializeComponent();
        }

        private void frmTableroTurnos_Load(object sender, EventArgs e)
        {
            dtpFechaFiltro.Value = DateTime.Today;
            bllSeguridad.AplicarSeguridadGranular(this, "frmTableroTurnos");
            CargarGrillaDelDia();
        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            CargarGrillaDelDia();
        }

        private void CargarGrillaDelDia()
        {
            idTurnoSeleccionado = 0;

            // Traemos todos los turnos y filtramos por la fecha seleccionada en el calendario
            var turnosDelDia = bllTurno.ListarTurnos()
                .Where(t => t.FechaTurno.Date == dtpFechaFiltro.Value.Date)
                .OrderBy(t => t.HoraTurno)
                .ToList();

            dgvTurnosDelDia.DataSource = turnosDelDia;

            // Ocultamos columnas técnicas
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

        // ==========================================
        // BOTÓN: ABRIR EL WIZARD DE NUEVO TURNO
        // ==========================================
        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que armamos en el paso anterior
            using (frmTurnos frm = new frmTurnos())
            {
                frm.ShowDialog();
            }
            // Al cerrar el asistente, recargamos la grilla para ver el turno nuevo
            CargarGrillaDelDia();
        }

        // ==========================================
        // BOTÓN: MARCAR COMO CANCELADO
        // ==========================================
        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (idTurnoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un turno de la lista para cancelar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea cancelar este turno? El horario quedará libre nuevamente.", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Llamamos a tu método de la BLL para actualizar el estado en la base de datos
                // bllTurno.CambiarEstado(idTurnoSeleccionado, "Cancelado"); 

                BitacoraBLL.RegistrarMovimiento($"Canceló el turno ID: {idTurnoSeleccionado}", "Recepción");
                CargarGrillaDelDia();
            }
        }

        // ==========================================
        // BOTÓN: MARCAR COMO ASISTIÓ
        // ==========================================
        private void btnAsistio_Click(object sender, EventArgs e)
        {
            if (idTurnoSeleccionado == 0) return;

            // bllTurno.CambiarEstado(idTurnoSeleccionado, "Asistió");
            CargarGrillaDelDia();
        }
    }
}