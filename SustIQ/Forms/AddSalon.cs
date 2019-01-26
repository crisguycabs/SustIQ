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
    public partial class AddSalon : Form
    {
        /// <summary>
        /// Referencia al form padre
        /// </summary>
        public Main padre = null;

        /// <summary>
        /// Indica el modo de la forma. True: modo agregar; False: modo modificar
        /// </summary>
        public bool modo;

        public int iSalonMod = -1;

        public AddSalon()
        {
            InitializeComponent();
        }

        private void AddSalon_Load(object sender, EventArgs e)
        {
            if (modo)
            {
                // modo agregar

                this.Text = "AGREGAR SALON";
                btnAdd.Text = "Agregar";

                txtEdificio.Clear();                
                txtNombre.Clear();
            }
            else
            {
                // modo modificar
                this.Text = "MODIFICAR SALON";
                btnAdd.Text = "Modificar";

                txtNombre.Text = padre.salones[iSalonMod].nombre;
                txtEdificio.Text = padre.salones[iSalonMod].edificio;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.CerrarAddSalonesForm();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // verificaciones de seguridad
            bool aceptado = true;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Nombre incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                aceptado = false;
            }
            if (string.IsNullOrWhiteSpace(txtEdificio.Text))
            {
                MessageBox.Show("Edificio incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEdificio.Focus();
                aceptado = false;
            }
            
            if (aceptado)
            {
                if (modo)
                {
                    // modo agregar
                    padre.salones.Add(new CSalon(txtNombre.Text,txtEdificio.Text));
                }
                else
                {
                    // modo modificar
                    padre.salones[iSalonMod].nombre = txtNombre.Text;
                    padre.salones[iSalonMod].edificio = txtEdificio.Text;                    
                }

                padre.CerrarAddSalonesForm();
                this.Close();
            }
        }
    }
}
