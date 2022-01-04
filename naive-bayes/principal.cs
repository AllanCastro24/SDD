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

        private void cb_mismo_dataset_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_ruta_dataset.Text == "")
            {
                MessageBox.Show("Aun no ha indicado dataset", "Mensaje del sistema");
                cb_mismo_dataset.Checked = false;
                rb_validacion_simple.Checked = false;
            }
            else
            {
                if (cb_mismo_dataset.Checked)
                {
                    rb_validacion_simple.Checked = true;
                }
                else
                {
                    rb_validacion_simple.Checked = false;
                    txt_poracentaje_entrenamiento.Text = "";
                }
                    
            }
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            //if (txt_ruta_dataset.Text == "")
            //{
            //MessageBox.Show("Aun no ha indicado dataset","Mensaje del sistema");
            //}
            //else
            //{
            //dg_datos.DataSource = ConvertToDataTable(txt_ruta_dataset.Text);
            //}

        }

        private void rb_validacion_simple_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_mismo_dataset.Checked)
            {
                MessageBox.Show("No indicó pruebas", "Mensaje del sistema");
                rb_validacion_simple.Checked = false;
            }
        }

        public DataTable ConvertToDataTable(String ruta, int columnas, int indice)
        {
            int contador = 0;
            DataTable tbl = new DataTable();
            //Se crea variable llamada: lector, para abrir el archivo csv donde están almacenadas los datos de los alumnos.
            var lector = new StreamReader(File.OpenRead(@ruta));
            //En el ciclo while, recorre todas las lineas del archivo

            while (!lector.EndOfStream)
            {
                contador = contador + 1;
                //Guarda el contenido de cada linea
                var line = lector.ReadLine();
                //Nombre de empresa, edad, tiempo y correo
                var cols = line.Split(',');
                if (contador == 1 )
                {
                    if (rb_si.Checked)
                    {
                        for (int col = 0; col < columnas; col++)
                            tbl.Columns.Add(new DataColumn(cols[col]));

                        continue;
                    }
                    else
                    {
                        for (int col = 0; col < columnas; col++)
                            tbl.Columns.Add(new DataColumn("Columna " + (col + 1).ToString()));
                    }
                    
                }
                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < columnas; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }

        private void txt_poracentaje_entrenamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (txt_ruta_dataset.Text == "")
            {
                MessageBox.Show("Aun no ha indicado dataset", "Mensaje del sistema");
                txt_poracentaje_entrenamiento.Text = "";
            }else
            {
                if (!cb_mismo_dataset.Checked)
                {
                    MessageBox.Show("No indicó pruebas", "Mensaje del sistema");
                    txt_poracentaje_entrenamiento.Text = "";
                }
            }
        }

        private void txt_intervalo_discretizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (txt_ruta_dataset.Text == "")
            {
                MessageBox.Show("Aun no ha indicado dataset", "Mensaje del sistema");
                txt_intervalo_discretizacion.Text = "";
            }
        }

        private void rb_no_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_ruta_dataset.Text == "")
            {
                MessageBox.Show("Aun no ha indicado dataset","Mensaje del sistema");
                rb_no.Checked = false;
            }
            else
            {
                if (rb_no.Checked)
                {
                    dg_datos.DataSource = ConvertToDataTable(txt_ruta_dataset.Text, total_columnas(txt_ruta_dataset.Text),0);
                }
            }
        }

        public int total_columnas(String ruta)
        {
            int columnas = 0;
            //Se crea variable llamada: lector, para abrir el archivo csv donde están almacenadas los datos de los alumnos.
            var lector = new StreamReader(File.OpenRead(@ruta));
            //En el ciclo while, recorre todas las lineas del archivo

            while (!lector.EndOfStream)
            {
                //Guarda el contenido de cada linea
                var line = lector.ReadLine();
                var cols = line.Split(',');
                columnas = cols.Count();
            }
            return columnas;
        }

        private void rb_si_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_ruta_dataset.Text == "")
            {
                MessageBox.Show("Aun no ha indicado dataset", "Mensaje del sistema");
                rb_si.Checked = false;
            }
            else
            {
                if (rb_si.Checked)
                {
                    dg_datos.DataSource = ConvertToDataTable(txt_ruta_dataset.Text, total_columnas(txt_ruta_dataset.Text),1);
                }
            }
        }
    }
}
