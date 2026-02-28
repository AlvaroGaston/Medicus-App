using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Medicus.BLL;
using Medicus.Entidades;



namespace Medicus.UX
{
    public partial class frmReportes : Form
    {
        private TurnoBLL bllTurno = new TurnoBLL();
        private SeguridadBLL bllSeguridad = new SeguridadBLL();

        // Lista en memoria para filtrar rápido sin ir a la base de datos a cada rato
        private List<Turno> todosLosTurnos;

        // Variables para la impresión
        private Turno turnoAImprimir;
        private List<Turno> agendaAImprimir;
        private int idMedicoAgenda = 0;
        private string nombreMedicoImpresion;
        private DateTime fechaImpresion;

        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            bllSeguridad.AplicarSeguridadGranular(this, "frmReportes");

            // Inicializamos fechas
            dtpFechaTurnos.Value = DateTime.Today;
            dtpFechaAgenda.Value = DateTime.Today;
            chkTodosLosTurnos.Checked = true; // Por defecto vemos todos en la pestaña 1

            CargarGrillaTurnos();
        }

        // ==========================================
        // 1. PESTAÑA: COMPROBANTE DE TURNO
        // ==========================================
        private void CargarGrillaTurnos()
        {
            todosLosTurnos = bllTurno.ListarTurnos().OrderByDescending(t => t.FechaTurno).ToList();
            FiltrarTurnos(); // Llama al motor de búsqueda
        }

