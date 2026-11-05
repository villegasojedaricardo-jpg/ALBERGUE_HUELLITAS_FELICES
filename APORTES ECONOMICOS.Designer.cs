namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class APORTES_ECONOMICOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APORTES_ECONOMICOS));
            cmbDonanteAportesEconomicos = new ComboBox();
            txtMontoAportesEconomicos = new TextBox();
            btnGuardarAportesEconomicos = new Button();
            btnVolverAportesEconomicos = new Button();
            dgvAportesEconomicos = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAportesEconomicos).BeginInit();
            SuspendLayout();
            // 
            // cmbDonanteAportesEconomicos
            // 
            cmbDonanteAportesEconomicos.FormattingEnabled = true;
            cmbDonanteAportesEconomicos.Location = new Point(197, 446);
            cmbDonanteAportesEconomicos.Margin = new Padding(5, 5, 5, 5);
            cmbDonanteAportesEconomicos.Name = "cmbDonanteAportesEconomicos";
            cmbDonanteAportesEconomicos.Size = new Size(825, 49);
            cmbDonanteAportesEconomicos.TabIndex = 0;
            // 
            // txtMontoAportesEconomicos
            // 
            txtMontoAportesEconomicos.Location = new Point(1209, 444);
            txtMontoAportesEconomicos.Margin = new Padding(5, 5, 5, 5);
            txtMontoAportesEconomicos.Name = "txtMontoAportesEconomicos";
            txtMontoAportesEconomicos.Size = new Size(550, 47);
            txtMontoAportesEconomicos.TabIndex = 1;
            // 
            // btnGuardarAportesEconomicos
            // 
            btnGuardarAportesEconomicos.BackColor = Color.Transparent;
            btnGuardarAportesEconomicos.FlatAppearance.BorderSize = 0;
            btnGuardarAportesEconomicos.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarAportesEconomicos.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarAportesEconomicos.FlatStyle = FlatStyle.Flat;
            btnGuardarAportesEconomicos.Location = new Point(107, 553);
            btnGuardarAportesEconomicos.Margin = new Padding(5, 5, 5, 5);
            btnGuardarAportesEconomicos.Name = "btnGuardarAportesEconomicos";
            btnGuardarAportesEconomicos.Size = new Size(439, 71);
            btnGuardarAportesEconomicos.TabIndex = 2;
            btnGuardarAportesEconomicos.Text = ".";
            btnGuardarAportesEconomicos.UseVisualStyleBackColor = false;
            btnGuardarAportesEconomicos.Click += btnGuardarAportesEconomicos_Click;
            // 
            // btnVolverAportesEconomicos
            // 
            btnVolverAportesEconomicos.BackColor = Color.Transparent;
            btnVolverAportesEconomicos.FlatAppearance.BorderSize = 0;
            btnVolverAportesEconomicos.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverAportesEconomicos.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverAportesEconomicos.FlatStyle = FlatStyle.Flat;
            btnVolverAportesEconomicos.Location = new Point(1844, 271);
            btnVolverAportesEconomicos.Margin = new Padding(5, 5, 5, 5);
            btnVolverAportesEconomicos.Name = "btnVolverAportesEconomicos";
            btnVolverAportesEconomicos.Size = new Size(286, 56);
            btnVolverAportesEconomicos.TabIndex = 3;
            btnVolverAportesEconomicos.Text = ".";
            btnVolverAportesEconomicos.UseVisualStyleBackColor = false;
            btnVolverAportesEconomicos.Click += btnVolverAportesEconomicos_Click;
            // 
            // dgvAportesEconomicos
            // 
            dgvAportesEconomicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAportesEconomicos.Location = new Point(71, 854);
            dgvAportesEconomicos.Margin = new Padding(5, 5, 5, 5);
            dgvAportesEconomicos.Name = "dgvAportesEconomicos";
            dgvAportesEconomicos.RowHeadersWidth = 62;
            dgvAportesEconomicos.Size = new Size(2135, 271);
            dgvAportesEconomicos.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(1194, 305);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 5;
            button1.Text = "ReporteAportesEconomicos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // APORTES_ECONOMICOS
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(2275, 1243);
            Controls.Add(button1);
            Controls.Add(dgvAportesEconomicos);
            Controls.Add(btnVolverAportesEconomicos);
            Controls.Add(btnGuardarAportesEconomicos);
            Controls.Add(txtMontoAportesEconomicos);
            Controls.Add(cmbDonanteAportesEconomicos);
            Margin = new Padding(5, 5, 5, 5);
            Name = "APORTES_ECONOMICOS";
            Text = "APORTES_ECONOMICOS";
            Load += APORTES_ECONOMICOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAportesEconomicos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDonanteAportesEconomicos;
        private TextBox txtMontoAportesEconomicos;
        private Button btnGuardarAportesEconomicos;
        private Button btnVolverAportesEconomicos;
        private DataGridView dgvAportesEconomicos;
        private Button button1;
    }
}