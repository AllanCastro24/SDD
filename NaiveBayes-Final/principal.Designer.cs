
namespace NaiveBayes_Final
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_salir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txt_archivo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_cargar_dataset = new MaterialSkin.Controls.MaterialRaisedButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_porcentaje = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txt_intervalo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.rb_inicio = new MaterialSkin.Controls.MaterialRadioButton();
            this.rb_final = new MaterialSkin.Controls.MaterialRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_reiniciar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_matriz = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(51, 115);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(138, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Cargar dataset:";
            // 
            // btn_salir
            // 
            this.btn_salir.Depth = 0;
            this.btn_salir.Location = new System.Drawing.Point(1187, 33);
            this.btn_salir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Primary = true;
            this.btn_salir.Size = new System.Drawing.Size(27, 23);
            this.btn_salir.TabIndex = 1;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txt_archivo
            // 
            this.txt_archivo.Depth = 0;
            this.txt_archivo.Enabled = false;
            this.txt_archivo.Hint = "";
            this.txt_archivo.Location = new System.Drawing.Point(218, 115);
            this.txt_archivo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_archivo.Name = "txt_archivo";
            this.txt_archivo.PasswordChar = '\0';
            this.txt_archivo.SelectedText = "";
            this.txt_archivo.SelectionLength = 0;
            this.txt_archivo.SelectionStart = 0;
            this.txt_archivo.Size = new System.Drawing.Size(373, 28);
            this.txt_archivo.TabIndex = 3;
            this.txt_archivo.UseSystemPasswordChar = false;
            // 
            // btn_cargar_dataset
            // 
            this.btn_cargar_dataset.Depth = 0;
            this.btn_cargar_dataset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cargar_dataset.Location = new System.Drawing.Point(615, 115);
            this.btn_cargar_dataset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_cargar_dataset.Name = "btn_cargar_dataset";
            this.btn_cargar_dataset.Primary = true;
            this.btn_cargar_dataset.Size = new System.Drawing.Size(56, 28);
            this.btn_cargar_dataset.TabIndex = 4;
            this.btn_cargar_dataset.Text = "...";
            this.btn_cargar_dataset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cargar_dataset.UseVisualStyleBackColor = true;
            this.btn_cargar_dataset.Click += new System.EventHandler(this.btn_cargar_dataset_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(52, 179);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(262, 24);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Porcentaje de entrenamiento: ";
            // 
            // txt_porcentaje
            // 
            this.txt_porcentaje.Depth = 0;
            this.txt_porcentaje.Hint = "";
            this.txt_porcentaje.Location = new System.Drawing.Point(480, 179);
            this.txt_porcentaje.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_porcentaje.Name = "txt_porcentaje";
            this.txt_porcentaje.PasswordChar = '\0';
            this.txt_porcentaje.SelectedText = "";
            this.txt_porcentaje.SelectionLength = 0;
            this.txt_porcentaje.SelectionStart = 0;
            this.txt_porcentaje.Size = new System.Drawing.Size(111, 28);
            this.txt_porcentaje.TabIndex = 6;
            this.txt_porcentaje.UseSystemPasswordChar = false;
            this.txt_porcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_porcentaje_KeyPress);
            // 
            // txt_intervalo
            // 
            this.txt_intervalo.Depth = 0;
            this.txt_intervalo.Hint = "";
            this.txt_intervalo.Location = new System.Drawing.Point(480, 232);
            this.txt_intervalo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_intervalo.Name = "txt_intervalo";
            this.txt_intervalo.PasswordChar = '\0';
            this.txt_intervalo.SelectedText = "";
            this.txt_intervalo.SelectionLength = 0;
            this.txt_intervalo.SelectionStart = 0;
            this.txt_intervalo.Size = new System.Drawing.Size(111, 28);
            this.txt_intervalo.TabIndex = 8;
            this.txt_intervalo.UseSystemPasswordChar = false;
            this.txt_intervalo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_intervalo_KeyPress);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(52, 232);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(236, 24);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "Intervalo de discretización:";
            // 
            // rb_inicio
            // 
            this.rb_inicio.AutoSize = true;
            this.rb_inicio.BackColor = System.Drawing.SystemColors.Control;
            this.rb_inicio.Depth = 0;
            this.rb_inicio.Font = new System.Drawing.Font("Roboto", 10F);
            this.rb_inicio.Location = new System.Drawing.Point(16, 48);
            this.rb_inicio.Margin = new System.Windows.Forms.Padding(0);
            this.rb_inicio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_inicio.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_inicio.Name = "rb_inicio";
            this.rb_inicio.Ripple = true;
            this.rb_inicio.Size = new System.Drawing.Size(72, 30);
            this.rb_inicio.TabIndex = 10;
            this.rb_inicio.TabStop = true;
            this.rb_inicio.Text = "inicio";
            this.rb_inicio.UseVisualStyleBackColor = false;
            // 
            // rb_final
            // 
            this.rb_final.AutoSize = true;
            this.rb_final.BackColor = System.Drawing.Color.Transparent;
            this.rb_final.Depth = 0;
            this.rb_final.Font = new System.Drawing.Font("Roboto", 10F);
            this.rb_final.Location = new System.Drawing.Point(424, 48);
            this.rb_final.Margin = new System.Windows.Forms.Padding(0);
            this.rb_final.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_final.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_final.Name = "rb_final";
            this.rb_final.Ripple = true;
            this.rb_final.Size = new System.Drawing.Size(64, 30);
            this.rb_final.TabIndex = 11;
            this.rb_final.TabStop = true;
            this.rb_final.Text = "final";
            this.rb_final.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_inicio);
            this.groupBox1.Controls.Add(this.rb_final);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(56, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ubicación de la clase";
            // 
            // btn_reiniciar
            // 
            this.btn_reiniciar.Depth = 0;
            this.btn_reiniciar.Location = new System.Drawing.Point(827, 342);
            this.btn_reiniciar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_reiniciar.Name = "btn_reiniciar";
            this.btn_reiniciar.Primary = true;
            this.btn_reiniciar.Size = new System.Drawing.Size(247, 53);
            this.btn_reiniciar.TabIndex = 13;
            this.btn_reiniciar.Text = "Reiniciar";
            this.btn_reiniciar.UseVisualStyleBackColor = true;
            this.btn_reiniciar.Click += new System.EventHandler(this.btn_reiniciar_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(827, 115);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(247, 53);
            this.materialRaisedButton1.TabIndex = 14;
            this.materialRaisedButton1.Text = "Analizar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // btn_matriz
            // 
            this.btn_matriz.Depth = 0;
            this.btn_matriz.Location = new System.Drawing.Point(827, 225);
            this.btn_matriz.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_matriz.Name = "btn_matriz";
            this.btn_matriz.Primary = true;
            this.btn_matriz.Size = new System.Drawing.Size(247, 53);
            this.btn_matriz.TabIndex = 15;
            this.btn_matriz.Text = "Motrar resultados";
            this.btn_matriz.UseVisualStyleBackColor = true;
            this.btn_matriz.Click += new System.EventHandler(this.btn_matriz_Click);
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 660);
            this.ControlBox = false;
            this.Controls.Add(this.btn_matriz);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.btn_reiniciar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_intervalo);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txt_porcentaje);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btn_cargar_dataset);
            this.Controls.Add(this.txt_archivo);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.materialLabel1);
            this.Name = "principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clasificador Naive Bayes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton btn_salir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_archivo;
        private MaterialSkin.Controls.MaterialRaisedButton btn_cargar_dataset;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_porcentaje;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_intervalo;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialRadioButton rb_inicio;
        private MaterialSkin.Controls.MaterialRadioButton rb_final;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btn_reiniciar;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton btn_matriz;
    }
}

