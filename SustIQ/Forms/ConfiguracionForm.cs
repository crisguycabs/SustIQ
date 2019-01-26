using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SustIQ
{
    public partial class ConfiguracionForm : Form
    {
        public Main padre;

        public ConfiguracionForm()
        {
            InitializeComponent();
        }

        private void ConfiguracionForm_Load(object sender, EventArgs e)
        {
            txtCorreo.Text = padre.correo;
            txtPass.Text = padre.password;
            this.btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.padre.CerrarConfiguracion();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro/a que quiere realizar este cambio?","Confirmación de cambios",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (MessageBox.Show("Se perderá la información previa. Desea continuar?", "Confirmación de cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    padre.correo = txtCorreo.Text;
                    padre.password = txtPass.Text;

                    padre.GuardarConfiguracion();
                    btnClose_Click(sender, e);
                }
                else ConfiguracionForm_Load(sender, e);
            }
            else ConfiguracionForm_Load(sender, e);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
