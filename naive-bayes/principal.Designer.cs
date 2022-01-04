
namespace naive_bayes
{
    partial class principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_salir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_ruta_dataset = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_cargar_dataset = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_mismo_dataset = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_poracentaje_entrenamiento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rb_validacion_simple = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_intervalo_discretizacion = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_analisis = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dg_datos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_no = new MaterialSkin.Controls.MaterialRadioButton();
            this.rb_si = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_datos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_salir
            // 
            this.btn_salir.Depth = 0;
            this.btn_salir.Location = new System.Drawing.Point(1576, 28);
            this.btn_salir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Primary = true;
            this.btn_salir.Size = new System.Drawing.Size(26, 22);
            this.btn_salir.TabIndex = 0;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 117);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(138, 24);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Cargar dataset:";
            // 
            // txt_ruta_dataset
            // 
            this.txt_ruta_dataset.Depth = 0;
            this.txt_ruta_dataset.Enabled = false;
            this.txt_ruta_dataset.Hint = "";
            this.txt_ruta_dataset.Location = new System.Drawing.Point(213, 117);
            this.txt_ruta_dataset.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_ruta_dataset.Name = "txt_ruta_dataset";
            this.txt_ruta_dataset.PasswordChar = '\0';
            this.txt_ruta_dataset.SelectedText = "";
            this.txt_ruta_dataset.SelectionLength = 0;
            this.txt_ruta_dataset.SelectionStart = 0;
            this.txt_ruta_dataset.Size = new System.Drawing.Size(373, 28);
            this.txt_ruta_dataset.TabIndex = 2;
            this.txt_ruta_dataset.UseSystemPasswordChar = false;
            // 
            // btn_cargar_dataset
            // 
            this.btn_cargar_dataset.Depth = 0;
            this.btn_cargar_dataset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cargar_dataset.Location = new System.Drawing.Point(618, 117);
            this.btn_cargar_dataset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_cargar_dataset.Name = "btn_cargar_dataset";
            this.btn_cargar_dataset.Primary = true;
            this.btn_cargar_dataset.Size = new System.Drawing.Size(56, 28);
            this.btn_cargar_dataset.TabIndex = 3;
            this.btn_cargar_dataset.Text = "...";
            this.btn_cargar_dataset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cargar_dataset.UseVisualStyleBackColor = true;
            this.btn_cargar_dataset.Click += new System.EventHandler(this.btn_cargar_dataset_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(6, 18);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(84, 24);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Pruebas:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.materialRaisedButton1);
            this.groupBox1.Controls.Add(this.cb_mismo_dataset);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.txt_poracentaje_entrenamiento);
            this.groupBox1.Controls.Add(this.rb_validacion_simple);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Location = new System.Drawing.Point(39, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 270);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cb_mismo_dataset
            // 
            this.cb_mismo_dataset.AutoSize = true;
            this.cb_mismo_dataset.Depth = 0;
            this.cb_mismo_dataset.Font = new System.Drawing.Font("Roboto", 10F);
            this.cb_mismo_dataset.Location = new System.Drawing.Point(63, 63);
            this.cb_mismo_dataset.Margin = new System.Windows.Forms.Padding(0);
            this.cb_mismo_dataset.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cb_mismo_dataset.MouseState = MaterialSkin.MouseState.HOVER;
            this.cb_mismo_dataset.Name = "cb_mismo_dataset";
            this.cb_mismo_dataset.Ripple = true;
            this.cb_mismo_dataset.Size = new System.Drawing.Size(151, 30);
            this.cb_mismo_dataset.TabIndex = 11;
            this.cb_mismo_dataset.Text = "Mismo dataset:";
            this.cb_mismo_dataset.UseVisualStyleBackColor = true;
            this.cb_mismo_dataset.CheckedChanged += new System.EventHandler(this.cb_mismo_dataset_CheckedChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(204, 138);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(252, 24);
            this.materialLabel3.TabIndex = 9;
            this.materialLabel3.Text = "Porcentaje de entrenamiento";
            // 
            // txt_poracentaje_entrenamiento
            // 
            this.txt_poracentaje_entrenamiento.Depth = 0;
            this.txt_poracentaje_entrenamiento.Hint = "";
            this.txt_poracentaje_entrenamiento.Location = new System.Drawing.Point(488, 138);
            this.txt_poracentaje_entrenamiento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_poracentaje_entrenamiento.Name = "txt_poracentaje_entrenamiento";
            this.txt_poracentaje_entrenamiento.PasswordChar = '\0';
            this.txt_poracentaje_entrenamiento.SelectedText = "";
            this.txt_poracentaje_entrenamiento.SelectionLength = 0;
            this.txt_poracentaje_entrenamiento.SelectionStart = 0;
            this.txt_poracentaje_entrenamiento.Size = new System.Drawing.Size(86, 28);
            this.txt_poracentaje_entrenamiento.TabIndex = 8;
            this.txt_poracentaje_entrenamiento.UseSystemPasswordChar = false;
            this.txt_poracentaje_entrenamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_poracentaje_entrenamiento_KeyPress);
            // 
            // rb_validacion_simple
            // 
            this.rb_validacion_simple.AutoSize = true;
            this.rb_validacion_simple.Depth = 0;
            this.rb_validacion_simple.Font = new System.Drawing.Font("Roboto", 10F);
            this.rb_validacion_simple.Location = new System.Drawing.Point(115, 102);
            this.rb_validacion_simple.Margin = new System.Windows.Forms.Padding(0);
            this.rb_validacion_simple.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_validacion_simple.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_validacion_simple.Name = "rb_validacion_simple";
            this.rb_validacion_simple.Ripple = true;
            this.rb_validacion_simple.Size = new System.Drawing.Size(167, 30);
            this.rb_validacion_simple.TabIndex = 7;
            this.rb_validacion_simple.TabStop = true;
            this.rb_validacion_simple.Text = "Validación simple";
            this.rb_validacion_simple.UseVisualStyleBackColor = true;
            this.rb_validacion_simple.CheckedChanged += new System.EventHandler(this.rb_validacion_simple_CheckedChanged);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(35, 682);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(236, 24);
            this.materialLabel5.TabIndex = 8;
            this.materialLabel5.Text = "Intervalo de discretización:";
            // 
            // txt_intervalo_discretizacion
            // 
            this.txt_intervalo_discretizacion.Depth = 0;
            this.txt_intervalo_discretizacion.Hint = "";
            this.txt_intervalo_discretizacion.Location = new System.Drawing.Point(291, 682);
            this.txt_intervalo_discretizacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_intervalo_discretizacion.Name = "txt_intervalo_discretizacion";
            this.txt_intervalo_discretizacion.PasswordChar = '\0';
            this.txt_intervalo_discretizacion.SelectedText = "";
            this.txt_intervalo_discretizacion.SelectionLength = 0;
            this.txt_intervalo_discretizacion.SelectionStart = 0;
            this.txt_intervalo_discretizacion.Size = new System.Drawing.Size(76, 28);
            this.txt_intervalo_discretizacion.TabIndex = 9;
            this.txt_intervalo_discretizacion.UseSystemPasswordChar = false;
            this.txt_intervalo_discretizacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_intervalo_discretizacion_KeyPress);
            // 
            // btn_analisis
            // 
            this.btn_analisis.Depth = 0;
            this.btn_analisis.Location = new System.Drawing.Point(490, 668);
            this.btn_analisis.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_analisis.Name = "btn_analisis";
            this.btn_analisis.Primary = true;
            this.btn_analisis.Size = new System.Drawing.Size(184, 54);
            this.btn_analisis.TabIndex = 10;
            this.btn_analisis.Text = "Análisis";
            this.btn_analisis.UseVisualStyleBackColor = true;
            this.btn_analisis.Click += new System.EventHandler(this.materialRaisedButton1_Click_1);
            // 
            // dg_datos
            // 
            this.dg_datos.AllowUserToAddRows = false;
            this.dg_datos.AllowUserToDeleteRows = false;
            this.dg_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_datos.Location = new System.Drawing.Point(728, 117);
            this.dg_datos.Name = "dg_datos";
            this.dg_datos.ReadOnly = true;
            this.dg_datos.RowHeadersWidth = 51;
            this.dg_datos.RowTemplate.Height = 24;
            this.dg_datos.Size = new System.Drawing.Size(847, 530);
            this.dg_datos.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_no);
            this.groupBox2.Controls.Add(this.rb_si);
            this.groupBox2.Controls.Add(this.materialLabel4);
            this.groupBox2.Location = new System.Drawing.Point(39, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 163);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // rb_no
            // 
            this.rb_no.AutoSize = true;
            this.rb_no.Depth = 0;
            this.rb_no.Font = new System.Drawing.Font("Roboto", 10F);
            this.rb_no.Location = new System.Drawing.Point(349, 83);
            this.rb_no.Margin = new System.Windows.Forms.Padding(0);
            this.rb_no.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_no.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_no.Name = "rb_no";
            this.rb_no.Ripple = true;
            this.rb_no.Size = new System.Drawing.Size(52, 30);
            this.rb_no.TabIndex = 2;
            this.rb_no.TabStop = true;
            this.rb_no.Text = "No";
            this.rb_no.UseVisualStyleBackColor = true;
            this.rb_no.CheckedChanged += new System.EventHandler(this.rb_no_CheckedChanged);
            // 
            // rb_si
            // 
            this.rb_si.AutoSize = true;
            this.rb_si.Depth = 0;
            this.rb_si.Font = new System.Drawing.Font("Roboto", 10F);
            this.rb_si.Location = new System.Drawing.Point(34, 83);
            this.rb_si.Margin = new System.Windows.Forms.Padding(0);
            this.rb_si.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_si.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_si.Name = "rb_si";
            this.rb_si.Ripple = true;
            this.rb_si.Size = new System.Drawing.Size(45, 30);
            this.rb_si.TabIndex = 1;
            this.rb_si.TabStop = true;
            this.rb_si.Text = "Si";
            this.rb_si.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rb_si.UseVisualStyleBackColor = true;
            this.rb_si.CheckedChanged += new System.EventHandler(this.rb_si_CheckedChanged);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(26, 28);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(210, 24);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Contiene encabezados?";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(390, 192);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(184, 54);
            this.materialRaisedButton1.TabIndex = 12;
            this.materialRaisedButton1.Text = "Análisis";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click_2);
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 763);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dg_datos);
            this.Controls.Add(this.btn_analisis);
            this.Controls.Add(this.txt_intervalo_discretizacion);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_cargar_dataset);
            this.Controls.Add(this.txt_ruta_dataset);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btn_salir);
            this.Name = "principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clasificador Naive - Bayes";
            this.Load += new System.EventHandler(this.principal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_datos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btn_salir;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_ruta_dataset;
        private MaterialSkin.Controls.MaterialRaisedButton btn_cargar_dataset;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialRadioButton rb_validacion_simple;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_poracentaje_entrenamiento;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_intervalo_discretizacion;
        private MaterialSkin.Controls.MaterialRaisedButton btn_analisis;
        private MaterialSkin.Controls.MaterialCheckBox cb_mismo_dataset;
        private System.Windows.Forms.DataGridView dg_datos;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialRadioButton rb_no;
        private MaterialSkin.Controls.MaterialRadioButton rb_si;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}

