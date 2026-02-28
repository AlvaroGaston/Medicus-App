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
using System.Windows.Forms.DataVisualization.Charting;

namespace Medicus.UX
{
    public partial class frmInicio : Form
    {
        private TurnoBLL bllTurno = new TurnoBLL();
        private DashboardBLL bllDashboard = new DashboardBLL();

        public frmInicio()
        {
            InitializeComponent();
            // 1. Garantizamos que el Dashboard inicie en pantalla completa
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            if (!Sesion.HaySesionActiva())
            {
                Application.Exit();
                return;
            }

            lblBienvenida.Text = $"Hola, {Sesion.UsuarioActual.NombreCompleto}";
            lblRol.Text = Sesion.UsuarioActual.Documento.ToLower() == "admin" ? "Administrador Supremo" : "Usuario del Sistema";

            ConfigurarMenuSeguridad();

            // Cargamos todo por primera vez
            ActualizarDashboard();
        }

        private void ConfigurarMenuSeguridad()
        {
            // 2. Si es el Administrador Supremo, tiene acceso a todo
            if (Sesion.UsuarioActual.Documento.ToLower() == "admin")
            {
                btnSeguridad.Visible = true;
                btnMantenimiento.Visible = true;
                return;
            }

            // 3. BLINDAJE ESTRICTO: Para cualquier otro usuario, estos módulos desaparecen
            btnSeguridad.Visible = false;
            btnMantenimiento.Visible = false;

            // 4. Mapeo del menú lateral según los permisos de acceso a las pantallas
            btnTurnos.Visible = TienePermiso("frmTurnos");
            btnPacientes.Visible = TienePermiso("frmPacientes");
            btnMedicos.Visible = TienePermiso("frmMedicos");
            btnBitacora.Visible = TienePermiso("frmBitacora");
            btnReportes.Visible = TienePermiso("frmReportes");
        }

        private bool TienePermiso(string nombreMenu)
        {
            var permiso = Sesion.PermisosActuales?.FirstOrDefault(p => p.NombreMenu == nombreMenu);
            return permiso != null && permiso.PuedeVer;
        }

        // ==========================================
        // LÓGICA DEL DASHBOARD Y ACTUALIZACIÓN
        // ==========================================
        private void ActualizarDashboard()
        {
            CargarTarjetasInformativas();
            GenerarGraficos();

            // Al reasignar la fecha, forzamos a que se dispare el evento que recarga la grilla
            DateTime fechaActual = dtpFechaFiltro.Value;
            dtpFechaFiltro.Value = fechaActual.AddDays(1);
            dtpFechaFiltro.Value = fechaActual;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // AUDITORÍA
            BitacoraBLL.RegistrarMovimiento("Actualizó los datos del Dashboard", "Dashboard");
            ActualizarDashboard();
        }

        private void CargarTarjetasInformativas()
        {
            lblNumPacientes.Text = bllDashboard.ObtenerTotalPacientes().ToString();
            lblNumMedicos.Text = bllDashboard.ObtenerTotalMedicos().ToString();
        }

