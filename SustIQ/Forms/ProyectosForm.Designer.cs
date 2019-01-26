namespace SustIQ
{
    partial class s
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(s));
            this.dgvProyectos = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnSoporte = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSoporte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreProy = new System.Windows.Forms.TextBox();
            this.txtCodProy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreEst1 = new System.Windows.Forms.TextBox();
            this.txtMailEst1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreEst2 = new System.Windows.Forms.TextBox();
            this.txtMailEst2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboDirector = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddProf = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboEval2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboEval1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudiantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.director = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eval1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eval2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProyectos
            // 
            this.dgvProyectos.AllowUserToAddRows = false;
            this.dgvProyectos.AllowUserToDeleteRows = false;
            this.dgvProyectos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProyectos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.codigo,
            this.nombre,
            this.estudiantes,
            this.director,
            this.eval1,
            this.eval2,
            this.incluir});
            this.dgvProyectos.Location = new System.Drawing.Point(12, 12);
            this.dgvProyectos.MultiSelect = false;
            this.dgvProyectos.Name = "dgvProyectos";
            this.dgvProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProyectos.Size = new System.Drawing.Size(1396, 383);
            this.dgvProyectos.TabIndex = 0;
            this.dgvProyectos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProyectos_CellContentClick);
            this.dgvProyectos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProyectos_CellDoubleClick);
            this.dgvProyectos.SelectionChanged += new System.EventHandler(this.dgvProyectos_SelectionChanged);
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
            this.btnClose.Location = new System.Drawing.Point(1287, 548);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 31);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVer);
            this.groupBox1.Controls.Add(this.btnSoporte);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtSoporte);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombreProy);
            this.groupBox1.Controls.Add(this.txtCodProy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 183);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PROYECTO";
            // 
            // btnVer
            // 
            this.btnVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVer.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnVer.FlatAppearance.BorderSize = 2;
            this.btnVer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnVer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnVer.Location = new System.Drawing.Point(486, 142);
            this.btnVer.Margin = new System.Windows.Forms.Padding(4);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(102, 31);
            this.btnVer.TabIndex = 18;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnSoporte
            // 
            this.btnSoporte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSoporte.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSoporte.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnSoporte.FlatAppearance.BorderSize = 2;
            this.btnSoporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSoporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSoporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoporte.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSoporte.Location = new System.Drawing.Point(377, 142);
            this.btnSoporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnSoporte.Name = "btnSoporte";
            this.btnSoporte.Size = new System.Drawing.Size(102, 31);
            this.btnSoporte.TabIndex = 17;
            this.btnSoporte.Text = "Soporte";
            this.btnSoporte.UseVisualStyleBackColor = false;
            this.btnSoporte.Click += new System.EventHandler(this.btnSoporte_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Soporte:";
            // 
            // txtSoporte
            // 
            this.txtSoporte.Location = new System.Drawing.Point(64, 147);
            this.txtSoporte.Name = "txtSoporte";
            this.txtSoporte.ReadOnly = true;
            this.txtSoporte.Size = new System.Drawing.Size(306, 23);
            this.txtSoporte.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            // 
            // txtNombreProy
            // 
            this.txtNombreProy.Location = new System.Drawing.Point(64, 50);
            this.txtNombreProy.Multiline = true;
            this.txtNombreProy.Name = "txtNombreProy";
            this.txtNombreProy.Size = new System.Drawing.Size(524, 87);
            this.txtNombreProy.TabIndex = 3;
            // 
            // txtCodProy
            // 
            this.txtCodProy.Location = new System.Drawing.Point(64, 21);
            this.txtCodProy.Name = "txtCodProy";
            this.txtCodProy.Size = new System.Drawing.Size(136, 23);
            this.txtCodProy.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNombreEst1);
            this.groupBox2.Controls.Add(this.txtMailEst1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(613, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 87);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ESTUDIANTE 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre:";
            // 
            // txtNombreEst1
            // 
            this.txtNombreEst1.Location = new System.Drawing.Point(66, 54);
            this.txtNombreEst1.Name = "txtNombreEst1";
            this.txtNombreEst1.Size = new System.Drawing.Size(202, 23);
            this.txtNombreEst1.TabIndex = 6;
            // 
            // txtMailEst1
            // 
            this.txtMailEst1.Location = new System.Drawing.Point(66, 22);
            this.txtMailEst1.Name = "txtMailEst1";
            this.txtMailEst1.Size = new System.Drawing.Size(202, 23);
            this.txtMailEst1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Correo:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtNombreEst2);
            this.groupBox3.Controls.Add(this.txtMailEst2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(613, 497);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 87);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ESTUDIANTE 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nombre:";
            // 
            // txtNombreEst2
            // 
            this.txtNombreEst2.Location = new System.Drawing.Point(66, 55);
            this.txtNombreEst2.Name = "txtNombreEst2";
            this.txtNombreEst2.Size = new System.Drawing.Size(202, 23);
            this.txtNombreEst2.TabIndex = 9;
            // 
            // txtMailEst2
            // 
            this.txtMailEst2.Location = new System.Drawing.Point(66, 22);
            this.txtMailEst2.Name = "txtMailEst2";
            this.txtMailEst2.Size = new System.Drawing.Size(202, 23);
            this.txtMailEst2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Correo: ";
            // 
            // comboDirector
            // 
            this.comboDirector.FormattingEnabled = true;
            this.comboDirector.Location = new System.Drawing.Point(86, 22);
            this.comboDirector.Name = "comboDirector";
            this.comboDirector.Size = new System.Drawing.Size(216, 23);
            this.comboDirector.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddProf);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.comboEval2);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.comboEval1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.comboDirector);
            this.groupBox4.Location = new System.Drawing.Point(901, 401);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 183);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // btnAddProf
            // 
            this.btnAddProf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddProf.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddProf.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnAddProf.FlatAppearance.BorderSize = 2;
            this.btnAddProf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddProf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnAddProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProf.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAddProf.Location = new System.Drawing.Point(181, 142);
            this.btnAddProf.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProf.Name = "btnAddProf";
            this.btnAddProf.Size = new System.Drawing.Size(123, 31);
            this.btnAddProf.TabIndex = 14;
            this.btnAddProf.Text = "Agregar Profesor";
            this.btnAddProf.UseVisualStyleBackColor = false;
            this.btnAddProf.Click += new System.EventHandler(this.btnAddProf_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Evaluador 2:";
            // 
            // comboEval2
            // 
            this.comboEval2.FormattingEnabled = true;
            this.comboEval2.Location = new System.Drawing.Point(86, 94);
            this.comboEval2.Name = "comboEval2";
            this.comboEval2.Size = new System.Drawing.Size(217, 23);
            this.comboEval2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Evaluador 1:";
            // 
            // comboEval1
            // 
            this.comboEval1.FormattingEnabled = true;
            this.comboEval1.Location = new System.Drawing.Point(86, 58);
            this.comboEval1.Name = "comboEval1";
            this.comboEval1.Size = new System.Drawing.Size(216, 23);
            this.comboEval1.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Director: ";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAdd.Location = new System.Drawing.Point(1287, 474);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 31);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnDelete.Location = new System.Drawing.Point(1287, 511);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 31);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // numero
            // 
            this.numero.HeaderText = "#";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 30;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 70;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 320;
            // 
            // estudiantes
            // 
            this.estudiantes.HeaderText = "Estudiantes";
            this.estudiantes.Name = "estudiantes";
            this.estudiantes.ReadOnly = true;
            this.estudiantes.Width = 250;
            // 
            // director
            // 
            this.director.HeaderText = "Director";
            this.director.Name = "director";
            this.director.ReadOnly = true;
            this.director.Width = 200;
            // 
            // eval1
            // 
            this.eval1.HeaderText = "Evaluador 1";
            this.eval1.Name = "eval1";
            this.eval1.ReadOnly = true;
            this.eval1.Width = 200;
            // 
            // eval2
            // 
            this.eval2.HeaderText = "Evaluador 2";
            this.eval2.Name = "eval2";
            this.eval2.ReadOnly = true;
            this.eval2.Width = 200;
            // 
            // incluir
            // 
            this.incluir.HeaderText = "Incluir";
            this.incluir.Name = "incluir";
            this.incluir.Width = 60;
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1413, 592);
            this.ControlBox = false;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProyectos);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "s";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROYECTOS DE GRADO";
            this.Load += new System.EventHandler(this.ProyectosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProyectos;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombreProy;
        private System.Windows.Forms.TextBox txtCodProy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombreEst1;
        private System.Windows.Forms.TextBox txtMailEst1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreEst2;
        private System.Windows.Forms.TextBox txtMailEst2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboDirector;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboEval2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboEval1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddProf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSoporte;
        private System.Windows.Forms.Button btnSoporte;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudiantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn director;
        private System.Windows.Forms.DataGridViewTextBoxColumn eval1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eval2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn incluir;
    }
}