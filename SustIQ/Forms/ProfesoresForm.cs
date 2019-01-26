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

        public bool pintar = false;

        public FormProfesores()
        {
            InitializeComponent();
        }

        private void FormProfesores_Load(object sender, EventArgs e)
        {
            pintar = false;

            LlenarDGV();

            // se prepara la lista de horas
            dgvDispMañana.Rows.Add("06:20 am", "", "");
            dgvDispMañana.Rows.Add("07:00 am", "", "");
            dgvDispMañana.Rows.Add("07:40 am", "", "");
            dgvDispMañana.Rows.Add("08:20 am", "", "");
            dgvDispMañana.Rows.Add("09:00 am", "", "");
            dgvDispMañana.Rows.Add("09:40 am", "", "");
            dgvDispMañana.Rows.Add("10:20 am", "", "");
            dgvDispMañana.Rows.Add("11:00 am", "", "");
            dgvDispMañana.Rows.Add("11:40 am", "", "");
            dgvDispMañana.Rows.Add("12:20 m", "", "");
            dgvDispTarde.Rows.Add("01:00 pm", "", "");
            dgvDispTarde.Rows.Add("01:40 pm", "", "");
            dgvDispTarde.Rows.Add("02:20 pm", "", "");
            dgvDispTarde.Rows.Add("03:00 pm", "", "");
            dgvDispTarde.Rows.Add("03:40 pm", "", "");
            dgvDispTarde.Rows.Add("04:20 pm", "", "");
            dgvDispTarde.Rows.Add("05:00 pm", "", "");
            dgvDispTarde.Rows.Add("05:40 pm", "", "");
            dgvDispTarde.Rows.Add("06:20 pm", "", "");

            PintarDispMañana();
            PintarDispTarde();

            pintar = true;
        }

        /// <summary>
        /// Llena el Data Grid View
        /// </summary>
        public void LlenarDGV()
        {
            pintar = false;
            this.dgvProf.Rows.Clear();

            for (int i = 0; i < padre.profesores.Count; i++)
            {
                this.dgvProf.Rows.Add(padre.profesores[i].nombres, padre.profesores[i].apellidos, padre.profesores[i].correo);
                if (padre.profesores[i].planta) dgvProf.Rows[i].Cells[3].Value = true;
            }
            pintar = true;
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
                int eliminar = dgvProf.CurrentCell.RowIndex;
                padre.profesores.RemoveAt(dgvProf.CurrentCell.RowIndex);
                this.LlenarDGV();
                if (eliminar >= padre.profesores.Count) eliminar--;
                dgvProf.CurrentCell = dgvProf.Rows[eliminar].Cells[0];
                PintarDispMañana();
                PintarDispTarde();
            }
        }

        

        public void PintarDispMañana()
        {
            // se obtiene el indice del profesor
            int iprof = dgvProf.CurrentCell.RowIndex;

            int N = padre.profesores[0].dispMañana.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                if (padre.profesores[iprof].dispMañana[i, 0]) dgvDispMañana.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                else dgvDispMañana.Rows[i].Cells[1].Style.BackColor = Color.Red;

                if (padre.profesores[iprof].dispMañana[i, 1]) dgvDispMañana.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                else dgvDispMañana.Rows[i].Cells[2].Style.BackColor = Color.Red;
            }
        }

        public void PintarDispTarde()
        {
            // se obtiene el indice del profesor
            int iprof = dgvProf.CurrentCell.RowIndex;

            int N = padre.profesores[0].dispTarde.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                if (padre.profesores[iprof].dispTarde[i, 0]) dgvDispTarde.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                else dgvDispTarde.Rows[i].Cells[1].Style.BackColor = Color.Red;

                if (padre.profesores[iprof].dispTarde[i, 1]) dgvDispTarde.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                else dgvDispTarde.Rows[i].Cells[2].Style.BackColor = Color.Red;
            }
        }

        private void dgvProf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                // se obtiene el indice del profesor
                int iprof = dgvProf.CurrentCell.RowIndex;
                padre.profesores[iprof].planta = !padre.profesores[iprof].planta;
            } 
        }

        private void dgvProf_SelectionChanged(object sender, EventArgs e)
        {
            if(pintar)
            {
                if (dgvProf.CurrentCell.RowIndex < padre.profesores.Count)
                {
                    PintarDispMañana();
                    PintarDispTarde();
                }
            }
        }

        private void dgvDispMañana_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 1)
            {
                // se obtiene el indice del profesor
                int iprof = dgvProf.CurrentCell.RowIndex;

                // se obtienen las coordenadas de la celda de disponibilidad seleccionada
                int i = e.RowIndex;
                int j = e.ColumnIndex - 1;

                padre.profesores[iprof].dispMañana[i, j] = !padre.profesores[iprof].dispMañana[i, j];
                PintarDispMañana();
            }
        }

        private void dgvDispTarde_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 1)
            {
                // se obtiene el indice del profesor
                int iprof = dgvProf.CurrentCell.RowIndex;

                // se obtienen las coordenadas de la celda de disponibilidad seleccionada
                int i = e.RowIndex;
                int j = e.ColumnIndex - 1;

                padre.profesores[iprof].dispTarde[i, j] = !padre.profesores[iprof].dispTarde[i, j];
                PintarDispTarde();
            }
        }

        private void dgvDispMañana_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex>0)
            {
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
        }

        private void dgvDispTarde_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void dgvProf_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (pintar)
            {
                padre.profesores.Add(new CProfesor());
                if (dgvProf.CurrentCell.RowIndex < padre.profesores.Count)
                {
                    PintarDispMañana();
                    PintarDispTarde();
                }
            }
        }

        private void dgvProf_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (pintar)
            {
                // se obtiene el indice del profesor
                int iprof = dgvProf.CurrentCell.RowIndex;

                switch (e.ColumnIndex)
                {
                    case 0:
                        padre.profesores[iprof].nombres = dgvProf.CurrentCell.Value.ToString();
                        break;
                    case 1:
                        padre.profesores[iprof].apellidos = dgvProf.CurrentCell.Value.ToString();
                        break;
                    case 2:
                        padre.profesores[iprof].correo = dgvProf.CurrentCell.Value.ToString();
                        break;
                }
            }
        }
    }
}
