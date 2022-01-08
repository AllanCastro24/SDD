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
using NaiveBayes;

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
            if (txt_ruta_dataset.Text != "")
            {
                Application.Restart();
            }
            else
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
                    txt_poracentaje_entrenamiento.Text = "0";
                }
                    
            }
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            if (dg_datos.RowCount == 0)
            {
                MessageBox.Show("Aun no tiene un dataset", "Mensaje del sistema");
            }
            else
            {
                if (txt_intervalo_discretizacion.Text == "" || (rb_inicio.Checked == false && rb_final.Checked == false))
                {
                    MessageBox.Show("Aun faltan configuraciones", "Mensaje del sistema");
                }
                else
                {
                    if (rb_inicio.Checked)
                    {
                        int clase = 0;
                    }
                    else
                    {
                        int clase = dg_datos.Rows.Count - 1;
                    }
                    //Matriz inicial
                    String[,] conjunto = new String[dg_datos.Rows.Count, dg_datos.Columns.Count];
                    //Esta matriz es donde se va a poner la matriz final
                    String[,] NaiveBayes = new String[dg_datos.Rows.Count, dg_datos.Columns.Count];
                    //Aqui se exporta el dataset a la matriz inicial
                    foreach (DataGridViewRow row in dg_datos.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cel in row.Cells)
                            {
                                conjunto[cel.RowIndex, cel.ColumnIndex] = cel.Value.ToString();
                            }
                        }
                    }
                    //Empieza el calculo de matriz final (Proceso de discretización)
                    int[] vector = new int [dg_datos.Rows.Count];
                    
                    FrecuenciasIguales(vector);
                    //MessageBox.Show("Se exportó correctamente", "Mensaje del sistema");
                    //*******Metricas de evaluación*******
                    //dg_metricas_evaluacion.DataSource = MatrizEvaluacion(5, conjunto, dg_datos.Rows.Count);

                    //Al final calcular accuacy
                    CalcularAccuracy();
                }
            }
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

        private void materialRaisedButton1_Click_2(object sender, EventArgs e)
        {
            if (dg_datos.RowCount == 0)
            {
                MessageBox.Show("Aun no tiene un dataset", "Mensaje del sistema");
            }
            else
            {
                if (txt_intervalo_discretizacion.Text == "" || (rb_inicio.Checked == false && rb_final.Checked == false))
                {
                    MessageBox.Show("Ingrese intervalo de discretización", "Mensaje del sistema");
                }
                else
                {
                    int contador = 0;
                    int porc = (Int16.Parse(txt_poracentaje_entrenamiento.Text)* dg_datos.Rows.Count) / 100;
                    //MessageBox.Show(porc.ToString(), "Mensaje del sistema");
                    //MessageBox.Show(dg_datos.Rows.Count.ToString(), "Mensaje del sistema");
                    //Comienza el programa
                    //Exportar a una matriz
                    String[,] conjunto = new String[porc, dg_datos.Columns.Count];
                    String[,] NaiveBayesPruebas = new String[porc, dg_datos.Columns.Count];

                    if (rb_inicio.Checked)
                    {
                        int clase = 0;
                    }
                    else
                    {
                        int clase = porc - 1;
                    }
                    foreach (DataGridViewRow row in dg_datos.Rows)
                    {
                        contador = contador + 1;
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cel in row.Cells)
                            {
                                if (contador == porc)
                                {
                                    conjunto[cel.RowIndex, cel.ColumnIndex] = cel.Value.ToString();
                                    goto Lleno;
                                }
                                else
                                {
                                    conjunto[cel.RowIndex, cel.ColumnIndex] = cel.Value.ToString();
                                }
                            }
                        }
                        contador = contador + 1;
                    }
                Lleno:
                    MessageBox.Show("Ingrese intervalo de discretización", "Mensaje del sistema");
                    //MessageBox.Show("Se exportó correctamente", "Mensaje del sistema");
                    //*******Metricas de evaluación*******
                    dg_metricas_evaluacion.DataSource = MatrizEvaluacion(5, conjunto, porc);
                }
            }
        }

        private void txt_poracentaje_entrenamiento_TextChanged(object sender, EventArgs e)
        {
            if (Int16.Parse(txt_poracentaje_entrenamiento.Text) > 100)
            {
                MessageBox.Show("No se permite más del 100%", "Mensaje del sistema");
                txt_poracentaje_entrenamiento.Text = "";
            }
        }

        public DataTable MatrizEvaluacion(int columnas, String[,] conjunto, int rows)
        {
            int contador = 0;
            DataTable tbl = new DataTable();
            String[] encabezado = new string[5];
            encabezado[0] = "Categoría";
            encabezado[1] = "Precision";
            double precision = 0;
            encabezado[2] = "Exhaustividad";
            double exhaustividad = 0;
            encabezado[3] = "F1";
            double f1 = 0;
            encabezado[4] = "Soporte";

            //True positive, true negative, false positive y false negative
            int tp = AcumularTruePositives();
            int tn = AcumularTrueNegatives();
            int fp = AcumularFalsePositive();
            int fn = AcumularFalseNegative();

            //Calculos (Estos calculos se harán por clase
            //Precision:
            precision = tp / tp + fp;
            //Exhaustividad o Recall
            exhaustividad = tp / tp + fn;
            //F1
            f1 = 2 * (precision * exhaustividad / precision + exhaustividad);

            //Columnas
            for (int col = 0; col < columnas; col++)
                tbl.Columns.Add(new DataColumn(encabezado[col]));

            while (!(contador == rows))
            {
                //Registros
                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < columnas; cIndex++)
                {
                        dr[cIndex] = conjunto[1,cIndex];
                }

                tbl.Rows.Add(dr);
                contador = contador + 1;
            }

            

            return tbl;
        }

        public DataTable MatrizConfusion()
        {
            DataTable tbl = new DataTable();

            return tbl;
        }
        public void calcular_numero_clases()
        {

        }

        public void discretizar()
        {

        }

        public void NaiveBayes()
        {
            //Este código se va a correr por cada clase para obtener valor y generar matrices correspondientes
            //recibe los datos en forma de lista y recibe una clase a evaluar y devuelve el valor numerico de su probabilidad
            //var classify = new Classifier(data);
            //var result = classify.Probability("Rouge", test);
            
        }
        public void FrecuenciasIguales(int [] arreglo_a_discretizar)
        {
            //Metodo de discretización
            int intervaloDiscretizacion = Int16.Parse(txt_intervalo_discretizacion.Text);
            int[] grupos = new int[arreglo_a_discretizar.Length];
            //Paso 1 ordenarlos
            int t;
            for (int a = 1; a < arreglo_a_discretizar.Length; a++)
                for (int b = arreglo_a_discretizar.Length - 1; b >= a; b--)
                {
                    if (arreglo_a_discretizar[b - 1] > arreglo_a_discretizar[b])
                    {
                        t = arreglo_a_discretizar[b - 1];
                        arreglo_a_discretizar[b - 1] = arreglo_a_discretizar[b];
                        arreglo_a_discretizar[b] = t;
                    }
            }
            //Calcular cuantos elementos habrá por grupo
            int intervalos = arreglo_a_discretizar.Length / intervaloDiscretizacion;
            //asignar grupos
            for (int i = 0; i< arreglo_a_discretizar.Length;i++)
            {
                if (i < intervalos)
                {
                    
                }
                else
                {

                }
            }
        }

        public void CalcularAccuracy()
        {
            int tp = AcumularTruePositives();
            int tn = AcumularTrueNegatives();
            int fp = AcumularFalsePositive();
            int fn = AcumularFalseNegative();
            //Primero acumular los true positives los true positives
            txt_accuracy.Text = (tp + tn / tp + tn + fp + fn).ToString();
        }

        public int AcumularTruePositives()
        {
            int truepositive = 0;
            //acá se acumulan los true positives
            return truepositive;
        }

        public int AcumularTrueNegatives()
        {
            int truenegative = 0;
            //acá se acumulan los true positives
            return truenegative;
        }

        public int AcumularFalsePositive()
        {
            int falsepositive = 0;
            //acá se acumulan los true positives
            return falsepositive;
        }
        public int AcumularFalseNegative()
        {
            int falsenegative = 0;
            //acá se acumulan los true positives
            return falsenegative;
        }
    }
}
