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
    public partial class ProyectosForm : Form
    {
        public Main padre = null;

        public ProyectosForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.CerrarProyectosForm();
            this.Close();
        }

        private void ProyectosForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < padre.profesores.Count; i++)
            {
                comboDirector.Items.Add(padre.profesores[i].nombres + " " + padre.profesores[i].apellidos);
                comboEvaluador1.Items.Add(padre.profesores[i].nombres + " " + padre.profesores[i].apellidos);
                comboEvaluador2.Items.Add(padre.profesores[i].nombres + " " + padre.profesores[i].apellidos);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // verificaciones de seguridad

            // codigo vacio
            if (String.IsNullOrWhiteSpace(txtCodProy.Text))
            {
                MessageBox.Show("El codigo del proyecto de grado no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // nombre de proyecto vacio
            if (String.IsNullOrWhiteSpace(txtNameProy.Text))
            {
                MessageBox.Show("El nombre del proyecto de grado no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // codigo de estudiante 1 vacio
            if (String.IsNullOrWhiteSpace(txtCodEst1.Text))
            {
                MessageBox.Show("El codigo del estudiante 1 no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // nobmre de estudiante 1 vacio
            if (String.IsNullOrWhiteSpace(txtNameEst1.Text))
            {
                MessageBox.Show("El nombre del estudiante 1 no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // correo del estudiante 1 vacio
            if(string.IsNullOrWhiteSpace(txtMailEst1.Text))
            {
                MessageBox.Show("El correo del estudiante 1 no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // correo del estudiante 1 no valido
            if (!Main.ValidarEmail(txtMailEst1.Text))
            {
                MessageBox.Show("El correo del estudiante 1 no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // codigo de estudiante 2 vacio
            if (String.IsNullOrWhiteSpace(txtCodEst2.Text))
            {
                MessageBox.Show("El codigo del estudiante 2 no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // nobmre de estudiante 2 vacio
            if (String.IsNullOrWhiteSpace(txtNameEst2.Text))
            {
                MessageBox.Show("El nombre del estudiante 2 no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // correo del estudiante 2 vacio
            if(string.IsNullOrWhiteSpace(txtMailEst2.Text))
            {
                MessageBox.Show("El correo del estudiante 2 no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // correo del estudiante 2 no valido
            if (!Main.ValidarEmail(txtMailEst2.Text))
            {
                MessageBox.Show("El correo del estudiante 2 no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // director no seleccionado
            if (comboDirector.SelectedIndex < 0)
            {
                MessageBox.Show("No ha seleccionado el director del proyecto de grado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // evaluador 1 no seleccionado
            if (comboEvaluador1.SelectedIndex < 0)
            {
                MessageBox.Show("No ha seleccionado el evaluador 1 del proyecto de grado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // evaluador 2 no seleccionado
            if (comboEvaluador2.SelectedIndex < 0)
            {
                MessageBox.Show("No ha seleccionado el evaluador 2 del proyecto de grado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ruta vacia
            if(string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("No se ha seleccionado un documento de soporte del proyecto de grado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboDirector.SelectedIndex == comboEvaluador1.SelectedIndex)
            {
                MessageBox.Show("El Director y el Evaluador 1 no pueden ser la misma persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboDirector.SelectedIndex == comboEvaluador2.SelectedIndex)
            {
                MessageBox.Show("El Director y el Evaluador 2 no pueden ser la misma persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboEvaluador1.SelectedIndex == comboEvaluador2.SelectedIndex)
            {
                MessageBox.Show("El Evaluador 1 y el Evaluador 2 no pueden ser la misma persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // se pasaron todas las verificaciones de seguridad

            // se agrega el estudiante a memoria
            padre.proyectos.Add(new CProyecto(Convert.ToInt16(txtCodProy.Text), txtNameProy.Text, new CEstudiante(Convert.ToInt16(txtCodEst1.Text), txtNameEst1.Text, txtMailEst1.Text), new CEstudiante(Convert.ToInt16(txtCodEst2.Text), txtNameEst2.Text, txtMailEst2.Text),padre.profesores[comboDirector.SelectedIndex],padre.profesores[comboEvaluador1.SelectedIndex],padre.profesores[comboEvaluador2.SelectedIndex],txtPath.Text));

            LlenarProyectos();
        }

        public void LlenarProyectos()
        {
            dgvProyectos.Rows.Clear();

            string estudiantes;
            string director;
            string eva1;
            string eva2;

            for (int i = 0; i < padre.proyectos.Count; i++)
            {
                estudiantes = padre.proyectos[i].estudiante1.nombre + " - " + padre.proyectos[i].estudiante2.nombre;
                director=padre.proyectos[i].director.nombres + " " + padre.proyectos[i].director.apellidos;
                eva1=padre.proyectos[i].evaluador1.nombres + " " + padre.proyectos[i].evaluador1.apellidos;
                eva2=padre.proyectos[i].evaluador2.nombres + " " + padre.proyectos[i].evaluador2.apellidos;
                
                dgvProyectos.Rows.Add(padre.proyectos[i].codigo, padre.proyectos[i].nombre, estudiantes,director,eva1,eva2);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog soporte = new OpenFileDialog();
            soporte.Filter = "Archivos PDF (*.pdf)|*.pdf|Archivos DOCX (*.docx)|*.docx|Archivos DOC (*.doc)|*.doc";

            if (soporte.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = soporte.FileName;
            }
        }
    }
}
