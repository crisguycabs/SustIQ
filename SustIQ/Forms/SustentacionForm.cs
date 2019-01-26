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
    public partial class SustentacionForm : Form
    {
        public Main padre = null;

        public SustentacionForm()
        {
            InitializeComponent();
        }

        private void chkMañana_CheckedChanged(object sender, EventArgs e)
        {
            groupMañana.Enabled = chkMañana.Checked;
            GetMaxSustentaciones();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.CerrarSustentacionForm();
            this.Close();
        }

        private void chkTarde_CheckedChanged(object sender, EventArgs e)
        {
            groupTarde.Enabled = chkTarde.Checked;
            GetMaxSustentaciones();
        }

        private void SustentacionForm_Load(object sender, EventArgs e)
        {
            comboFinMañana.SelectedIndex = 14;
            comboIniMañana.SelectedIndex = 0;

            comboFinTarde.SelectedIndex = 10;
            comboIniTarde.SelectedIndex = 0;

            LlenarSalones();
        }

        /// <summary>
        /// Se llena la lista de salones con los salones en memoria
        /// </summary>
        public void LlenarSalones()
        {
            checkListSalones.Items.Clear();
            for (int i = 0; i < padre.salones.Count; i++)
            {
                checkListSalones.Items.Add(Convert.ToString(padre.salones[i].edificio + " - " + padre.salones[i].nombre));
            }
        }

        private void comboIniMañana_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verificacion de seguridad
            if (comboIniMañana.SelectedIndex >= comboFinMañana.SelectedIndex)
            {
                MessageBox.Show("Hora de inicio no permitida para la jornada de la mañana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboIniMañana.SelectedIndex = 0;
            }

            GetMaxSustentaciones();
        }

        public void GetMaxSustentaciones()
        {
            int max = 0;
            
            int mañana = 1;
            if (!chkMañana.Checked) mañana = 0;

            int tarde = 1;
            if (!chkTarde.Checked) tarde = 0;

            max = ((comboFinMañana.SelectedIndex - comboIniMañana.SelectedIndex)*mañana + (comboFinTarde.SelectedIndex - comboIniTarde.SelectedIndex)*tarde) * checkListSalones.CheckedIndices.Count;
            lblMax.Text = "Sustentaciones disponibles: " + Convert.ToString(max);
        }

        private void comboFinMañana_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verificacion de seguridad
            if (comboIniMañana.SelectedIndex >= comboFinMañana.SelectedIndex)
            {
                MessageBox.Show("Hora de finalización no permitida para la jornada de la mañana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboFinMañana.SelectedIndex = comboFinMañana.Items.Count - 1;
            }

            GetMaxSustentaciones();
        }

        private void comboIniTarde_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verificacion de seguridad
            if (comboIniTarde.SelectedIndex >= comboFinTarde.SelectedIndex)
            {
                MessageBox.Show("Hora de inicio no permitida para la jornada de la tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboIniTarde.SelectedIndex = 0;
            }

            GetMaxSustentaciones();
        }

        private void comboFinTarde_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verificacion de seguridad
            if (comboIniTarde.SelectedIndex >= comboFinTarde.SelectedIndex)
            {
                MessageBox.Show("Hora de finalización no permitida para la jornada de la tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboFinTarde.SelectedIndex = comboFinTarde.Items.Count - 1;
            }

            GetMaxSustentaciones();
        }

        /// <summary>
        /// Se agregan salones a la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSalon_Click(object sender, EventArgs e)
        {
            // primero se guarda el estado de chequeo de los salones
            List<bool> estadoSalones = new List<bool>();
            for (int i = 0; i < checkListSalones.Items.Count; i++) estadoSalones.Add(checkListSalones.GetItemChecked(i));

            padre.AbrirAddSalonesForm(true, -1);

            LlenarSalones();
            for (int i = 0; i < estadoSalones.Count; i++) checkListSalones.SetItemChecked(i, estadoSalones[i]);
        }

        private void checkListSalones_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(GetMaxSustentaciones), null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            padre.AbrirProyectosForm();
        }
    }
}
