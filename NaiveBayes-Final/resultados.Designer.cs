
namespace NaiveBayes_Final
{
    partial class resultados
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
            this.btn_salir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.total_elementos = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.total_aciertos = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.accuracy_final = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btn_salir
            // 
            this.btn_salir.Depth = 0;
            this.btn_salir.Location = new System.Drawing.Point(1187, 33);
            this.btn_salir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Primary = true;
            this.btn_salir.Size = new System.Drawing.Size(27, 23);
            this.btn_salir.TabIndex = 2;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(443, 93);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(205, 24);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Metricas de evaluación";
            // 
            // total_elementos
            // 
            this.total_elementos.Depth = 0;
            this.total_elementos.Enabled = false;
            this.total_elementos.Hint = "";
            this.total_elementos.Location = new System.Drawing.Point(1038, 173);
            this.total_elementos.MouseState = MaterialSkin.MouseState.HOVER;
            this.total_elementos.Name = "total_elementos";
            this.total_elementos.PasswordChar = '\0';
            this.total_elementos.SelectedText = "";
            this.total_elementos.SelectionLength = 0;
            this.total_elementos.SelectionStart = 0;
            this.total_elementos.Size = new System.Drawing.Size(119, 28);
            this.total_elementos.TabIndex = 4;
            this.total_elementos.UseSystemPasswordChar = false;
            // 
            // total_aciertos
            // 
            this.total_aciertos.Depth = 0;
            this.total_aciertos.Enabled = false;
            this.total_aciertos.Hint = "";
            this.total_aciertos.Location = new System.Drawing.Point(1038, 252);
            this.total_aciertos.MouseState = MaterialSkin.MouseState.HOVER;
            this.total_aciertos.Name = "total_aciertos";
            this.total_aciertos.PasswordChar = '\0';
            this.total_aciertos.SelectedText = "";
            this.total_aciertos.SelectionLength = 0;
            this.total_aciertos.SelectionStart = 0;
            this.total_aciertos.Size = new System.Drawing.Size(119, 28);
            this.total_aciertos.TabIndex = 5;
            this.total_aciertos.UseSystemPasswordChar = false;
            // 
            // accuracy_final
            // 
            this.accuracy_final.Depth = 0;
            this.accuracy_final.Enabled = false;
            this.accuracy_final.Hint = "";
            this.accuracy_final.Location = new System.Drawing.Point(1038, 343);
            this.accuracy_final.MouseState = MaterialSkin.MouseState.HOVER;
            this.accuracy_final.Name = "accuracy_final";
            this.accuracy_final.PasswordChar = '\0';
            this.accuracy_final.SelectedText = "";
            this.accuracy_final.SelectionLength = 0;
            this.accuracy_final.SelectionStart = 0;
            this.accuracy_final.Size = new System.Drawing.Size(119, 28);
            this.accuracy_final.TabIndex = 6;
            this.accuracy_final.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(809, 173);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(178, 24);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Elementos elegidos";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(809, 252);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(80, 24);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Aciertos";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(809, 343);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(87, 24);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Accuracy";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(241, 363);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(178, 24);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "Matriz de confusión";
            // 
            // resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 660);
            this.ControlBox = false;
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.accuracy_final);
            this.Controls.Add(this.total_aciertos);
            this.Controls.Add(this.total_elementos);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btn_salir);
            this.Name = "resultados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mostrar resultados";
            this.Load += new System.EventHandler(this.resultados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btn_salir;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField total_elementos;
        private MaterialSkin.Controls.MaterialSingleLineTextField total_aciertos;
        private MaterialSkin.Controls.MaterialSingleLineTextField accuracy_final;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}