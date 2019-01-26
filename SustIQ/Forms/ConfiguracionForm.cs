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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.padre.CerrarConfiguracion();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            padre.correo = txtCorreo.Text;
            padre.password = txtPass.Text;

            padre.GuardarConfiguracion();
            btnClose_Click(sender, e);
        }
    }
}
