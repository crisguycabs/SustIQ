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
    public partial class SalonesForm : Form
    {
        /// <summary>
        /// Instancia del main
        /// </summary>
        public Main padre = null;

        public SalonesForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.CerrarSalonesForm();
            this.Close();
        }

        private void SalonesForm_Load(object sender, EventArgs e)
        {
            LlenarDGV();
        }

        public void LlenarDGV()
        {
            dgvSalones.Rows.Clear();

            for (int i = 0; i < padre.salones.Count; i++)
            {
                this.dgvSalones.Rows.Add(padre.salones[i].nombre, padre.salones[i].edificio);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            padre.AbrirAddSalonesForm(true, -1);
            this.LlenarDGV();
            dgvSalones.Rows[padre.salones.Count - 1].Selected = true;
            dgvSalones.CurrentCell = dgvSalones.Rows[padre.salones.Count - 1].Cells[0];
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            padre.CerrarSalonesForm();
            this.Close();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            int index = dgvSalones.CurrentCell.RowIndex;
            padre.AbrirAddSalonesForm(false, index);
            this.LlenarDGV();
            dgvSalones.Rows[index].Selected = true;
            dgvSalones.CurrentCell = dgvSalones.Rows[index].Cells[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar este registro?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                padre.salones.RemoveAt(dgvSalones.CurrentCell.RowIndex);
                this.LlenarDGV();
            }
        }
    }
}
