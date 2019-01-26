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
    public partial class AddProfesoresForm : Form
    {
        /// <summary>
        /// Modo de operacion. True: agregar, False: modificar
        /// </summary>
        public bool modo = true;

        /// <summary>
        /// Referencia al padre
        /// </summary>
        public Main padre = null;

        public int iProfeMod = -1;

        public AddProfesoresForm()
        {
            InitializeComponent();
        }

        private void AddProfesoresForm_Load(object sender, EventArgs e)
        {
            if (modo)
            {
                // modo agregar

                this.Text = "AGREGAR PROFESOR";
                btnAdd.Text = "Agregar";

                txtApellidos.Clear();
                txtCorreo.Clear();
                txtNombres.Clear();
            }
            else
            {
                // modo modificar
                this.Text = "MODIFICAR PROFESOR";
                btnAdd.Text = "Modificar";

                txtNombres.Text = padre.profesores[iProfeMod].nombres;
                txtApellidos.Text = padre.profesores[iProfeMod].apellidos;
                txtCorreo.Text = padre.profesores[iProfeMod].correo;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.CerrarAddProfesoresForm();
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // verificaciones de seguridad
            bool aceptado = true;

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Nombres incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombres.Focus();
                aceptado = false;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Apellidos incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Focus();
                aceptado = false;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Correo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                aceptado = false;
            }
            else if (!Main.ValidarEmail(txtCorreo.Text))
            {
                MessageBox.Show("Correo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                aceptado = false;
            }

            if (aceptado)
            {
                if (modo)
                {
                    // modo agregar
                    padre.profesores.Add(new CProfesor(txtNombres.Text, txtApellidos.Text, txtCorreo.Text));
                }
                else
                {
                    // modo modificar
                    padre.profesores[iProfeMod].nombres = txtNombres.Text;
                    padre.profesores[iProfeMod].apellidos = txtApellidos.Text;
                    padre.profesores[iProfeMod].correo = txtCorreo.Text;
                }

                padre.CerrarAddProfesoresForm();
                this.Close();
            }
        }
    }
}
