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

namespace Medicus.UX
{
    public partial class frmRecuperar : Form
    {
        private UsuarioBLL bllUsuario = new UsuarioBLL();

        public frmRecuperar()
        {
            InitializeComponent();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtDocumento.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtNuevaClave.Text) || string.IsNullOrWhiteSpace(txtConfirmar.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevaClave.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentamos restablecer
            string resultado = bllUsuario.RecuperarClave(txtDocumento.Text.Trim(), txtCorreo.Text.Trim(), txtNuevaClave.Text);

            if (resultado == "OK")
            {
                MessageBox.Show("Tu contraseña ha sido actualizada correctamente. Ya podés iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Vuelve al login
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