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
    public partial class frmRegistro : Form
    {
        private UsuarioBLL bllUsuario = new UsuarioBLL();

        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtClave.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifíquelas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Armamos el objeto usuario
            Usuario nuevoUsuario = new Usuario
            {
                Documento = txtDocumento.Text.Trim(),
                NombreCompleto = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Clave = txtClave.Text // Se encripta en la BLL
            };

            // 3. Mandamos a guardar
            string resultado = bllUsuario.RegistrarUsuario(nuevoUsuario);

            if (resultado == "OK")
            {
                MessageBox.Show("¡Cuenta creada con éxito! Ahora puede iniciar sesión.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerramos la ventana y vuelve al Login
            }
            else
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}