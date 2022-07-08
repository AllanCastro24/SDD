using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using System.IO;

namespace NaiveBayes_Final
{
    public partial class principal : MaterialSkin.Controls.MaterialForm
    {
        public principal()
        {
            InitializeComponent();
        }

        // se declaran variables globales ya que se van a requerir en el formulario 2
        public static class Globales
        {
            public static int col = 0;
            public static int fila = 0;
            public static string str_RutaArchivo;
            public static string[,] arreglo;
            public static string[,] discretizada;
            public static string[] arreglo2;
            public static double[] comodin;
            public static string[] atributos;
            public static string[,] nuevo;
            public static string[] clase;
            public static int[] categoria;
            public static int[] rangos;
            public static int porcentaje;
            public static int evaluar;
            public static int inicio;
            public static int final;
            public static int[] numeros;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.Purple900, Primary.Purple900, Accent.Green700, TextShade.WHITE);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_cargar_dataset_Click(object sender, EventArgs e)
        {
            //permite abrir el explorador de archivos en la ruta c
            openFileDialog1.InitialDirectory = "c:\\archivo";
            openFileDialog1.Filter = "cvs files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Globales.str_RutaArchivo = openFileDialog1.FileName;
                    txt_archivo.Text = Globales.str_RutaArchivo;
                    var reader = new StreamReader(File.OpenRead(@Globales.str_RutaArchivo));
                    while (!reader.EndOfStream)
                    {

                        var linea1 = reader.ReadLine();
                        var valor1 = linea1.Split(',');

                        //cuentas cuantas columnas y filas tiene el dataset
                        Globales.col = valor1.Length;
                        Globales.fila = Globales.fila + 1;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void txt_porcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Solo permitir un decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (txt_archivo.Text == "")
            {
                MessageBox.Show("Aun no ha indicado dataset", "Mensaje del sistema");
                txt_archivo.Text = "";
            }
        }

        private void txt_intervalo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Solo permitir un decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (txt_archivo.Text == "")
            {
                MessageBox.Show("Aun no ha indicado dataset", "Mensaje del sistema");
                txt_archivo.Text = "";
            }
        }

        private void btn_reiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Globales.arreglo = new string[Globales.fila + 1, Globales.col + 1];
            Globales.discretizada = new string[Globales.fila + 1, Globales.col + 1];
            Globales.arreglo2 = new string[Globales.fila + 1];
            Globales.comodin = new double[Globales.fila + 1];
            Globales.nuevo = new string[Globales.fila + 2, (Globales.col * 3 + 2)];
            Globales.atributos = new string[4];

            //se guarda las clsaes default para discretizar
            Globales.atributos[0] = "muy bajo ";
            Globales.atributos[1] = "bajo ";
            Globales.atributos[2] = "medio ";
            Globales.atributos[3] = "alto ";
            Globales.inicio = 0;
            Globales.final = 0;
            Globales.categoria = new int[4];

            int muybajo = 0, bajo = 0, medio = 0, alto = 0, intervalo = 0, resta = 0, columna = 0, nuevacolumna = 0;
            double rango;
            int suma = 0, suma2;
            int contador = 1;

