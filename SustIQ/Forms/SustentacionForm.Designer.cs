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
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboIniMañana = new System.Windows.Forms.ComboBox();
            this.groupMañana = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboFinMañana = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupTarde = new System.Windows.Forms.GroupBox();
            this.comboFinTarde = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboIniTarde = new System.Windows.Forms.ComboBox();
            this.checkMañana = new System.Windows.Forms.CheckBox();
            this.checkTarde = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.checkSalones = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOrganizar = new System.Windows.Forms.Button();
            this.txtMax = new System.Windows.Forms.Label();
            this.btnAddSalon = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSust = new System.Windows.Forms.Label();
            this.groupMañana.SuspendLayout();
            this.groupTarde.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(90, 15);
            this.dateFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(250, 23);
            this.dateFecha.TabIndex = 0;
            this.dateFecha.ValueChanged += new System.EventHandler(this.dateFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha: ";
            // 
            // comboIniMañana
            // 
            this.comboIniMañana.FormattingEnabled = true;
            this.comboIniMañana.Items.AddRange(new object[] {
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
            "12:00 am"});
            this.comboIniMañana.Location = new System.Drawing.Point(136, 16);
            this.comboIniMañana.Margin = new System.Windows.Forms.Padding(4);
            this.comboIniMañana.Name = "comboIniMañana";
            this.comboIniMañana.Size = new System.Drawing.Size(112, 23);
            this.comboIniMañana.TabIndex = 2;
            this.comboIniMañana.SelectedIndexChanged += new System.EventHandler(this.comboIniMañana_SelectedIndexChanged);
            // 
            // groupMañana
            // 
            this.groupMañana.Controls.Add(this.label3);
            this.groupMañana.Controls.Add(this.comboFinMañana);
            this.groupMañana.Controls.Add(this.label2);
            this.groupMañana.Controls.Add(this.comboIniMañana);
            this.groupMañana.Location = new System.Drawing.Point(15, 71);
            this.groupMañana.Margin = new System.Windows.Forms.Padding(4);
            this.groupMañana.Name = "groupMañana";
            this.groupMañana.Padding = new System.Windows.Forms.Padding(4);
            this.groupMañana.Size = new System.Drawing.Size(255, 77);
            this.groupMañana.TabIndex = 3;
            this.groupMañana.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hora de Finalizacion:";
            // 
            // comboFinMañana
            // 
            this.comboFinMañana.FormattingEnabled = true;
            this.comboFinMañana.Items.AddRange(new object[] {
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
            "12:00 am"});
            this.comboFinMañana.Location = new System.Drawing.Point(136, 45);
            this.comboFinMañana.Margin = new System.Windows.Forms.Padding(4);
            this.comboFinMañana.Name = "comboFinMañana";
            this.comboFinMañana.Size = new System.Drawing.Size(112, 23);
            this.comboFinMañana.TabIndex = 5;
            this.comboFinMañana.SelectedIndexChanged += new System.EventHandler(this.comboFinMañana_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hora de Inicio:";
            // 
            // groupTarde
            // 
            this.groupTarde.Controls.Add(this.comboFinTarde);
            this.groupTarde.Controls.Add(this.label4);
            this.groupTarde.Controls.Add(this.label5);
            this.groupTarde.Controls.Add(this.comboIniTarde);
            this.groupTarde.Location = new System.Drawing.Point(281, 71);
            this.groupTarde.Margin = new System.Windows.Forms.Padding(4);
            this.groupTarde.Name = "groupTarde";
            this.groupTarde.Padding = new System.Windows.Forms.Padding(4);
            this.groupTarde.Size = new System.Drawing.Size(255, 77);
            this.groupTarde.TabIndex = 7;
            this.groupTarde.TabStop = false;
            // 
            // comboFinTarde
            // 
            this.comboFinTarde.FormattingEnabled = true;
            this.comboFinTarde.Items.AddRange(new object[] {
            "1:00 pm",
            "1:30 pm",
            "2:00 pm",
            "2:30 pm",
            "3:00 pm",
            "3:30 pm",
            "4:00 pm",
            "4:30 pm",
            "5:00 pm",
            "5:30 pm",
            "6:00 pm",
            "6:30 pm",
            "7:00 pm"});
            this.comboFinTarde.Location = new System.Drawing.Point(136, 45);
            this.comboFinTarde.Margin = new System.Windows.Forms.Padding(4);
            this.comboFinTarde.Name = "comboFinTarde";
            this.comboFinTarde.Size = new System.Drawing.Size(112, 23);
            this.comboFinTarde.TabIndex = 7;
            this.comboFinTarde.SelectedIndexChanged += new System.EventHandler(this.comboFinTarde_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hora de Finalizacion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hora de Inicio:";
            // 
            // comboIniTarde
            // 
            this.comboIniTarde.FormattingEnabled = true;
            this.comboIniTarde.Items.AddRange(new object[] {
            "1:00 pm",
            "1:30 pm",
            "2:00 pm",
            "2:30 pm",
            "3:00 pm",
            "3:30 pm",
            "4:00 pm",
            "4:30 pm",
            "5:00 pm",
            "5:30 pm",
            "6:00 pm",
            "6:30 pm",
            "7:00 pm"});
            this.comboIniTarde.Location = new System.Drawing.Point(136, 16);
            this.comboIniTarde.Margin = new System.Windows.Forms.Padding(4);
            this.comboIniTarde.Name = "comboIniTarde";
            this.comboIniTarde.Size = new System.Drawing.Size(112, 23);
            this.comboIniTarde.TabIndex = 2;
            this.comboIniTarde.SelectedIndexChanged += new System.EventHandler(this.comboIniTarde_SelectedIndexChanged);
            // 
            // checkMañana
            // 
            this.checkMañana.AutoSize = true;
            this.checkMañana.Checked = true;
            this.checkMañana.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMañana.Location = new System.Drawing.Point(16, 52);
            this.checkMañana.Margin = new System.Windows.Forms.Padding(4);
            this.checkMañana.Name = "checkMañana";
            this.checkMañana.Size = new System.Drawing.Size(149, 19);
            this.checkMañana.TabIndex = 8;
            this.checkMañana.Text = "Jornada de la Mañana";
            this.checkMañana.UseVisualStyleBackColor = true;
            this.checkMañana.CheckedChanged += new System.EventHandler(this.checkMañana_CheckedChanged);
            // 
            // checkTarde
            // 
            this.checkTarde.AutoSize = true;
            this.checkTarde.Checked = true;
            this.checkTarde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTarde.Location = new System.Drawing.Point(283, 49);
            this.checkTarde.Margin = new System.Windows.Forms.Padding(4);
            this.checkTarde.Name = "checkTarde";
            this.checkTarde.Size = new System.Drawing.Size(133, 19);
            this.checkTarde.TabIndex = 8;
            this.checkTarde.Text = "Jornada de la Tarde";
            this.checkTarde.UseVisualStyleBackColor = true;
            this.checkTarde.CheckedChanged += new System.EventHandler(this.checkTarde_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnClose.Location = new System.Drawing.Point(413, 329);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 31);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkSalones
            // 
            this.checkSalones.CheckOnClick = true;
            this.checkSalones.FormattingEnabled = true;
            this.checkSalones.Location = new System.Drawing.Point(15, 184);
            this.checkSalones.Margin = new System.Windows.Forms.Padding(4);
            this.checkSalones.Name = "checkSalones";
            this.checkSalones.Size = new System.Drawing.Size(248, 130);
            this.checkSalones.TabIndex = 11;
            this.checkSalones.SelectedIndexChanged += new System.EventHandler(this.checkSalones_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Salones:";
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
            this.button1.Location = new System.Drawing.Point(301, 240);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "Proyectos de Grado";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOrganizar
            // 
            this.btnOrganizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrganizar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrganizar.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnOrganizar.FlatAppearance.BorderSize = 2;
            this.btnOrganizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOrganizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnOrganizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganizar.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnOrganizar.Location = new System.Drawing.Point(301, 280);
            this.btnOrganizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrganizar.Name = "btnOrganizar";
            this.btnOrganizar.Size = new System.Drawing.Size(214, 31);
            this.btnOrganizar.TabIndex = 14;
            this.btnOrganizar.Text = "Organización de Sustentaciones";
            this.btnOrganizar.UseVisualStyleBackColor = false;
            this.btnOrganizar.Click += new System.EventHandler(this.btnOrganizar_Click);
            // 
            // txtMax
            // 
            this.txtMax.AutoSize = true;
            this.txtMax.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.ForeColor = System.Drawing.Color.Red;
            this.txtMax.Location = new System.Drawing.Point(15, 342);
            this.txtMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(114, 15);
            this.txtMax.TabIndex = 15;
            this.txtMax.Text = "Capacidad maxima: ";
            // 
            // btnAddSalon
            // 
            this.btnAddSalon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddSalon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSalon.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnAddSalon.FlatAppearance.BorderSize = 2;
            this.btnAddSalon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddSalon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnAddSalon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSalon.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAddSalon.Location = new System.Drawing.Point(301, 200);
            this.btnAddSalon.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSalon.Name = "btnAddSalon";
            this.btnAddSalon.Size = new System.Drawing.Size(214, 31);
            this.btnAddSalon.TabIndex = 16;
            this.btnAddSalon.Text = "Agregar Salones";
            this.btnAddSalon.UseVisualStyleBackColor = false;
            this.btnAddSalon.Click += new System.EventHandler(this.btnAddSalon_Click);
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
            this.btnSave.Location = new System.Drawing.Point(301, 329);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 31);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSust
            // 
            this.lblSust.AutoSize = true;
            this.lblSust.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSust.ForeColor = System.Drawing.Color.Red;
            this.lblSust.Location = new System.Drawing.Point(15, 321);
            this.lblSust.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSust.Name = "lblSust";
            this.lblSust.Size = new System.Drawing.Size(118, 15);
            this.lblSust.TabIndex = 17;
            this.lblSust.Text = "Proyectos cargados: ";
            // 
            // SustentacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(541, 368);
            this.ControlBox = false;
            this.Controls.Add(this.lblSust);
            this.Controls.Add(this.btnAddSalon);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.btnOrganizar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkSalones);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.checkTarde);
            this.Controls.Add(this.checkMañana);
            this.Controls.Add(this.groupTarde);
            this.Controls.Add(this.groupMañana);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFecha);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SustentacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLANEACION DE SUSTENTACION";
            this.Load += new System.EventHandler(this.SustentacionForm_Load);
            this.groupMañana.ResumeLayout(false);
            this.groupMañana.PerformLayout();
            this.groupTarde.ResumeLayout(false);
            this.groupTarde.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboIniMañana;
        private System.Windows.Forms.GroupBox groupMañana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFinMañana;
        private System.Windows.Forms.GroupBox groupTarde;
        private System.Windows.Forms.ComboBox comboFinTarde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboIniTarde;
        private System.Windows.Forms.CheckBox checkMañana;
        private System.Windows.Forms.CheckBox checkTarde;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckedListBox checkSalones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOrganizar;
        private System.Windows.Forms.Label txtMax;
        private System.Windows.Forms.Button btnAddSalon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSust;
    }
}