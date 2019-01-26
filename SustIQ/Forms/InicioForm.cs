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
    public partial class InicioForm : Form
    {
        public Main padre = null;

        public InicioForm()
        {
            InitializeComponent();
        }

        private void InicioForm_Load(object sender, EventArgs e)
        {
            labelProductName.ForeColor = Main.colorRojoIQ;
        }

        private void InicioForm_Paint(object sender, PaintEventArgs e)
        {
            int width = this.Width - 1;
            int height = this.Height - 1;
            Pen rojoPen = new Pen(Color.DarkRed, 3);
            e.Graphics.DrawRectangle(rojoPen, 0, 0, width, height);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            padre.NuevaSustentacion();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Title = "Seleccione el archivo de sustentacion a abrir...";
            abrir.Filter = "Archivo de sustentacion (*.sust)|*.sust";
            abrir.DefaultExt = "sust";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                padre.CargarSustentacion(abrir.FileName);
            }
        }
    }
}
