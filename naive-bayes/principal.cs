using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace naive_bayes
{
    public partial class principal : MaterialSkin.Controls.MaterialForm
    {
        public principal()
        {
            InitializeComponent();
        }

        private void principal_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.LightBlue900, Primary.LightBlue900, Primary.LightGreen900, Accent.Green700, TextShade.WHITE);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_cargar_dataset_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\archivo";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Almacenar la ruta de un archivo especifico
                    filePath = openFileDialog.FileName;

                    //Leer el contenido del documento con un stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            txt_ruta_dataset.Text = filePath;
        }

        private void btn_cargar_pruebas_externo_Click(object sender, EventArgs e)
        {
            if (cb_archivo_externo.Checked) { 
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\archivo";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Almacenar la ruta de un archivo especifico
                        filePath = openFileDialog.FileName;

                        //Leer el contenido del documento con un stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                }
                txt_ruta_dataset_pruebas.Text = filePath;
            }
            else
            {
                MessageBox.Show("No indicó check de pruebas externo...","Mensaje del sistema");
            }
        }

        private void cb_mismo_dataset_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_archivo_externo.Checked && cb_mismo_dataset.Checked)
            {
                MessageBox.Show("No puede indicar los dos checks", "Mensaje del sistema");

                cb_archivo_externo.Checked = false;
                cb_mismo_dataset.Checked = false;
            }
        }

        private void cb_archivo_externo_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_archivo_externo.Checked && cb_mismo_dataset.Checked)
            {
                MessageBox.Show("No puede indicar los dos checks", "Mensaje del sistema");

                cb_archivo_externo.Checked = false;
                cb_mismo_dataset.Checked = false;
            }
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void rb_validacion_simple_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
