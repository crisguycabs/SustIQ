namespace SustIQ
{
    partial class SustentacionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SustentacionForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMax = new System.Windows.Forms.Label();
            this.checkListSalones = new System.Windows.Forms.CheckedListBox();
            this.groupTarde = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboIniTarde = new System.Windows.Forms.ComboBox();
            this.comboFinTarde = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTarde = new System.Windows.Forms.CheckBox();
            this.groupMañana = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboIniMañana = new System.Windows.Forms.ComboBox();
            this.comboFinMañana = new System.Windows.Forms.ComboBox();
            this.chkMañana = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupTarde.SuspendLayout();
            this.groupMañana.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSave.Location = new System.Drawing.Point(229, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Proyectos de Grado";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnClose.Location = new System.Drawing.Point(326, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.ForeColor = System.Drawing.Color.Red;
            this.lblMax.Location = new System.Drawing.Point(12, 304);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(168, 15);
            this.lblMax.TabIndex = 7;
            this.lblMax.Text = "Sustentaciones disponibles: --";
            // 
            // checkListSalones
            // 
            this.checkListSalones.FormattingEnabled = true;
            this.checkListSalones.Location = new System.Drawing.Point(15, 180);
            this.checkListSalones.Name = "checkListSalones";
            this.checkListSalones.Size = new System.Drawing.Size(188, 112);
            this.checkListSalones.TabIndex = 5;
            this.checkListSalones.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListSalones_ItemCheck);
            // 
            // groupTarde
            // 
            this.groupTarde.Controls.Add(this.label3);
            this.groupTarde.Controls.Add(this.comboIniTarde);
            this.groupTarde.Controls.Add(this.comboFinTarde);
            this.groupTarde.Controls.Add(this.label2);
            this.groupTarde.Location = new System.Drawing.Point(220, 85);
            this.groupTarde.Name = "groupTarde";
            this.groupTarde.Size = new System.Drawing.Size(188, 78);
            this.groupTarde.TabIndex = 4;
            this.groupTarde.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hora de fin:";
            // 
            // comboIniTarde
            // 
            this.comboIniTarde.FormattingEnabled = true;
            this.comboIniTarde.Items.AddRange(new object[] {
            "14:00 pm",
            "14:30 pm",
            "15:00 pm",
            "15:30 pm",
            "16:00 pm",
            "16:30 pm",
            "17:00 pm",
            "17:30 pm",
            "18:00 pm",
            "18:30 pm",
            "19:00 pm"});
            this.comboIniTarde.Location = new System.Drawing.Point(100, 15);
            this.comboIniTarde.Name = "comboIniTarde";
            this.comboIniTarde.Size = new System.Drawing.Size(80, 23);
            this.comboIniTarde.TabIndex = 0;
            this.comboIniTarde.SelectedIndexChanged += new System.EventHandler(this.comboIniTarde_SelectedIndexChanged);
            // 
            // comboFinTarde
            // 
            this.comboFinTarde.FormattingEnabled = true;
            this.comboFinTarde.Items.AddRange(new object[] {
            "14:00 pm",
            "14:30 pm",
            "15:00 pm",
            "15:30 pm",
            "16:00 pm",
            "16:30 pm",
            "17:00 pm",
            "17:30 pm",
            "18:00 pm",
            "18:30 pm",
            "19:00 pm"});
            this.comboFinTarde.Location = new System.Drawing.Point(100, 45);
            this.comboFinTarde.Name = "comboFinTarde";
            this.comboFinTarde.Size = new System.Drawing.Size(80, 23);
            this.comboFinTarde.TabIndex = 1;
            this.comboFinTarde.SelectedIndexChanged += new System.EventHandler(this.comboFinTarde_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hora de inicio:";
            // 
            // chkTarde
            // 
            this.chkTarde.AutoSize = true;
            this.chkTarde.Checked = true;
            this.chkTarde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTarde.Location = new System.Drawing.Point(220, 69);
            this.chkTarde.Name = "chkTarde";
            this.chkTarde.Size = new System.Drawing.Size(132, 19);
            this.chkTarde.TabIndex = 3;
            this.chkTarde.Text = "Jornada de la tarde";
            this.chkTarde.UseVisualStyleBackColor = true;
            this.chkTarde.CheckedChanged += new System.EventHandler(this.chkTarde_CheckedChanged);
            // 
            // groupMañana
            // 
            this.groupMañana.Controls.Add(this.label4);
            this.groupMañana.Controls.Add(this.label5);
            this.groupMañana.Controls.Add(this.comboIniMañana);
            this.groupMañana.Controls.Add(this.comboFinMañana);
            this.groupMañana.Location = new System.Drawing.Point(15, 85);
            this.groupMañana.Name = "groupMañana";
            this.groupMañana.Size = new System.Drawing.Size(188, 78);
            this.groupMañana.TabIndex = 2;
            this.groupMañana.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hora de fin:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hora de inicio:";
            // 
            // comboIniMañana
            // 
            this.comboIniMañana.FormattingEnabled = true;
            this.comboIniMañana.Items.AddRange(new object[] {
            "6:00 am",
            "6:30 am",
            "7:00 am",
            "7:30 am",
            "8:00 am",
            "8:30 am",
            "9:00 am",
            "9:30 am",
            "10:00 am",
            "10:30 am",
            "11:00 am",
            "11:30 am",
            "12:00 m",
            "12:30 pm",
            "13:00 pm"});
            this.comboIniMañana.Location = new System.Drawing.Point(100, 14);
            this.comboIniMañana.Name = "comboIniMañana";
            this.comboIniMañana.Size = new System.Drawing.Size(80, 23);
            this.comboIniMañana.TabIndex = 0;
            this.comboIniMañana.SelectedIndexChanged += new System.EventHandler(this.comboIniMañana_SelectedIndexChanged);
            // 
            // comboFinMañana
            // 
            this.comboFinMañana.FormattingEnabled = true;
            this.comboFinMañana.Items.AddRange(new object[] {
            "6:00 am",
            "6:30 am",
            "7:00 am",
            "7:30 am",
            "8:00 am",
            "8:30 am",
            "9:00 am",
            "9:30 am",
            "10:00 am",
            "10:30 am",
            "11:00 am",
            "11:30 am",
            "12:00 m",
            "12:30 pm",
            "13:00 pm"});
            this.comboFinMañana.Location = new System.Drawing.Point(100, 46);
            this.comboFinMañana.Name = "comboFinMañana";
            this.comboFinMañana.Size = new System.Drawing.Size(80, 23);
            this.comboFinMañana.TabIndex = 1;
            this.comboFinMañana.SelectedIndexChanged += new System.EventHandler(this.comboFinMañana_SelectedIndexChanged);
            // 
            // chkMañana
            // 
            this.chkMañana.AutoSize = true;
            this.chkMañana.Checked = true;
            this.chkMañana.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMañana.Location = new System.Drawing.Point(15, 69);
            this.chkMañana.Name = "chkMañana";
            this.chkMañana.Size = new System.Drawing.Size(148, 19);
            this.chkMañana.TabIndex = 1;
            this.chkMañana.Text = "Jornada de la mañana";
            this.chkMañana.UseVisualStyleBackColor = true;
            this.chkMañana.CheckedChanged += new System.EventHandler(this.chkMañana_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha de las sustentaciones:";
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(13, 30);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(223, 23);
            this.dateFecha.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 10F);
            this.button1.Location = new System.Drawing.Point(229, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Horario de Sustentaciones";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 10F);
            this.button2.Location = new System.Drawing.Point(238, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // SustentacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(414, 358);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkListSalones);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupTarde);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.chkTarde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupMañana);
            this.Controls.Add(this.chkMañana);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SustentacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ORGANIZACION DE LAS JORNADAS DE SUSTENTACIONES";
            this.Load += new System.EventHandler(this.SustentacionForm_Load);
            this.groupTarde.ResumeLayout(false);
            this.groupTarde.PerformLayout();
            this.groupMañana.ResumeLayout(false);
            this.groupMañana.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupTarde;
        private System.Windows.Forms.CheckBox chkTarde;
        private System.Windows.Forms.GroupBox groupMañana;
        private System.Windows.Forms.CheckBox chkMañana;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.ComboBox comboFinMañana;
        private System.Windows.Forms.ComboBox comboIniMañana;
        private System.Windows.Forms.ComboBox comboFinTarde;
        private System.Windows.Forms.ComboBox comboIniTarde;
        private System.Windows.Forms.CheckedListBox checkListSalones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}