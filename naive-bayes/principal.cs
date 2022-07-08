﻿using System;
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
                    openFileDialog.Filter = "cvs files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
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
                    int clase;
                    int indice_i = 0;
                    int indice_fin = 0;
                    if (rb_inicio.Checked)
                    {
                        clase = 0;
                        indice_i = 1;
                        indice_fin = dg_datos.Columns.Count;
                    }
                    else
                    {
                        clase = dg_datos.Columns.Count - 1;
                        indice_i = 0;
                        indice_fin = dg_datos.Columns.Count - 1;
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
                    decimal[] vector = new decimal [dg_datos.Rows.Count];
                    decimal valor = 0;
                    bool discretizar = false;
                    int indice = 0;
                    
                    //Discretización
                    for (int columna = indice_i; columna < indice_fin; columna++)
                    {
                        discretizar = decimal.TryParse(conjunto[0, columna], out valor);
                        if (discretizar == true)
                        {
                            //Si entra es por que es un valor numerico, entonces llenas el vector y lo mandas a discretizar
                            for (int registro = 0; registro < dg_datos.Rows.Count; registro++)
                            {
                                vector[registro] = decimal.Parse(conjunto[registro, columna]);
                            }
                            //*******Frecuencias iguales*******
                            int intervaloDiscretizacion = Int16.Parse(txt_intervalo_discretizacion.Text); // En cuantos grupos lo voy a discretizar
                            int contador_intervalos = 0;
                            int[] grupos = new int[vector.Length];
                            int rango = dg_datos.Rows.Count / intervaloDiscretizacion; //Cuantos elementos por grupo
                            
                            //Paso 1 ordenarlos
                            decimal t;
                            for (int a = 1; a < vector.Length; a++)
                                for (int b = vector.Length - 1; b >= a; b--)
                                {
                                    if (vector[b - 1] > vector[b])
                                    {
                                        t = vector[b - 1];
                                        vector[b - 1] = vector[b];
                                        vector[b] = t;
                                    }
                                }

                            //asignar grupos
                            int intervalo = rango;
                            for (int i = 0; i < vector.Length; i++)
                            {
                                if (contador_intervalos < rango)
                                {
                                    grupos[i] = intervalo;
                                    contador_intervalos = contador_intervalos + 1;
                                }
                                else
                                {
                                    contador_intervalos = 0;
                                    intervalo = intervalo - 1;

                                    grupos[i] = intervalo;
                                    contador_intervalos = contador_intervalos + 1;
                                }

                                if (intervalo == 0)
                                {
                                    goto continuar_aca;
                                }
                            }
                            continuar_aca:
                            //Remplazar valores
                            for (int i = 0; i < vector.Length; i++)
                            {
                                indice = BusquedaBinaria(conjunto[i,columna].ToString(),vector,grupos);
                                NaiveBayes[i, columna] = grupos[indice].ToString();
                                //lb_pruebas.Items.Add("Discreto: " + NaiveBayes[i, columna].ToString() + "No discreto: " + conjunto[i, columna].ToString() + "\n");
                            }
                            
                        }
                        else
                        {
                            for (int registro = 0; registro < dg_datos.Rows.Count; registro++)
                            {
                                NaiveBayes[registro, columna] = conjunto[registro, columna];
                            }
                        }
                    }
                    
                    //Al llegar acá comenzamos a utilizar la matriz naive bayes que en teoría es la matriz final
                    //*******Matriz de confusión*******
                    dg_matriz_confusion.DataSource = MatrizConfusion(NaiveBayes, clase, dg_datos.Rows.Count);
                    //*******Metricas de evaluación*******
                    dg_metricas_evaluacion.DataSource = MatrizEvaluacion(4, conjunto, dg_datos.Rows.Count);

                    //Al final calcular accuacy
                    //CalcularAccuracy();
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
                    //dg_metricas_evaluacion.DataSource = MatrizEvaluacion(5, conjunto, porc);
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
            String[] encabezado = new string[4];
            encabezado[0] = "Categoría";
            encabezado[1] = "Precision";
            double precision = 0;
            encabezado[2] = "Exhaustividad";
            double exhaustividad = 0;
            encabezado[3] = "F1";
            double f1 = 0;

            //True positive, true negative, false positive y false negative
            int tp = AcumularTruePositives();
            int tn = AcumularTrueNegatives();
            int fp = AcumularFalsePositive();
            int fn = AcumularFalseNegative();

            //Calculos (Estos calculos se harán por clase
            //Precision:
            //precision = tp / tp + fp;
            //Exhaustividad o Recall
            //exhaustividad = tp / tp + fn;
            //F1
            //f1 = 2 * (precision * exhaustividad / precision + exhaustividad);

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

        public DataTable MatrizConfusion(String[,] matrizOriginal, int clase, int rows)
        {
            int contador_clases = 0;
            int contador = 0;
            MessageBox.Show(clase.ToString());
            MessageBox.Show(rows.ToString());
            //Primero obtener numero de clases diferentes y el vector con los encabezados
            for (int i = 0; i < rows;i++)
            {
                
            }
            String[] clases = new string[contador_clases];
            //El +1 es para incluir columna encabezados
            String[,] matriz_confusion = new string [contador_clases + 1, contador_clases + 1];
            //Calculo de matriz de consufión
            DataTable tbl = new DataTable();

            //Columnas
            for (int col = 0; col < contador_clases; col++)
                tbl.Columns.Add(new DataColumn(clases[col]));

            while (!(contador == contador_clases))
            {
                //Registros
                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < contador_clases; cIndex++)
                {
                    for (int rIndex = 0; rIndex < contador_clases; rIndex++)
                    {
                        dr[cIndex] = matriz_confusion[rIndex, cIndex];
                    }
                }

                tbl.Rows.Add(dr);
                contador = contador + 1;
            }

            return tbl;
        }

        public void NaiveBayes()
        {
            //Este código se va a correr por cada clase para obtener valor y generar matrices correspondientes
            //recibe los datos en forma de lista y recibe una clase a evaluar y devuelve el valor numerico de su probabilidad
            //var classify = new Classifier(data);
            //var result = classify.Probability("Rouge", test);
            
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
            //Es donde se intersectan las clases
            return truepositive;
        }

        public int AcumularTrueNegatives()
        {
            int truenegative = 0;
            //Suma las celdas que no consideran ninguno de los demás
            return truenegative;
        }

        public int AcumularFalsePositive()
        {
            int falsepositive = 0;
            //Toda la linea horizontal de la clase pero sin contemplar la intersección
            return falsepositive;
        }
        public int AcumularFalseNegative()
        {
            int falsenegative = 0;
            //Toda la linea vertical de la clase sin contar donde se intersectan
            return falsenegative;
        }

        public int BusquedaBinaria(String valor, decimal []vector, int []grupo)
        {
            //Variables para busqueda binaria
            int centro;
            int inf;
            int sup;
            int posicion_final = 0;
            bool encontro = false;

            inf = 0;
            sup = vector.Length - 1;

            while (inf <= sup && encontro == false)
            {
                centro = ((sup - inf) / 2) + inf;
                if (vector[centro].ToString() == valor)
                {
                    posicion_final = centro; 
                    encontro = true;
                }
                else
                {
                    int comparacion = valor.CompareTo(vector[centro].ToString());
                    if (comparacion < 0)
                    {
                        sup = centro - 1;
                    }
                    else if (comparacion > 0)
                    {
                        inf = centro + 1;
                    }
                }
            }

            return posicion_final;
        }
    }
}
