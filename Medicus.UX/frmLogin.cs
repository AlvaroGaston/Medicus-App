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
    public partial class frmLogin : Form
    {
        private UsuarioBLL bllUsuario = new UsuarioBLL();
        private SeguridadBLL bllSeguridad = new SeguridadBLL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones "Estilo Facebook" (No dejar campos vacíos)
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El correo electrónico o número de documento es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            try
            {
                // 2. Intento de Login (La BLL ya encripta en SHA256)
                Usuario user = bllUsuario.Login(txtDocumento.Text.Trim(), txtClave.Text);

                if (user != null)
                {
                    // 3. Guardamos la Sesión
                    Sesion.UsuarioActual = user;

                    // 4. Cargamos los Permisos
                    if (user.IdGrupo.HasValue)
                        Sesion.PermisosActuales = bllSeguridad.ListarPermisos(user.IdGrupo.Value);
                    else
                        Sesion.PermisosActuales = new List<Permiso>();

                    // ==========================================
                    // 5. REGISTRAMOS EL INGRESO EN LA BITÁCORA
                    // ==========================================
                    BitacoraBLL.RegistrarMovimiento("Inició sesión en el sistema", "Acceso");

                    // 6. Redirigimos al Inicio
                    frmInicio inicio = new frmInicio();
                    inicio.Show();
                    this.Hide();
                }
                else
                {
                    // Mensaje genérico por seguridad (para que no sepan si falló el usuario o la clave)
                    MessageBox.Show("El documento o la contraseña que ingresaste son incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abre la pantalla de recuperar contraseña
            frmRecuperar recuperar = new frmRecuperar();
            recuperar.ShowDialog();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Abre la pantalla de Crear Cuenta Nueva
            frmRegistro registro = new frmRegistro();
            registro.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}