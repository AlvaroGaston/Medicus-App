using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Medicus.BLL;
using Medicus.Entidades;

namespace Medicus.UX
{
    public partial class frmSeguridad : Form
    {
        private SeguridadBLL bllSeguridad = new SeguridadBLL();

        public frmSeguridad()
        {
            InitializeComponent();
        }

        private void frmSeguridad_Load(object sender, EventArgs e)
        {
            // Vinculamos los eventos de la grilla acá para el efecto "Cascada" sin tocar el Designer
            dgvPermisos.CellValueChanged += dgvPermisos_CellValueChanged;
            dgvPermisos.CurrentCellDirtyStateChanged += dgvPermisos_CurrentCellDirtyStateChanged;

            // Aplicar seguridad a la propia pantalla
            bllSeguridad.AplicarSeguridadGranular(this, "frmSeguridad");
            CargarListaGrupos();
        }

        private void CargarListaGrupos()
        {
            lstGrupos.DataSource = null;
            var todosLosGrupos = bllSeguridad.ListarGrupos();

            // UX/Seguridad: Ocultamos al "Administrador" de la lista para evitar confusiones (su grilla está vacía a propósito)
            lstGrupos.DataSource = todosLosGrupos.Where(g => g.Nombre.ToLower() != "administrador").ToList();

            lstGrupos.DisplayMember = "Nombre";
            lstGrupos.ValueMember = "IdGrupo";
        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem != null)
            {
                Grupo seleccionado = (Grupo)lstGrupos.SelectedItem;
                CargarMatrizPermisos(seleccionado.IdGrupo);
            }
        }

        // ========================================================
        // NUEVA MATRIZ JERÁRQUICA CON UX/UI
        // ========================================================
        private void CargarMatrizPermisos(int idGrupo)
        {
            var permisos = bllSeguridad.ListarPermisos(idGrupo);

            // Filtramos los módulos de administración para que no se puedan asignar
            var permisosVisibles = permisos.Where(p =>
                p.NombreMenu != "frmSeguridad" &&
                p.NombreMenu != "frmMantenimiento" &&
                p.NombreMenu != "btnGenerarBackup" &&
                p.NombreMenu != "btnEjecutarRestore"
            ).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("IdPermiso", typeof(int));
            dt.Columns.Add("Módulo_y_Acción", typeof(string));
            dt.Columns.Add("NombreMenuReal", typeof(string));
            dt.Columns.Add("PuedeVer", typeof(bool));
            dt.Columns.Add("PuedeCrear", typeof(bool));
            dt.Columns.Add("PuedeEditar", typeof(bool));
            dt.Columns.Add("PuedeEliminar", typeof(bool));

            // --- ARMADO DEL ÁRBOL ---

            // 1. RECEPCIÓN Y TABLERO
            AgregarFilaJerarquica(dt, permisosVisibles, "frmTableroTurnos", "▶ TABLERO DE RECEPCIÓN");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnNuevoTurno", "      ↳ Botón: Nuevo Turno (Abre Asistente)");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnAsistio", "      ↳ Botón: Marcar Presente");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnCancelarTurno", "      ↳ Botón: Cancelar Turno");

