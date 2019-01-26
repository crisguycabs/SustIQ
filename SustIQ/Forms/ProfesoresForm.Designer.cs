namespace SustIQ
{
    partial class FormProfesores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfesores));
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvProf = new System.Windows.Forms.DataGridView();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDispMañana = new System.Windows.Forms.DataGridView();
            this.dgvDispTarde = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispMañana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispTarde)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnClose.Location = new System.Drawing.Point(771, 521);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvProf
            // 
            this.dgvProf.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombres,
            this.apellidos,
            this.correo,
            this.planta});
            this.dgvProf.Location = new System.Drawing.Point(12, 12);
            this.dgvProf.MultiSelect = false;
            this.dgvProf.Name = "dgvProf";
            this.dgvProf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProf.Size = new System.Drawing.Size(643, 500);
            this.dgvProf.TabIndex = 1;
            this.dgvProf.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProf_CellContentClick);
            this.dgvProf.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProf_CellValueChanged);
            this.dgvProf.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProf_RowsAdded);
            this.dgvProf.SelectionChanged += new System.EventHandler(this.dgvProf_SelectionChanged);
            // 
            // nombres
            // 
            this.nombres.HeaderText = "Nombres";
            this.nombres.Name = "nombres";
            this.nombres.Width = 110;
            // 
            // apellidos
            // 
            this.apellidos.HeaderText = "Apellidos";
            this.apellidos.Name = "apellidos";
            this.apellidos.Width = 150;
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            this.correo.Width = 250;
            // 
            // planta
            // 
            this.planta.HeaderText = "Planta IQ";
            this.planta.Name = "planta";
            this.planta.Width = 70;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnDelete.Location = new System.Drawing.Point(682, 521);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 28);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDispMañana
            // 
            this.dgvDispMañana.AllowUserToAddRows = false;
            this.dgvDispMañana.AllowUserToDeleteRows = false;
            this.dgvDispMañana.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDispMañana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispMañana.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hora,
            this.lunes,
            this.viernes});
            this.dgvDispMañana.Location = new System.Drawing.Point(666, 34);
            this.dgvDispMañana.Name = "dgvDispMañana";
            this.dgvDispMañana.ReadOnly = true;
            this.dgvDispMañana.Size = new System.Drawing.Size(186, 250);
            this.dgvDispMañana.TabIndex = 6;
            this.dgvDispMañana.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispMañana_CellDoubleClick);
            this.dgvDispMañana.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDispMañana_CellFormatting);
            // 
            // dgvDispTarde
            // 
            this.dgvDispTarde.AllowUserToAddRows = false;
            this.dgvDispTarde.AllowUserToDeleteRows = false;
            this.dgvDispTarde.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDispTarde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispTarde.ColumnHeadersVisible = false;
            this.dgvDispTarde.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvDispTarde.Location = new System.Drawing.Point(666, 309);
            this.dgvDispTarde.Name = "dgvDispTarde";
            this.dgvDispTarde.ReadOnly = true;
            this.dgvDispTarde.Size = new System.Drawing.Size(186, 203);
            this.dgvDispTarde.TabIndex = 8;
            this.dgvDispTarde.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispTarde_CellDoubleClick);
            this.dgvDispTarde.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDispTarde_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Disponibilidad Mañana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Disponibilidad Tarde";
            // 
            // hora
            // 
            this.hora.HeaderText = "Hora";
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            this.hora.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.hora.Width = 70;
            // 
            // lunes
            // 
            this.lunes.HeaderText = "Lun";
            this.lunes.Name = "lunes";
            this.lunes.ReadOnly = true;
            this.lunes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lunes.Width = 35;
            // 
            // viernes
            // 
            this.viernes.HeaderText = "Vie";
            this.viernes.Name = "viernes";
            this.viernes.ReadOnly = true;
            this.viernes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.viernes.Width = 35;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Hora";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Lun";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 35;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Vie";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 35;
            // 
            // FormProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(860, 557);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDispTarde);
            this.Controls.Add(this.dgvDispMañana);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvProf);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProfesores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROFESORES";
            this.Load += new System.EventHandler(this.FormProfesores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispMañana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispTarde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvProf;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDispMañana;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn planta;
        private System.Windows.Forms.DataGridView dgvDispTarde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn viernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;


    }
}