        private void GenerarGraficos()
        {
            // Limpiamos los paneles por si estamos apretando el botón de Actualizar
            panelGrafico1.Controls.Clear();
            panelGrafico2.Controls.Clear();

            // -----------------------------------------------------
            // 1. Gráfico de Especialidades (Estilo Dona Moderno)
            // -----------------------------------------------------
            Chart chartEsp = new Chart { Dock = DockStyle.Fill };
            chartEsp.Titles.Add(new Title("Turnos por Especialidad", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));
            chartEsp.ChartAreas.Add(new ChartArea("Area1"));
            chartEsp.Legends.Add(new Legend("Legend1") { Docking = Docking.Bottom }); // Leyenda abajo

            Series s1 = new Series("Especialidades")
            {
                ChartType = SeriesChartType.Doughnut, // Dona (Doughnut)
                IsValueShownAsLabel = true
            };
            chartEsp.Series.Add(s1);
            chartEsp.Palette = ChartColorPalette.Pastel; // Colores suaves

            var datosEsp = bllDashboard.ObtenerTurnosPorEspecialidad();
            foreach (var item in datosEsp) s1.Points.AddXY(item.Key, item.Value);

            panelGrafico1.Controls.Add(chartEsp);

            // -----------------------------------------------------
            // 2. Gráfico de Estados (Barras limpias)
            // -----------------------------------------------------
            Chart chartEst = new Chart { Dock = DockStyle.Fill };
            chartEst.Titles.Add(new Title("Estado de los Turnos", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));

            ChartArea ca2 = new ChartArea("Area1");
            ca2.AxisX.MajorGrid.Enabled = false; // Sacamos las líneas verticales de fondo
            ca2.AxisY.MajorGrid.LineColor = Color.LightGray; // Suavizamos las horizontales
            chartEst.ChartAreas.Add(ca2);

            Series s2 = new Series("Estados")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Palette = ChartColorPalette.SeaGreen // Paleta de colores distintiva
            };
            chartEst.Series.Add(s2);

            var datosEst = bllDashboard.ObtenerTurnosPorEstado();
            foreach (var item in datosEst) s2.Points.AddXY(item.Key, item.Value);

            panelGrafico2.Controls.Add(chartEst);
        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            var todosLosTurnos = bllTurno.ListarTurnos();
            var turnosDelDia = todosLosTurnos.Where(t => t.FechaTurno.Date == dtpFechaFiltro.Value.Date).ToList();

            dgvTurnosDia.DataSource = turnosDelDia;
            lblTotalDia.Text = $"Total de turnos para este día: {turnosDelDia.Count}";

            if (dgvTurnosDia.Columns["IdTurno"] != null) dgvTurnosDia.Columns["IdTurno"].Visible = false;
            if (dgvTurnosDia.Columns["IdPaciente"] != null) dgvTurnosDia.Columns["IdPaciente"].Visible = false;
            if (dgvTurnosDia.Columns["IdMedico"] != null) dgvTurnosDia.Columns["IdMedico"].Visible = false;
        }

        // ==========================================
        // NAVEGACIÓN Y AUDITORÍA DETALLADA
        // ==========================================
        private void btnTurnos_Click(object sender, EventArgs e)
        {
            BitacoraBLL.RegistrarMovimiento("Accedió al módulo de Gestión de Turnos", "Navegación");
            new frmTurnos().ShowDialog();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            BitacoraBLL.RegistrarMovimiento("Accedió al módulo de Pacientes", "Navegación");
            new frmPacientes().ShowDialog();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            BitacoraBLL.RegistrarMovimiento("Accedió al módulo de Médicos", "Navegación");
            new frmMedicos().ShowDialog();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            BitacoraBLL.RegistrarMovimiento("Accedió al módulo de Seguridad y Roles", "Navegación");
            new frmSeguridad().ShowDialog();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            BitacoraBLL.RegistrarMovimiento("Accedió al módulo de Auditoría (Bitácora)", "Navegación");
            new frmBitacora().ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            BitacoraBLL.RegistrarMovimiento("Accedió al módulo de Reportes", "Navegación");
            new frmReportes().ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas cerrar la sesión?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // AUDITORÍA (Registramos antes de destruir la sesión)
                BitacoraBLL.RegistrarMovimiento("Cerró sesión en el sistema", "Acceso");

                Sesion.CerrarSesion();
                this.Hide();
                new frmLogin().Show();
            }
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            // Registramos que alguien entró a una zona sensible
            BitacoraBLL.RegistrarMovimiento("Ingresó al módulo de Mantenimiento", "Seguridad");

            // Abrimos el formulario de Backup y Restauración
            frmMantenimiento frm = new frmMantenimiento();
            frm.ShowDialog();
        }

        private void frmInicio_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}