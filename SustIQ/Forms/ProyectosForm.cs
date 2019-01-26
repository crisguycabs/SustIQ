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
    public partial class s : Form
    {
        public Main padre;

        /// <summary>
        /// Modo-> True: se agrega un nuevo proyecto    False: se modifica un proyecto existente
        /// </summary>
        public bool modo=true;
        
        /// <summary>
        /// indice a modificar
        /// </summary>
        public int imod = -1;

        public s()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.GuardarSustentacion();
            padre.CerrarProyectosForm();
            this.Close();
        }

        private void ProyectosForm_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            ListarProyectos();
        }

        public void ListarProyectos()
        {
            dgvProyectos.Rows.Clear();

            for (int i = 0; i < padre.actual.proyectos.Count; i++)
            {
                bool incluir = padre.actual.proyectos[i].incluir;
                if (padre.actual.proyectos[i].estudiante2.correo == null)
                {
                    dgvProyectos.Rows.Add((i + 1).ToString(), padre.actual.proyectos[i].codigo.ToString(), padre.actual.proyectos[i].nombre, padre.actual.proyectos[i].estudiante1.nombre, padre.actual.proyectos[i].director.nombres + " " + padre.actual.proyectos[i].director.apellidos, padre.actual.proyectos[i].evaluador1.nombres + " " + padre.actual.proyectos[i].evaluador1.apellidos, padre.actual.proyectos[i].evaluador2.nombres + " " + padre.actual.proyectos[i].evaluador2.apellidos, incluir);
                }
                else
                {
                    dgvProyectos.Rows.Add((i + 1).ToString(), padre.actual.proyectos[i].codigo.ToString(), padre.actual.proyectos[i].nombre, padre.actual.proyectos[i].estudiante1.nombre + " & " + padre.actual.proyectos[i].estudiante2.nombre, padre.actual.proyectos[i].director.nombres + " " + padre.actual.proyectos[i].director.apellidos, padre.actual.proyectos[i].evaluador1.nombres + " " + padre.actual.proyectos[i].evaluador1.apellidos, padre.actual.proyectos[i].evaluador2.nombres + " " + padre.actual.proyectos[i].evaluador2.apellidos, incluir);
                }
            }
        }

        public void Limpiar()
        {
            this.txtCodProy.Clear();
            this.txtMailEst1.Clear();
            this.txtMailEst2.Clear();
            this.txtNombreEst1.Clear();
            this.txtNombreEst2.Clear();
            this.txtNombreProy.Clear();
            this.txtSoporte.Clear();
            comboDirector.SelectedIndex=-1;
            comboEval1.SelectedIndex=-1;
            comboEval2.SelectedIndex=-1;

            btnAdd.Text = "Agregar";
        }

        private void btnAddProf_Click(object sender, EventArgs e)
        {
            padre.AbrirFormProfesores();
            ReLlenarCombos();
        }

        public void ReLlenarCombos()
        {
            comboDirector.Items.Clear();
            comboEval1.Items.Clear();
            comboEval2.Items.Clear();

            LlenarCombos();
        }

        public void LlenarCombos()
        {
            for(int i=0;i<padre.profesores.Count;i++)
            {
                comboDirector.Items.Add(padre.profesores[i].apellidos + " " + padre.profesores[i].nombres);
                comboEval1.Items.Add(padre.profesores[i].apellidos + " " + padre.profesores[i].nombres);
                comboEval2.Items.Add(padre.profesores[i].apellidos + " " + padre.profesores[i].nombres);
            }
        }

        private void btnSoporte_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "archivos pdf (*.pdf)|*.pdf|archivos doc (*.doc)|*.doc|archivos docx (*.docx)|*.docx";
            if(abrir.ShowDialog()==DialogResult.OK)
            {
                txtSoporte.Text = abrir.FileName;
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txtSoporte.Text);
            }
            catch
            { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // verificaciones de seguridad
            
            // codigo de proyecto
            if(String.IsNullOrWhiteSpace(txtCodProy.Text))
            {
                MessageBox.Show("Codigo de proyecto vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodProy.Focus();
                return;
            }
            try
            {
                int testCodigo = Convert.ToInt32(txtCodProy.Text);
            }
            catch
            {
                MessageBox.Show("El codigo del proyecto no es un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodProy.Focus();
                return;
            }

            // nombre de proyecto
            if (String.IsNullOrWhiteSpace(txtNombreProy.Text))
            {
                MessageBox.Show("Nombre de proyecto vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreProy.Focus();
                return;
            }

            // soporte
            if (String.IsNullOrWhiteSpace(txtSoporte.Text))
            {
                MessageBox.Show("No se ha seleccionado un archivo de soporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoporte.Focus();
                return;
            }

            // nombre del estudiante 1
            if (String.IsNullOrWhiteSpace(this.txtNombreEst1.Text))
            {
                MessageBox.Show("Nombre del estudiante 1 vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreEst1.Focus();
                return;
            }

            // correo estudiante 1
            if (String.IsNullOrWhiteSpace(this.txtMailEst1.Text))
            {
                MessageBox.Show("Correo para el estudiante 1 vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMailEst1.Focus();
                return;
            }
            else if (!Main.ValidarEmail(txtMailEst1.Text))
            {
                MessageBox.Show("Correo incorrecto para el estudiante 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMailEst1.Focus();
                return;
            }

            bool estudiante2 = true;
            // nombre del estudiante 2
            if (String.IsNullOrWhiteSpace(this.txtNombreEst2.Text))
            {
                estudiante2 = false;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.txtMailEst2.Text)) // correo estudiante 2
                {
                    MessageBox.Show("Correo para el estudiante 2 vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMailEst1.Focus();
                    return;
                }
                else if (!Main.ValidarEmail(txtMailEst2.Text))
                {
                    MessageBox.Show("Correo incorrecto para el estudiante 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMailEst1.Focus();
                    return;
                }
            }

            if(comboDirector.SelectedIndex<0)
            {
                MessageBox.Show("No se ha seleccionado un Director de proyectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDirector.Focus();
                return;
            }

            if (this.comboEval1.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha seleccionado el Evaluador 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboEval1.Focus();
                return;
            }

            if (this.comboEval2.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha seleccionado el Evaluador 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboEval2.Focus();
                return;
            }

            if(comboDirector.SelectedIndex == comboEval1.SelectedIndex)
            {
                MessageBox.Show("El Director y el Evaluador 1 no pueden ser el mismo profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboDirector.SelectedIndex == comboEval2.SelectedIndex)
            {
                MessageBox.Show("El Director y el Evaluador 2 no pueden ser el mismo profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboEval1.SelectedIndex == comboEval2.SelectedIndex)
            {
                MessageBox.Show("El Evaluador 1 y el Evaluador 2 no pueden ser el mismo profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNombreProy.Text=txtNombreProy.Text.Replace("\r\n", "");

            if (modo) // modo=true se AGREGA un nuevo registro
            {
                // primero se debe crear una copia del soporte y cambiar la ruta que se va a guardar en la lista
                string folder = System.IO.Path.GetDirectoryName(padre.actual.path);
                string newPath = folder + "\\" + txtCodProy.Text + System.IO.Path.GetExtension(txtSoporte.Text);
                System.IO.File.Copy(txtSoporte.Text, newPath,true);

                if(estudiante2)
                {
                    padre.actual.proyectos.Add(new CProyecto(Convert.ToInt32(txtCodProy.Text), txtNombreProy.Text, new CEstudiante(txtNombreEst1.Text, txtMailEst1.Text), new CEstudiante(txtNombreEst2.Text, txtMailEst2.Text), new CProfesor(padre.profesores[comboDirector.SelectedIndex]), new CProfesor(padre.profesores[comboEval1.SelectedIndex]), new CProfesor(padre.profesores[comboEval2.SelectedIndex]), newPath));
                }
                else
                {
                    padre.actual.proyectos.Add(new CProyecto(Convert.ToInt32(txtCodProy.Text), txtNombreProy.Text, new CEstudiante(txtNombreEst1.Text, txtMailEst1.Text), new CEstudiante(), new CProfesor(padre.profesores[comboDirector.SelectedIndex]), new CProfesor(padre.profesores[comboEval1.SelectedIndex]), new CProfesor(padre.profesores[comboEval2.SelectedIndex]), newPath));
                }
                Limpiar();
                ListarProyectos();

                dgvProyectos.Rows[padre.actual.proyectos.Count-1].Selected = true;
                dgvProyectos.CurrentCell = dgvProyectos.Rows[padre.actual.proyectos.Count - 1].Cells[0];

                modo = true;
            }
            else // modo=false se MODIFICA un registro existente
            {
                // se cambian los soportes en caso de que se halla cambiado el contenido de TxtSoporte
                string oldSoporte = padre.actual.proyectos[imod].soporte;
                string newSoporte = txtSoporte.Text;
                if (oldSoporte != newSoporte) // no hacer nada en caso de que el viejo y nuevo soporte sea igual
                {
                    // se mueve el nuevo soporte a la carpeta
                    string folder = System.IO.Path.GetDirectoryName(padre.actual.path);
                    string newPath = folder + "\\" + txtCodProy.Text + System.IO.Path.GetExtension(txtSoporte.Text);
                    System.IO.File.Copy(txtSoporte.Text, newPath, true);
                }

                // se actualiza el resto de la informacion
                padre.actual.proyectos[imod].codigo = Convert.ToInt32(Convert.ToInt32(txtCodProy.Text));
                padre.actual.proyectos[imod].director = new CProfesor(padre.profesores[comboDirector.SelectedIndex]);
                padre.actual.proyectos[imod].estudiante1.correo = txtMailEst1.Text;
                padre.actual.proyectos[imod].estudiante1.nombre = txtNombreEst1.Text;
                if(estudiante2)
                {
                    padre.actual.proyectos[imod].estudiante2.correo = txtMailEst2.Text;
                    padre.actual.proyectos[imod].estudiante2.nombre = txtNombreEst2.Text;
                }
                else
                {
                    padre.actual.proyectos[imod].estudiante2.correo = null;
                    padre.actual.proyectos[imod].estudiante2.nombre = null;
                }
                padre.actual.proyectos[imod].evaluador1 = new CProfesor(padre.profesores[this.comboEval1.SelectedIndex]);
                padre.actual.proyectos[imod].evaluador2 = new CProfesor(padre.profesores[this.comboEval2.SelectedIndex]);
                padre.actual.proyectos[imod].nombre = txtNombreProy.Text;
                padre.actual.proyectos[imod].soporte = newSoporte;

                int t = imod;
                ListarProyectos();
                dgvProyectos.Rows[t].Selected = true;
                dgvProyectos.CurrentCell = dgvProyectos.Rows[t].Cells[0];

                imod = -1;
                modo = true;
                Limpiar();
            }
        }

        private void dgvProyectos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // al hacer doble click sobre un registro se carga la información del registro en los textbox y se modifica el texto del boton AGREGAR por MODIFICAR

            btnAdd.Text = "Modificar";
            imod = dgvProyectos.CurrentCell.RowIndex;

            txtCodProy.Text = padre.actual.proyectos[imod].codigo.ToString();
            txtNombreProy.Text = padre.actual.proyectos[imod].nombre;
            txtSoporte.Text = padre.actual.proyectos[imod].soporte;
            txtMailEst1.Text = padre.actual.proyectos[imod].estudiante1.correo;
            txtNombreEst1.Text = padre.actual.proyectos[imod].estudiante1.nombre;
            txtMailEst2.Text = padre.actual.proyectos[imod].estudiante2.correo;
            txtNombreEst2.Text = padre.actual.proyectos[imod].estudiante2.nombre;
            
            for(int j=0;j<padre.profesores.Count;j++)
            {
                if (padre.profesores[j].apellidos == padre.actual.proyectos[imod].director.apellidos) comboDirector.SelectedIndex = j;
                if (padre.profesores[j].apellidos == padre.actual.proyectos[imod].evaluador1.apellidos) comboEval1.SelectedIndex = j;
                if (padre.profesores[j].apellidos == padre.actual.proyectos[imod].evaluador2.apellidos) comboEval2.SelectedIndex = j;
            }

            modo = false;
        }

        /// <summary>
        /// Se cambio la fila seleccionada, por tanto no se aplica la modificacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProyectos_SelectionChanged(object sender, EventArgs e)
        {
            imod = -1;
            modo = true;
            Limpiar();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = dgvProyectos.CurrentCell.RowIndex;
                padre.actual.proyectos.RemoveAt(indice);
                Limpiar();
                dgvProyectos.Rows.Clear();
                ListarProyectos();
            }
            catch
            { }
        }

        private void dgvProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                // se obtiene el indice del proyecto
                int iproy = dgvProyectos.CurrentCell.RowIndex;
                padre.actual.proyectos[iproy].incluir = !padre.actual.proyectos[iproy].incluir;
            } 
        }
    }
}