        private void FiltrarTurnos()
        {
            if (todosLosTurnos == null) return;
            var filtrados = todosLosTurnos.AsEnumerable();

            // 1er Filtro: Por Fecha (Si el checkbox NO está tildado)
            if (!chkTodosLosTurnos.Checked)
            {
                filtrados = filtrados.Where(t => t.FechaTurno.Date == dtpFechaTurnos.Value.Date);
            }

            // 2do Filtro: Por Buscador de Texto (Paciente, DNI o Médico)
            string filtroTexto = txtBuscarTurnos.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtroTexto))
            {
                filtrados = filtrados.Where(t =>
                    t.PacienteNombre.ToLower().Contains(filtroTexto) ||
                    t.PacienteDni.ToLower().Contains(filtroTexto) ||
                    t.MedicoNombre.ToLower().Contains(filtroTexto));
            }

            dgvTurnos.DataSource = filtrados.ToList();

            // Ocultamos columnas de IDs
            if (dgvTurnos.Columns["IdTurno"] != null) dgvTurnos.Columns["IdTurno"].Visible = false;
            if (dgvTurnos.Columns["IdPaciente"] != null) dgvTurnos.Columns["IdPaciente"].Visible = false;
            if (dgvTurnos.Columns["IdMedico"] != null) dgvTurnos.Columns["IdMedico"].Visible = false;
        }

        private void txtBuscarTurnos_TextChanged(object sender, EventArgs e) => FiltrarTurnos();
        private void dtpFechaTurnos_ValueChanged(object sender, EventArgs e) => FiltrarTurnos();

        private void chkTodosLosTurnos_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaTurnos.Enabled = !chkTodosLosTurnos.Checked;
            FiltrarTurnos();
        }

        private void btnImprimirComprobante_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un turno de la grilla para imprimir el comprobante.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            turnoAImprimir = (Turno)dgvTurnos.CurrentRow.DataBoundItem;

            PrintDocument pdRecibo = new PrintDocument();
            pdRecibo.PrintPage += new PrintPageEventHandler(DibujarComprobante);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pdRecibo;
            preview.ShowDialog();

            BitacoraBLL.RegistrarMovimiento($"Imprimió comprobante del turno ID: {turnoAImprimir.IdTurno}", "Reportes");
        }

        private void DibujarComprobante(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitulo = new Font("Segoe UI", 18, FontStyle.Bold);
            Font fontSubtitulo = new Font("Segoe UI", 12, FontStyle.Bold);
            Font fontNormal = new Font("Segoe UI", 11);
            Brush brush = Brushes.Black;
            Pen pen = new Pen(Color.Black, 2);

            int y = 50;
            int margin = 50;

            g.DrawString("CLÍNICA MEDICUS", fontTitulo, brush, margin, y);
            y += 30;
            g.DrawString("Comprobante de Turno Médico", fontSubtitulo, brush, margin, y);
            y += 20;
            g.DrawLine(pen, margin, y, e.PageBounds.Width - margin, y);
            y += 30;

            g.DrawString($"Fecha de Emisión: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal, brush, margin, y);
            y += 40;
            g.DrawString($"PACIENTE: {turnoAImprimir.PacienteNombre}", fontSubtitulo, brush, margin, y);
            y += 25;
            g.DrawString($"DNI: {turnoAImprimir.PacienteDni}", fontNormal, brush, margin, y);
            y += 40;
            g.DrawString($"MÉDICO: {turnoAImprimir.MedicoNombre}", fontSubtitulo, brush, margin, y);
            y += 25;
            g.DrawString($"Especialidad: {turnoAImprimir.Especialidad}", fontNormal, brush, margin, y);
            y += 40;

            g.DrawRectangle(pen, margin, y, 400, 100);
            g.DrawString($"FECHA DEL TURNO: {turnoAImprimir.FechaTurno:dd/MM/yyyy}", fontSubtitulo, brush, margin + 20, y + 20);
            g.DrawString($"HORA: {turnoAImprimir.HoraTurno:hh\\:mm}", fontSubtitulo, brush, margin + 20, y + 50);
            y += 130;

            g.DrawString($"Motivo/Observaciones: {turnoAImprimir.Motivo}", fontNormal, brush, margin, y);
            y += 60;
            g.DrawLine(pen, margin, y, e.PageBounds.Width - margin, y);
            y += 20;
            g.DrawString("Por favor, presentarse 15 minutos antes del horario asignado.", new Font("Segoe UI", 10, FontStyle.Italic), brush, margin, y);
        }

        // ==========================================
        // 2. PESTAÑA: AGENDA DIARIA DEL MÉDICO
        // ==========================================
        private void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            // Usamos el buscador inteligente de médicos que ya teníamos
            using (frmBuscarMedico frmBuscadorM = new frmBuscarMedico())
            {
                if (frmBuscadorM.ShowDialog() == DialogResult.OK)
                {
                    idMedicoAgenda = frmBuscadorM.IdSeleccionado;
                    txtMedicoAgenda.Text = frmBuscadorM.NombreSeleccionado;
                }
            }
        }

        private void btnImprimirAgenda_Click(object sender, EventArgs e)
        {
            if (idMedicoAgenda == 0)
            {
                MessageBox.Show("Por favor, busque y seleccione un médico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fechaImpresion = dtpFechaAgenda.Value.Date;
            nombreMedicoImpresion = txtMedicoAgenda.Text;

            // Filtramos la agenda
            agendaAImprimir = bllTurno.ListarTurnos()
                .Where(t => t.IdMedico == idMedicoAgenda && t.FechaTurno.Date == fechaImpresion && t.Estado != "Cancelado")
                .OrderBy(t => t.HoraTurno).ToList();

            if (agendaAImprimir.Count == 0)
            {
                MessageBox.Show("El médico no tiene turnos activos para la fecha seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDocument pdAgenda = new PrintDocument();
            pdAgenda.PrintPage += new PrintPageEventHandler(DibujarAgenda);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pdAgenda;
            preview.ShowDialog();

            BitacoraBLL.RegistrarMovimiento($"Imprimió agenda del Dr. ID: {idMedicoAgenda} para la fecha {fechaImpresion:dd/MM/yyyy}", "Reportes");
        }

        private void DibujarAgenda(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            Font fontColumna = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fontFila = new Font("Segoe UI", 10);
            Brush brush = Brushes.Black;
            Pen pen = new Pen(Color.Black, 1);

            int y = 50;
            int margin = 50;

            g.DrawString("MEDICUS - AGENDA DIARIA DE TURNOS", fontTitulo, brush, margin, y);
            y += 40;
            g.DrawString($"Profesional: {nombreMedicoImpresion}", fontColumna, brush, margin, y);
            y += 20;
            g.DrawString($"Fecha: {fechaImpresion:dd/MM/yyyy}", fontColumna, brush, margin, y);
            y += 30;

            g.DrawLine(pen, margin, y, e.PageBounds.Width - margin, y);
            y += 5;
            g.DrawString("HORA", fontColumna, brush, margin, y);
            g.DrawString("PACIENTE", fontColumna, brush, margin + 80, y);
            g.DrawString("DNI", fontColumna, brush, margin + 350, y);
            g.DrawString("ESTADO", fontColumna, brush, margin + 450, y);
            y += 20;
            g.DrawLine(pen, margin, y, e.PageBounds.Width - margin, y);
            y += 10;

            foreach (var t in agendaAImprimir)
            {
                g.DrawString(t.HoraTurno.ToString(@"hh\:mm"), fontFila, brush, margin, y);
                g.DrawString(t.PacienteNombre, fontFila, brush, margin + 80, y);
                g.DrawString(t.PacienteDni, fontFila, brush, margin + 350, y);
                g.DrawString(t.Estado, fontFila, brush, margin + 450, y);
                y += 25;

                if (y > e.PageBounds.Height - 100)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }
    }
}