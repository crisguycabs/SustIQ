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
    public partial class FormProfesores : Form
    {
        /// <summary>
        /// Instancia de la forma Main
        /// </summary>
        public Main padre = null;

        public FormProfesores()
        {
            InitializeComponent();
        }

        private void FormProfesores_Load(object sender, EventArgs e)
        {
            LlenarDGV();
        }

        /// <summary>
        /// Llena el Data Grid View
        /// </summary>
        public void LlenarDGV()
        {
            this.dgvProf.Rows.Clear();

            for (int i = 0; i < padre.profesores.Count; i++)
            {
                this.dgvProf.Rows.Add(padre.profesores[i].nombres, padre.profesores[i].apellidos, padre.profesores[i].correo);
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.padre.CerrarFormProfesores();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            padre.AbrirAddProfesoresForm(true,-1);
            this.LlenarDGV();
            dgvProf.Rows[padre.profesores.Count - 1].Selected = true;
            dgvProf.CurrentCell = dgvProf.Rows[padre.profesores.Count - 1].Cells[0];
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            int index=dgvProf.CurrentCell.RowIndex;
            padre.AbrirAddProfesoresForm(false,index);
            this.LlenarDGV();
            dgvProf.Rows[index].Selected = true;
            dgvProf.CurrentCell = dgvProf.Rows[index].Cells[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar este registro?","Confirmación de eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                padre.profesores.RemoveAt(dgvProf.CurrentCell.RowIndex);
                this.LlenarDGV();
            }
        }

        private void dgvProf_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvProf.CurrentCell.RowIndex;
            padre.AbrirAddProfesoresForm(false, index);
            this.LlenarDGV();
            dgvProf.Rows[index].Selected = true;
            dgvProf.CurrentCell = dgvProf.Rows[index].Cells[0];
        }
    }
}