            //valida que en donde va la ruta del archivo 
            if (txt_archivo.Text != "")
            {
                var reader = new StreamReader(File.OpenRead(@Globales.str_RutaArchivo));
                int k = 1;
                while (!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    var valor = linea.Split(',');
                    for (int i = 1; i <= Globales.col; i++)
                    {
                        //guarda en un arreglo el contenido del dataset
                        Globales.arreglo[k, i] = valor[i - 1];
                    }
                    k = k + 1;
                }

                //valida que se haya ingresado un porcentaje de entrenamiento
                if (txt_porcentaje.Text == "")
                {
                    MessageBox.Show("Debe ingresar un porcentaje de entrenamiento", "Mensaje del sistema");
                }
                else if (Int32.Parse(txt_porcentaje.Text) <= 50 || Int32.Parse(txt_porcentaje.Text) >= 100)
                {
                    MessageBox.Show("Debe ingresar un porcentaje mayor a 50 y menor a 100", "Mensaje del sistema");
                }
                else
                {
                    //valida que se haya ingresado el intervalo a discretizar
                    if (txt_intervalo.Text != "" && Int32.Parse(txt_intervalo.Text) > 1)
                    {
                        if (rb_inicio.Checked == true)
                        {
                            Globales.inicio = 1;
                            Globales.porcentaje = Int32.Parse(txt_porcentaje.Text);
                            double b = 0;
                            string cadena;
                            bool bandera;
                            for (int j = 2; j <= Globales.col; j++)
                            {
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    cadena = Globales.arreglo[i, (j)];
                                    bandera = double.TryParse(cadena, out b);

                                    if (bandera == true)
                                    {
                                        suma++;
                                        Globales.arreglo2[i] = suma.ToString();
                                        Globales.comodin[i] = Convert.ToDouble(Globales.arreglo[i, j]);
                                    }
                                }
                                //ordena arreglo de menor a mayor
                                Array.Sort(Globales.comodin, Globales.arreglo2);
                                cadena = Globales.arreglo[1, (j)];
                                bandera = double.TryParse(cadena, out b);

                                if (bandera == true)
                                {
                                    for (int i = 1; i <= Globales.fila; i++)
                                    {
                                        //guarda datos ordenados con su puntero
                                        if (j - 1 == 0)
                                        {

                                            Globales.nuevo[i, contador] = Globales.arreglo2[i];
                                            Globales.nuevo[i, contador + 1] = Globales.comodin[i].ToString();
                                        }
                                        else
                                        {
                                            Globales.nuevo[i, contador] = Globales.arreglo2[i];
                                            Globales.nuevo[i, contador + 1] = Globales.comodin[i].ToString();
                                        }
                                    }
                                    columna = columna + 1;
                                    contador = contador + 3;
                                }

                                suma = 0;
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    Globales.arreglo2[i] = "";
                                    Globales.comodin[i] = 0;
                                }
                            }

                            intervalo = Int32.Parse(txt_intervalo.Text);
                            Globales.rangos = new int[intervalo];
                            Globales.clase = new string[intervalo];

                            //para discretizar, revisa cual fue el num de intervalo
                            if (intervalo == 2)
                            {
                                for (int i = 0; i < intervalo;)
                                {
                                    if (i < intervalo)
                                    {
                                        bajo = bajo + 1;
                                        Globales.categoria[0] = bajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        alto = alto + 1;
                                        Globales.categoria[1] = alto;
                                        i = i + 1;
                                    }

                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            if (intervalo == 3)
                            {
                                for (int i = 0; i < intervalo;)
                                {
                                    if (i < intervalo)
                                    {
                                        bajo = bajo + 1;
                                        Globales.categoria[0] = bajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        medio = medio + 1;
                                        Globales.categoria[1] = medio;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        alto = alto + 1;
                                        Globales.categoria[2] = alto;
                                        i = i + 1;
                                    }

                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            if (intervalo >= 4)
                            {
                                for (int i = 0; i < intervalo;)
                                {
                                    if (i < intervalo)
                                    {
                                        muybajo = muybajo + 1;
                                        Globales.categoria[0] = muybajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        bajo = bajo + 1;
                                        Globales.categoria[1] = bajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        medio = medio + 1;
                                        Globales.categoria[2] = medio;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        alto = alto + 1;
                                        Globales.categoria[3] = alto;
                                        i = i + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            rango = Globales.fila / intervalo;
                            contador = 0;
                            resta = (int)(Globales.fila - (Math.Truncate(rango) * intervalo));

                            //asigna cuanto es el num de elementos a discretizar cada clase
                            for (int i = 0; i < intervalo; i++)
                            {
                                Globales.rangos[i] = (int)Math.Truncate(rango);
                                contador = contador + Globales.rangos[i];
                            }
                            //revisda si falta datos a discretizar en caso que haya
                            for (int i = 0; i < resta; i++)
                            {
                                Globales.rangos[i] = Globales.rangos[i] + 1;
                            }

                            int algo = 0, valor = 0;
                            suma = 0;

                            //obtiene el nombre de cada categoria para discretizar
                            for (int i = 0; i < intervalo; i++)
                            {
                                algo = Globales.categoria[valor];

                                if (suma < algo)
                                {
                                    Globales.clase[i] = Globales.atributos[valor] + (suma + 1).ToString();
                                    suma = suma + 1;
                                }
                                else
                                {
                                    i = i - 1;
                                    suma = 0;
                                    valor = valor + 1;
                                }

                            }
                            suma = 0;

                            //discretiza
                            for (int h = 0; h < intervalo; h++)
                            {
                                suma = suma + Globales.rangos[h];

                                for (int i = (suma - Globales.rangos[h]) + 1; i <= suma; i++)
                                {
                                    for (int j = 3; j <= (Globales.col * 3); j = j + 3)
                                    {
                                        Globales.nuevo[i, j] = Globales.clase[h];
                                    }
                                }
                            }

                            suma = 0;
                            b = 0;
                            nuevacolumna = 2;

                            //ingresa la clase al arreglo discretizado
                            for (int i = 1; i <= Globales.fila; i++)
                            {
                                Globales.discretizada[i, 1] = Globales.arreglo[i, 1];
                            }

                            //guarda datos que ya estan discretizados por default
                            for (int j = 2; j <= Globales.col; j++)
                            {
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    cadena = Globales.arreglo[i, j];
                                    bandera = double.TryParse(cadena, out b);
                                    if (bandera == false)
                                    {
                                        Globales.discretizada[i, nuevacolumna] = Globales.arreglo[i, j];
                                    }

                                }

                                cadena = Globales.arreglo[1, j];
                                bandera = double.TryParse(cadena, out b);

                                if (bandera == false)
                                {
                                    suma = suma + 1;
                                    nuevacolumna = nuevacolumna + 1;
                                }
                            }
                            //limpia las columnas restantes
                            for (int j = nuevacolumna; j <= Globales.col; j++)
                            {
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    Globales.discretizada[i, j] = "";
                                }

                            }
                            suma2 = 0;

                            //cuenta si una columna esta vacia
                            for (int j = 1; j <= Globales.col; j++)
                            {
                                if (Globales.discretizada[1, j] == "")
                                {
                                }
                                else
                                {
                                    suma2 = suma2 + 1;
                                }
                            }

                            //ingresa los datos discretizados a un arreglo
                            int numero;
                            for (int j = 1; j < (columna * 3 + 1); j = j + 3)
                            {
                                suma2 = suma2 + 1;

                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    if (Globales.nuevo[i, j] == null)
                                    {
                                    }
                                    else
                                    {
                                        numero = Int32.Parse(Globales.nuevo[i, j]);
                                        Globales.discretizada[numero, suma2] = Globales.nuevo[i, j + 2];
                                    }
                                }
                            }

                            //se crea daragird para mostrar datos discretizados
                            DataGridView dgv = new DataGridView();
                            DataTable Tabla = new DataTable();
                            DataRow Renglon;

                            dgv.Size = new Size(850, 200);
                            dgv.Location = new Point(43, 328);
                            this.Controls.Add(dgv);

                            for (int j = 1; j <= Globales.col; j++)
                            {
                                Tabla.Columns.Add(new DataColumn("columna " + j.ToString()));

                                //dar color a encabezado de datagrid
                                dgv.EnableHeadersVisualStyles = false;
                                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
                                dgv.AllowUserToAddRows = false;
                                dgv.AllowUserToDeleteRows = false;
                            }


                            for (int i = 1; i < Globales.fila + 1; i++)
                            {
                                Renglon = Tabla.NewRow();
                                for (int j = 0; j < Globales.col; j++)
                                {

                                    Renglon[j] = Globales.discretizada[i, j + 1];

                                }
                                Tabla.Rows.Add(Renglon);
                            }
                            dgv.DataSource = Tabla;
                        }

                        else if (rb_final.Checked == true)
                        {
                            Globales.final = 1;
                            Globales.porcentaje = Int32.Parse(txt_porcentaje.Text);
                            double b = 0;
                            string cadena;
                            bool bandera;

                            //obtiene columna del dataset
                            for (int j = 1; j < Globales.col; j++)
                            {
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    cadena = Globales.arreglo[i, (j)];
                                    bandera = double.TryParse(cadena, out b);

                                    if (bandera == true)
                                    {
                                        suma++;
                                        Globales.arreglo2[i] = suma.ToString();
                                        Globales.comodin[i] = Convert.ToDouble(Globales.arreglo[i, j]);
                                    }
                                }
                                //ordena columna con su respectivo puntero
                                Array.Sort(Globales.comodin, Globales.arreglo2);
                                cadena = Globales.arreglo[1, (j)];
                                bandera = double.TryParse(cadena, out b);

                                //guarda en un arreglo los datos ordenados con su respenctivo puntero
                                if (bandera == true)
                                {
                                    for (int i = 1; i <= Globales.fila; i++)
                                    {
                                        if (j - 1 == 0)
                                        {
                                            Globales.nuevo[i, contador] = Globales.arreglo2[i];
                                            Globales.nuevo[i, contador + 1] = Globales.comodin[i].ToString();
                                        }
                                        else
                                        {
                                            Globales.nuevo[i, contador] = Globales.arreglo2[i];
                                            Globales.nuevo[i, contador + 1] = Globales.comodin[i].ToString();
                                        }
                                    }
                                    columna = columna + 1;
                                    contador = contador + 3;
                                }

                                suma = 0;
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    Globales.arreglo2[i] = "";
                                    Globales.comodin[i] = 0;
                                }
                            }  //termina for


                            intervalo = Int32.Parse(txt_intervalo.Text);
                            Globales.rangos = new int[intervalo];
                            Globales.clase = new string[intervalo];
                            //determina cual es el intervalo para obtener las clases y discretizar
                            if (intervalo == 2)
                            {
                                for (int i = 0; i < intervalo;)
                                {
                                    if (i < intervalo)
                                    {
                                        bajo = bajo + 1;
                                        Globales.categoria[0] = bajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        alto = alto + 1;
                                        Globales.categoria[1] = alto;
                                        i = i + 1;
                                    }

                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            if (intervalo == 3)
                            {
                                for (int i = 0; i < intervalo;)
                                {
                                    if (i < intervalo)
                                    {
                                        bajo = bajo + 1;
                                        Globales.categoria[0] = bajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        medio = medio + 1;
                                        Globales.categoria[1] = medio;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        alto = alto + 1;
                                        Globales.categoria[2] = alto;
                                        i = i + 1;
                                    }

                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            if (intervalo >= 4)
                            {
                                for (int i = 0; i < intervalo;)
                                {
                                    if (i < intervalo)
                                    {
                                        muybajo = muybajo + 1;
                                        Globales.categoria[0] = muybajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        bajo = bajo + 1;
                                        Globales.categoria[1] = bajo;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        medio = medio + 1;
                                        Globales.categoria[2] = medio;
                                        i = i + 1;
                                    }
                                    if (i < intervalo)
                                    {
                                        alto = alto + 1;
                                        Globales.categoria[3] = alto;
                                        i = i + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            rango = Globales.fila / intervalo;
                            contador = 0;
                            resta = (int)(Globales.fila - (Math.Truncate(rango) * intervalo));
                            //obtiene el rango para cada clase
                            for (int i = 0; i < intervalo; i++)
                            {
                                Globales.rangos[i] = (int)Math.Truncate(rango);
                                contador = contador + Globales.rangos[i];
                            }
                            //revisa si falta algun dato para obtener rango
                            for (int i = 0; i < resta; i++)
                            {
                                Globales.rangos[i] = Globales.rangos[i] + 1;
                            }

                            int algo = 0, valor = 0;
                            suma = 0;
                            //obtiene las clases para discretizar
                            for (int i = 0; i < intervalo; i++)
                            {
                                algo = Globales.categoria[valor];

                                if (suma < algo)
                                {
                                    Globales.clase[i] = Globales.atributos[valor] + (suma + 1).ToString();
                                    suma = suma + 1;
                                }
                                else
                                {
                                    i = i - 1;
                                    suma = 0;
                                    valor = valor + 1;
                                }
                            }
                            suma = 0;

                            //discretizar

                            for (int h = 0; h < intervalo; h++)
                            {
                                suma = suma + Globales.rangos[h];

                                for (int i = (suma - Globales.rangos[h]) + 1; i <= suma; i++)
                                {
                                    for (int j = 3; j <= (Globales.col * 3); j = j + 3)
                                    {
                                        Globales.nuevo[i, j] = Globales.clase[h];
                                    }
                                }
                            }

                            suma = 0;
                            b = 0;
                            nuevacolumna = 1;

                            //en el arreeglo diszcretizada guarda la clase correspondiente
                            for (int i = 1; i <= Globales.fila; i++)
                            {
                                Globales.discretizada[i, Globales.col] = Globales.arreglo[i, Globales.col];
                            }

                            //guarda datos discretizados por default en sarreglo discretizada
                            for (int j = 1; j < Globales.col; j++)
                            {
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    cadena = Globales.arreglo[i, j];
                                    bandera = double.TryParse(cadena, out b);

                                    if (bandera == false)
                                    {
                                        Globales.discretizada[i, nuevacolumna] = Globales.arreglo[i, j];
                                    }
                                }

                                cadena = Globales.arreglo[1, j];
                                bandera = double.TryParse(cadena, out b);

                                if (bandera == false)
                                {
                                    suma = suma + 1;
                                    nuevacolumna = nuevacolumna + 1;
                                }

                            }

                            for (int j = nuevacolumna; j < Globales.col; j++)
                            {
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    Globales.discretizada[i, j] = "";
                                }
                            }

                            suma2 = 0;
                            //ceunta cuantas columnas de discretizada ya estan ocupadas
                            for (int j = 1; j < Globales.col; j++)
                            {
                                if (Globales.discretizada[1, j] == "")
                                {
                                }
                                else
                                {
                                    suma2 = suma2 + 1;
                                }
                            }

                            int numero;
                            //guarda datos discretizados en arreglo discretizada
                            for (int j = 1; j < (columna * 3); j = j + 3)
                            {
                                suma2 = suma2 + 1;
                                for (int i = 1; i <= Globales.fila; i++)
                                {
                                    if (Globales.nuevo[i, j] == null)
                                    {
                                    }
                                    else
                                    {
                                        numero = Int32.Parse(Globales.nuevo[i, j]);
                                        Globales.discretizada[numero, suma2] = Globales.nuevo[i, j + 2];
                                    }
                                }
                            }

                            //se crea datagrid para mostras dataset discretizado

                            DataGridView dgv = new DataGridView();
                            DataTable Tabla = new DataTable();
                            DataRow Renglon;

                            dgv.Size = new Size(850, 200);
                            dgv.Location = new Point(43, 328);
                            this.Controls.Add(dgv);

                            for (int j = 1; j <= Globales.col; j++)
                            {
                                Tabla.Columns.Add(new DataColumn("columna " + j.ToString()));

                                //DGV Principal

                                //dar color a encabezado de datagrid
                                dgv.EnableHeadersVisualStyles = false;
                                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
                                dgv.AllowUserToAddRows = false;
                                dgv.AllowUserToDeleteRows = false;
                            }

                            for (int i = 1; i < Globales.fila + 1; i++)
                            {
                                Renglon = Tabla.NewRow();
                                for (int j = 0; j < Globales.col; j++)
                                {
                                    Renglon[j] = Globales.discretizada[i, j + 1];
                                }
                                Tabla.Rows.Add(Renglon);
                            }
                            dgv.DataSource = Tabla;
                        }
                        else
                        {
                            MessageBox.Show("Debe de seleccionar donde se ubica la clase", "Mensaje del sistema");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar el numero de intervalos", "Mensaje del sistema");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo", "Mensaje del sistema");
            }
        }

        private void btn_matriz_Click(object sender, EventArgs e)
        {
            int nuevasfilas;
            double auxiliar;
            auxiliar = (Globales.porcentaje * Globales.fila) / 100;
            nuevasfilas = (int)Math.Round(auxiliar);
            Globales.evaluar = Globales.fila - nuevasfilas;

            resultados mostrar = new resultados();
            mostrar.Show();
        }
    }
}
