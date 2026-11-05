namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class TIPO_DE_VACUNA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIPO_DE_VACUNA));
            cmbTipoVacuna = new ComboBox();
            cmbDosisRecomendada = new ComboBox();
            btnGuardarTipoVacunas = new Button();
            btnVolverTipoVacuna = new Button();
            dgvTipoVacuna = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTipoVacuna).BeginInit();
            SuspendLayout();
            // 
            // cmbTipoVacuna
            // 
            cmbTipoVacuna.FormattingEnabled = true;
            cmbTipoVacuna.Items.AddRange(new object[] { "Antirrábica", "Quíntuple canina", "Séxtuple canina", "Parvovirus", "Tos de las perreras", "Triple felina", "Leucemia felina" });
            cmbTipoVacuna.Location = new Point(194, 453);
            cmbTipoVacuna.Margin = new Padding(5, 5, 5, 5);
            cmbTipoVacuna.Name = "cmbTipoVacuna";
            cmbTipoVacuna.Size = new Size(674, 49);
            cmbTipoVacuna.TabIndex = 0;
            // 
            // cmbDosisRecomendada
            // 
            cmbDosisRecomendada.FormattingEnabled = true;
            cmbDosisRecomendada.Items.AddRange(new object[] { "0.5 ml", "1 ml", "2 ml" });
            cmbDosisRecomendada.Location = new Point(1086, 453);
            cmbDosisRecomendada.Margin = new Padding(5, 5, 5, 5);
            cmbDosisRecomendada.Name = "cmbDosisRecomendada";
            cmbDosisRecomendada.Size = new Size(691, 49);
            cmbDosisRecomendada.TabIndex = 1;
            // 
            // btnGuardarTipoVacunas
            // 
            btnGuardarTipoVacunas.BackColor = Color.Transparent;
            btnGuardarTipoVacunas.FlatAppearance.BorderSize = 0;
            btnGuardarTipoVacunas.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarTipoVacunas.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarTipoVacunas.FlatStyle = FlatStyle.Flat;
            btnGuardarTipoVacunas.Location = new Point(99, 563);
            btnGuardarTipoVacunas.Margin = new Padding(5, 5, 5, 5);
            btnGuardarTipoVacunas.Name = "btnGuardarTipoVacunas";
            btnGuardarTipoVacunas.Size = new Size(434, 56);
            btnGuardarTipoVacunas.TabIndex = 2;
            btnGuardarTipoVacunas.Text = ".";
            btnGuardarTipoVacunas.UseVisualStyleBackColor = false;
            btnGuardarTipoVacunas.Click += btnGuardarTipoVacunas_Click;
            // 
            // btnVolverTipoVacuna
            // 
            btnVolverTipoVacuna.BackColor = Color.Transparent;
            btnVolverTipoVacuna.FlatAppearance.BorderSize = 0;
            btnVolverTipoVacuna.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverTipoVacuna.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverTipoVacuna.FlatStyle = FlatStyle.Flat;
            btnVolverTipoVacuna.Location = new Point(1860, 271);
            btnVolverTipoVacuna.Margin = new Padding(5, 5, 5, 5);
            btnVolverTipoVacuna.Name = "btnVolverTipoVacuna";
            btnVolverTipoVacuna.Size = new Size(264, 56);
            btnVolverTipoVacuna.TabIndex = 3;
            btnVolverTipoVacuna.Text = ".";
            btnVolverTipoVacuna.UseVisualStyleBackColor = false;
            btnVolverTipoVacuna.Click += btnVolverTipoVacuna_Click;
            // 
            // dgvTipoVacuna
            // 
            dgvTipoVacuna.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipoVacuna.Location = new Point(66, 854);
            dgvTipoVacuna.Margin = new Padding(5, 5, 5, 5);
            dgvTipoVacuna.Name = "dgvTipoVacuna";
            dgvTipoVacuna.RowHeadersWidth = 62;
            dgvTipoVacuna.Size = new Size(2142, 297);
            dgvTipoVacuna.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(997, 289);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 5;
            button1.Text = "ReporteVacunaciones";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TIPO_DE_VACUNA
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(2275, 1243);
            Controls.Add(button1);
            Controls.Add(dgvTipoVacuna);
            Controls.Add(btnVolverTipoVacuna);
            Controls.Add(btnGuardarTipoVacunas);
            Controls.Add(cmbDosisRecomendada);
            Controls.Add(cmbTipoVacuna);
            Margin = new Padding(5, 5, 5, 5);
            Name = "TIPO_DE_VACUNA";
            Text = "TIPO_DE_VACUNA";
            Load += TIPO_DE_VACUNA_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTipoVacuna).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbTipoVacuna;
        private ComboBox cmbDosisRecomendada;
        private Button btnGuardarTipoVacunas;
        private Button btnVolverTipoVacuna;
        private DataGridView dgvTipoVacuna;
        private Button button1;
    }
}