            // 2. ASISTENTE DE TURNOS
            AgregarFilaJerarquica(dt, permisosVisibles, "frmTurnos", "▶ ASISTENTE DE TURNOS");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnConfirmarTurno", "      ↳ Confirmar Turno");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnBuscarPaciente", "      ↳ Buscar Paciente (Lupa)");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnImprimirRecibo", "      ↳ Imprimir Recibo");

            // 3. PACIENTES Y BÚSQUEDA
            AgregarFilaJerarquica(dt, permisosVisibles, "frmPacientes", "▶ PACIENTES");
            AgregarFilaJerarquica(dt, permisosVisibles, "frmBuscarPaciente", "      ↳ Pantalla de Búsqueda de Pacientes");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnGuardarPaciente", "      ↳ Guardar/Alta Paciente");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnEditarPaciente", "      ↳ Editar Paciente");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnEliminarPaciente", "      ↳ Eliminar Paciente");


            // 4. BITÁCORA
            AgregarFilaJerarquica(dt, permisosVisibles, "frmBitacora", "▶ BITÁCORA DE AUDITORÍA");

            // 5. REPORTES
            AgregarFilaJerarquica(dt, permisosVisibles, "frmReportes", "▶ REPORTES E IMPRESIÓN");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnImprimirAgenda", "      ↳ Imprimir Agenda");
            AgregarFilaJerarquica(dt, permisosVisibles, "btnImprimirComprobante", "      ↳ Imprimir Comprobante");

            dgvPermisos.DataSource = dt;

            // LLamada al motor visual
            ConfigurarGrillaUX();

            // Suscripción al evento de pintado dinámico
            dgvPermisos.CellFormatting -= dgvPermisos_CellFormatting;
            dgvPermisos.CellFormatting += dgvPermisos_CellFormatting;
        }

        private void AgregarFilaJerarquica(DataTable dt, List<Permiso> lista, string nombreReal, string nombreVisual)
        {
            var p = lista.FirstOrDefault(x => x.NombreMenu == nombreReal);
            if (p != null)
            {
                dt.Rows.Add(p.IdPermiso, nombreVisual, p.NombreMenu, p.PuedeVer, p.PuedeCrear, p.PuedeEditar, p.PuedeEliminar);
            }
        }

        // ========================================================
        // MOTOR GRÁFICO (UX/UI)
        // ========================================================
        private void ConfigurarGrillaUX()
        {
            // Ocultar columnas técnicas
            if (dgvPermisos.Columns["IdPermiso"] != null) dgvPermisos.Columns["IdPermiso"].Visible = false;
            if (dgvPermisos.Columns["NombreMenuReal"] != null) dgvPermisos.Columns["NombreMenuReal"].Visible = false;

            // Ocultamos las columnas viejas que ya no aportan visualmente
            if (dgvPermisos.Columns["PuedeCrear"] != null) dgvPermisos.Columns["PuedeCrear"].Visible = false;
            if (dgvPermisos.Columns["PuedeEditar"] != null) dgvPermisos.Columns["PuedeEditar"].Visible = false;
            if (dgvPermisos.Columns["PuedeEliminar"] != null) dgvPermisos.Columns["PuedeEliminar"].Visible = false;

            // Estilos generales
            dgvPermisos.EnableHeadersVisualStyles = false;
            dgvPermisos.BackgroundColor = Color.White;
            dgvPermisos.BorderStyle = BorderStyle.None;
            dgvPermisos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPermisos.RowHeadersVisible = false;
            dgvPermisos.AllowUserToResizeRows = false;

            dgvPermisos.ColumnHeadersHeight = 45;
            dgvPermisos.RowTemplate.Height = 35;

            // Estilos del Encabezado
            dgvPermisos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 119, 242);
            dgvPermisos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPermisos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvPermisos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPermisos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Renombrar columnas visibles
            if (dgvPermisos.Columns["Módulo_y_Acción"] != null)
            {
                dgvPermisos.Columns["Módulo_y_Acción"].HeaderText = "Estructura del Sistema";
                dgvPermisos.Columns["Módulo_y_Acción"].Width = 350;
                dgvPermisos.Columns["Módulo_y_Acción"].ReadOnly = true;
            }

            if (dgvPermisos.Columns["PuedeVer"] != null)
            {
                dgvPermisos.Columns["PuedeVer"].HeaderText = "🟢 Habilitado";
                dgvPermisos.Columns["PuedeVer"].Width = 150;
            }
        }

        private void dgvPermisos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string textoModulo = dgvPermisos.Rows[e.RowIndex].Cells["Módulo_y_Acción"].Value?.ToString() ?? "";

            if (textoModulo.StartsWith("▶"))
            {
                dgvPermisos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 242, 245);
                dgvPermisos.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvPermisos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(24, 119, 242);
            }
            else
            {
                dgvPermisos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvPermisos.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                dgvPermisos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        // ========================================================
        // EFECTO CASCADA (Al tildar el padre, se tildan los hijos)
        // ========================================================
        private void dgvPermisos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPermisos.IsCurrentCellDirty)
            {
                dgvPermisos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvPermisos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Chequeamos que estén tocando la columna "PuedeVer" (la única que dejamos visible)
            if (dgvPermisos.Columns[e.ColumnIndex].Name != "PuedeVer") return;

            string nombreVisual = dgvPermisos.Rows[e.RowIndex].Cells["Módulo_y_Acción"].Value.ToString();
            bool valorMarcado = (bool)dgvPermisos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (nombreVisual.StartsWith("▶"))
            {
                for (int i = e.RowIndex + 1; i < dgvPermisos.Rows.Count; i++)
                {
                    string nombreHijo = dgvPermisos.Rows[i].Cells["Módulo_y_Acción"].Value.ToString();
                    if (nombreHijo.StartsWith("▶")) break;

                    dgvPermisos.Rows[i].Cells[e.ColumnIndex].Value = valorMarcado;
                }
            }
        }

        // ========================================================
        // GESTIÓN DE ROLES
        // ========================================================
        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            string nombreRol = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del nuevo rol:", "Nuevo Rol", "");

            if (!string.IsNullOrWhiteSpace(nombreRol))
            {
                string msj = bllSeguridad.CrearRol(nombreRol);
                if (msj == "OK")
                {
                    MessageBox.Show("Rol creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaGrupos();
                }
                else MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarRol_Click(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null) return;
            Grupo seleccionado = (Grupo)lstGrupos.SelectedItem;

            if (seleccionado.Nombre.ToLower() == "admin")
            {
                MessageBox.Show("No se puede renombrar el rol de Administrador por seguridad.", "Protección del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Modificar nombre del rol:", "Editar Rol", seleccionado.Nombre);

            if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != seleccionado.Nombre)
            {
                string msj = bllSeguridad.ModificarRol(seleccionado.IdGrupo, nuevoNombre);
                if (msj == "OK")
                {
                    MessageBox.Show("Nombre del rol actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaGrupos();
                }
                else MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null) return;
            Grupo seleccionado = (Grupo)lstGrupos.SelectedItem;

            if (seleccionado.Nombre.ToLower() == "admin")
            {
                MessageBox.Show("El rol de Administrador es vital y no puede ser eliminado.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var confirm = MessageBox.Show($"¿Está seguro que desea eliminar el rol '{seleccionado.Nombre}'?\nEsta acción borrará también toda su matriz de permisos.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string msj = bllSeguridad.EliminarRol(seleccionado.IdGrupo);
                if (msj == "OK")
                {
                    MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaGrupos();
                }
                else MessageBox.Show(msj, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ========================================================
        // GUARDAR PERMISOS
        // ========================================================
        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            if (dgvPermisos.Rows.Count > 0 && lstGrupos.SelectedItem != null)
            {
                DataTable dt = (DataTable)dgvPermisos.DataSource;
                List<Permiso> listaAGuardar = new List<Permiso>();
                Grupo seleccionado = (Grupo)lstGrupos.SelectedItem;

                foreach (DataRow row in dt.Rows)
                {
                    Permiso p = new Permiso
                    {
                        IdPermiso = Convert.ToInt32(row["IdPermiso"]),
                        IdGrupo = seleccionado.IdGrupo,
                        NombreMenu = row["NombreMenuReal"].ToString(),
                        // Como en la UI solo tocamos el "PuedeVer", replicamos ese estado a las demás columnas en la Base de Datos.
                        PuedeVer = Convert.ToBoolean(row["PuedeVer"]),
                        PuedeCrear = Convert.ToBoolean(row["PuedeVer"]),
                        PuedeEditar = Convert.ToBoolean(row["PuedeVer"]),
                        PuedeEliminar = Convert.ToBoolean(row["PuedeVer"])
                    };
                    listaAGuardar.Add(p);
                }

                bllSeguridad.GuardarPermisos(listaAGuardar);
                BitacoraBLL.RegistrarMovimiento($"Modificó los permisos del rol: {seleccionado.Nombre}", "Seguridad");
                MessageBox.Show("Matriz de permisos actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}