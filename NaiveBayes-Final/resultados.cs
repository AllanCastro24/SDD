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
using static NaiveBayes_Final.principal;
using static NaiveBayes_Final.principal.Globales;

namespace NaiveBayes_Final
{
    public partial class resultados : MaterialSkin.Controls.MaterialForm
    {
        public resultados()
        {
            InitializeComponent();
        }

        int totalclase;
        string[,] laplace;
        string[,] laplace2;
        string[,] atributoss;
        string[,] discretizadanueva;
        string[,] discretizadafinal;
        string[,] clases;
        int numerador = 0, denominador;
        decimal calculo = 0, calculo2 = 1;
        string[,] suavizado;
        string[,] mayor;
        int colum = 4;
        int auxil = 1;
        decimal[] auxi;

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string[] valorauxi;

        private void resultados_Load(object sender, EventArgs e)
        {
            //Configuración de diseño
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.Purple900, Primary.Purple900, Accent.Green700, TextShade.WHITE);

            //Inicia programa
            clases = new string[evaluar + 1, 4];
            atributoss = new string[100, (col * 2) + 2];
            laplace = new string[evaluar + 2, col + 2];
            laplace2 = new string[evaluar + 2, col + 2];
            discretizadanueva = new string[(fila) + 1, col + 1];
            discretizadafinal = new string[(fila - evaluar) + 1, col + 1];
            int linea = 1;
            int[] elemento = new int[evaluar + 1];
            int[] nuevoelemento = new int[fila + 1];

            // se obtiene los datos aleatorios para realizar suavizado de laplace
            for (int contador1 = 1; contador1 <= evaluar; contador1++)
            {
                Random r = new Random();
                elemento[contador1] = r.Next(1, fila + 1);
                int contador2 = 0;

                while (contador2 < contador1)
                {
                    if (elemento[contador2] == elemento[contador1])
                    {
                        elemento[contador1] = r.Next(1, fila + 1);
                        contador2 = 0;
                        continue;
                    }
                    contador2++;
                }
            }

            //revisa si la clase esta al inicio
            if (inicio == 1)
            {
                Array.Sort(elemento);
                //guarda datos que se van a evaluar sin la clase (se va a determinar con laplace)
                for (int j = 2; j <= col; j++)
                {
                    for (int contador1 = 1; contador1 <= evaluar; contador1++)
                    {
                        linea = elemento[contador1];
                        laplace2[contador1, j] = discretizada[linea, j];
                    }
                }

                //guarda datos que se van a evaluar junto con la clase
                for (int j = 1; j <= col; j++)
                {
                    for (int contador1 = 1; contador1 <= evaluar; contador1++)
                    {
                        linea = elemento[contador1];
                        laplace[contador1, j] = discretizada[linea, j];
                    }
                }

                for (int contador1 = 1; contador1 <= evaluar; contador1++)
                {
                    nuevoelemento[elemento[contador1]] = elemento[contador1];
                }


                linea = 1;
                //guarda los datos con los que se van a evaluar
                for (int j = 1; j <= col; j++)
                {
                    for (int i = 1; i <= fila; i++)
                    {
                        if (nuevoelemento[i] != 0)
                        {
                        }
                        else
                        {
                            discretizadanueva[linea, j] = discretizada[i, j];
                            linea++;
                        }
                    }
                    linea = 1;
                }

                //obtiene la clase sin repetir
                HashSet<string> set = new HashSet<string>();

                for (int i = 1; i <= fila - evaluar; i++)
                {
                    set.Add(discretizadanueva[i, 1]);
                }

                int filaclase = 1;
                foreach (var n in set)
                {
                    clases[filaclase, 1] = n;
                    filaclase++;
                }
                totalclase = set.Count;
                int conteo = 0;

                for (int j = 1; j <= totalclase; j++)
                {
                    for (int i = 1; i <= fila - evaluar; i++)
                    {
                        if (discretizadanueva[i, 1] == clases[j, 1])
                        {
                            conteo = conteo + 1;
                        }
                    }
                    clases[j, 2] = conteo.ToString();
                    conteo = 0;
                }

                //se guarda en los atributos de cada columna sin repetir
                int nuevacolumna = 1;
                set.Clear();
                filaclase = 1;
                for (int j = 1; j <= col; j++)
                {
                    for (int i = 1; i <= fila - evaluar; i++)
                    {
                        set.Add(discretizadanueva[i, j]);
                    }

                    foreach (var n in set)
                    {
                        atributoss[filaclase, nuevacolumna] = n;
                        filaclase++;
                    }

                    atributoss[1, nuevacolumna + 1] = set.Count.ToString();
                    set.Clear();
                    filaclase = 1;
                    nuevacolumna = nuevacolumna + 2;
                }

                for (int j = 2; j <= col; j++)
                {

                    for (int i = 1; i <= fila - evaluar; i++)
                    {
                        discretizadafinal[i, j] = discretizadanueva[i, j];
                    }
                }

                auxi = new decimal[totalclase + 1];
                valorauxi = new string[totalclase + 1];
                suavizado = new string[totalclase + 1, col + 2];
                mayor = new string[totalclase + 1, 3];

                //se comienza a discretizar mediante el suavizado de laplace
                for (int i = 1; i <= evaluar; i++)
                {
                    for (int k = 1; k <= totalclase; k++)
                    {
                        for (int j = 2; j <= col; j++)
                        {
                            for (int m = 1; m <= fila - evaluar; m++)
                            {
                                if (laplace[i, j] == discretizadanueva[m, j] && discretizadanueva[m, 1] == clases[k, 1])
                                {
                                    numerador = numerador + 1;
                                }

                                auxil = auxil + 1;

                            }
                            auxil = 1;

                            numerador = numerador + 1;

                            denominador = Int32.Parse(clases[k, 2]) + Int32.Parse(atributoss[1, colum]);
                            calculo = ((decimal)numerador / (decimal)denominador);
                            calculo2 = calculo2 * calculo;
                            suavizado[k, j] = calculo.ToString();
                            suavizado[k, 1] = clases[k, 1];
                            numerador = 0;
                            colum = colum + 2;
                        }

                        calculo2 = calculo2 * (Convert.ToDecimal(clases[k, 2]) / Convert.ToDecimal(fila));
                        suavizado[k, col + 1] = calculo2.ToString();
                        colum = 2;
                        auxi[k] = calculo2;
                        valorauxi[k] = clases[k, 1];
                        calculo2 = 1;
                    }

                    decimal mayorfinal = 0;
                    int nume = 0;
                    for (int a = 1; a <= totalclase; a++)
                    {
                        if (auxi[a] > mayorfinal)
                        {
                            mayorfinal = auxi[a];
                            nume = a;
                        }
                    }

                    //aqui se asigna cual es mayor y meter el valor a laplace2
                    for (int a = 1; a <= totalclase; a++)
                    {
                        if (auxi[a] == mayorfinal)
                        {
                            laplace2[i, 1] = valorauxi[a];
                        }
                    }

                    mayorfinal = 0;
                    calculo2 = 1;

                } // termina for 

                //se obtiene a cuantos registros se acertaron
                int total = 0;
                for (int i = 1; i <= evaluar; i++)
                {
                    if (laplace[i, 1] == laplace2[i, 1])
                    {
                        total = total + 1;
                    }
                }

                decimal[,] matrizc = new decimal[totalclase + 3, totalclase + 3];
                decimal porcentaje = 0;
                decimal[] metricas = new decimal[5];
                decimal[,] metricas2 = new decimal[totalclase + 1, 4];
                string[,] metricas3 = new string[totalclase + 2, 5];


                denominador = fila - evaluar;
                total_elementos.Text = evaluar.ToString() + "  100%";
                porcentaje = (total * 100) / evaluar;
                total_aciertos.Text = total.ToString() + "  " + porcentaje.ToString() + "%";

                decimal sumar = 0;

                //se forma la matriz de confusion
                for (int i = 1; i <= evaluar; i++)
                {
                    if (laplace[i, 1] == laplace2[i, 1])
                    {
                        for (int j = 1; j <= totalclase; j++)
                        {
                            if (laplace[i, 1] == clases[j, 1])
                            {
                                sumar = matrizc[j, j];
                                sumar = sumar + 1;
                                matrizc[j, j] = sumar;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 1; j <= totalclase; j++)
                        {
                            if (laplace[i, 1] == clases[j, 1])
                            {
                                for (int k = 1; k <= totalclase; k++)
                                {
                                    if (laplace2[i, 1] == clases[k, 1])
                                    {
                                        sumar = matrizc[j, k];
                                        sumar = sumar + 1;
                                        matrizc[j, k] = sumar;
                                    }
                                }
                            }
                        }
                    }
                }

                // se ingresa cuantos fue la probabilidad de cadaa clase y cual fue lo real de cada clase
                for (int j = 1; j <= totalclase; j++)
                {
                    for (int k = 1; k <= totalclase; k++)
                    {
                        matrizc[j, totalclase + 1] = matrizc[j, totalclase + 1] + matrizc[j, k];
                        matrizc[totalclase + 1, j] = matrizc[totalclase + 1, j] + matrizc[k, j];
                    }
                }
                matrizc[totalclase + 1, totalclase + 1] = evaluar;

                // se obtiene la presicion de cada clase
                for (int j = 1; j <= totalclase; j++)
                {
                    if (matrizc[j, totalclase + 1] == 0)
                    {
                        metricas2[j, 1] = 0;
                    }
                    else
                    {
                        metricas2[j, 1] = matrizc[j, j] / matrizc[j, totalclase + 1];
                    }

                }

                //se obtiene el recall de cada clase
                for (int j = 1; j <= totalclase; j++)
                {
                    if (matrizc[totalclase + 1, j] == 0)
                    {
                        metricas2[j, 2] = 0;
                    }
                    else
                    {
                        metricas2[j, 2] = matrizc[j, j] / matrizc[totalclase + 1, j];
                    }
                }
                decimal diagonal = 0;

                //se determina la medida f1
                for (int j = 1; j <= totalclase; j++)
                {
                    if (metricas2[j, 1] == 0 || metricas2[j, 2] == 0)
                    {
                        metricas2[j, 3] = 0;
                    }
                    else
                    {
                        metricas2[j, 3] = (2 * metricas2[j, 1] * metricas2[j, 2]) / (metricas2[j, 1] + metricas2[j, 2]);
                    }
                    diagonal = diagonal + matrizc[j, j];
                }
                diagonal = diagonal / evaluar;
                accuracy_final.Text = decimal.Round(diagonal, 8).ToString();


                metricas3[1, 1] = " ";
                metricas3[1, 2] = "Presision";
                metricas3[1, 3] = "Recall";
                metricas3[1, 4] = "Medida F1";

                //se guarda las metricas en tipo string
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 2; k <= totalclase + 1; k++)
                    {
                        if (j != 1)
                        {
                            metricas3[k, j] = metricas2[k - 1, j - 1].ToString();
                        }
                    }
                }

                for (int k = 2; k <= totalclase + 1; k++)
                {
                    metricas3[k, 1] = clases[k - 1, 1];
                }

                //se crea datagrid para mostrar las metricas
                DataGridView dgv = new DataGridView();
                DataTable Tabla = new DataTable();
                DataRow Renglon;

                dgv.Size = new Size(450, 150);
                dgv.Location = new Point(40, 100);
                this.Controls.Add(dgv);

                for (int j = 1; j <= 4; j++)
                {
                    Tabla.Columns.Add(new DataColumn(metricas3[1, j].ToString()));

                    //Tabla.Width = 118;
                    //dar color a encabezado de datagrid
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
                    dgv.AllowUserToAddRows = false;
                    dgv.AllowUserToDeleteRows = false;
                }

                for (int i = 2; i <= totalclase + 1; i++)
                {
                    Renglon = Tabla.NewRow();
                    for (int j = 0; j < 4; j++)
                    {
                        Renglon[j] = metricas3[i, j + 1];
                    }
                    Tabla.Rows.Add(Renglon);
                }
                dgv.DataSource = Tabla;



                //se crea datagris para mostrar matriz de confusion
                DataGridView dgv1 = new DataGridView();
                DataTable Tabla1 = new DataTable();
                DataRow Renglon1;

                dgv1.Size = new Size(450, 150);
                dgv1.Location = new Point(40, 330);
                this.Controls.Add(dgv1);

                for (int j = 1; j <= totalclase; j++)
                {
                    Tabla1.Columns.Add(new DataColumn(clases[j, 1]));

                    //Tabla.Width = 118;
                    //dar color a encabezado de datagrid
                    dgv1.EnableHeadersVisualStyles = false;
                    dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
                    dgv1.AllowUserToAddRows = false;
                    dgv1.AllowUserToDeleteRows = false;
                }

                for (int i = 1; i <= totalclase; i++)
                {
                    Renglon1 = Tabla1.NewRow();
                    for (int j = 0; j < totalclase; j++)
                    {
                        Renglon1[j] = matrizc[i, j + 1];
                    }
                    Tabla1.Rows.Add(Renglon1);
                }
                dgv1.DataSource = Tabla1;
            }  /// fin if inicio


            if (final == 1)
            {
                Array.Sort(elemento);

                //se guardan datos discretizados sin la clase
                for (int j = 1; j < col; j++)
                {
                    for (int contador1 = 1; contador1 <= evaluar; contador1++)
                    {
                        linea = elemento[contador1];
                        laplace2[contador1, j] = discretizada[linea, j];
                    }
                }

                // se guardan datos discretizados con la clase
                for (int j = 1; j <= col; j++)
                {
                    for (int contador1 = 1; contador1 <= evaluar; contador1++)
                    {
                        linea = elemento[contador1];
                        laplace[contador1, j] = discretizada[linea, j];
                    }
                }

                for (int contador1 = 1; contador1 <= evaluar; contador1++)
                {
                    nuevoelemento[elemento[contador1]] = elemento[contador1];
                }
                linea = 1;

                //se guardan datos con los que se van a evaluar
                for (int j = 1; j <= col; j++)
                {
                    for (int i = 1; i <= fila; i++)
                    {
                        if (nuevoelemento[i] != 0)
                        {
                        }
                        else
                        {
                            discretizadanueva[linea, j] = discretizada[i, j];
                            linea++;
                        }
                    }
                    linea = 1;
                }


                HashSet<string> set = new HashSet<string>();

                //se obtiene la clase sin repetir
                for (int i = 1; i <= fila - evaluar; i++)
                {
                    set.Add(discretizadanueva[i, col]);
                }

                int filaclase = 1;
                foreach (var n in set)
                {
                    clases[filaclase, 1] = n;
                    filaclase++;
                }
                totalclase = set.Count;
                int conteo = 0;


                //se obtiene cuantos valores hay de cada clase
                for (int j = 1; j <= totalclase; j++)
                {
                    for (int i = 1; i <= fila - evaluar; i++)
                    {
                        if (discretizadanueva[i, col] == clases[j, 1])
                        {
                            conteo = conteo + 1;
                        }
                    }
                    clases[j, 2] = conteo.ToString();
                    conteo = 0;
                }


                //se obtiene los atributos de cada clase sin repetir
                int nuevacolumna = 1;
                set.Clear();
                filaclase = 1;
                for (int j = 1; j <= col; j++)
                {
                    for (int i = 1; i <= fila - evaluar; i++)
                    {
                        set.Add(discretizadanueva[i, j]);
                    }

                    foreach (var n in set)
                    {
                        atributoss[filaclase, nuevacolumna] = n;
                        filaclase++;
                    }
                    atributoss[1, nuevacolumna + 1] = set.Count.ToString();

                    set.Clear();

                    filaclase = 1;
                    nuevacolumna = nuevacolumna + 2;
                }

                for (int j = 1; j < col; j++)
                {
                    for (int i = 1; i <= fila - evaluar; i++)
                    {
                        discretizadafinal[i, j] = discretizadanueva[i, j];
                    }
                }


                auxi = new decimal[totalclase + 1];
                valorauxi = new string[totalclase + 1];
                suavizado = new string[totalclase + 1, col + 2];
                mayor = new string[totalclase + 1, 3];

                //se realiza el suavizado de laplace
                for (int i = 1; i <= evaluar; i++)
                {
                    for (int k = 1; k <= totalclase; k++)
                    {
                        for (int j = 1; j < col; j++)
                        {
                            for (int m = 1; m <= fila - evaluar; m++)
                            {
                                if (laplace[i, j] == discretizadanueva[m, j] && discretizadanueva[m, col] == clases[k, 1])   /*****//////////
                                {
                                    numerador = numerador + 1;
                                }
                                auxil = auxil + 1;
                            }
                            auxil = 1;

                            numerador = numerador + 1;
                            denominador = Int32.Parse(clases[k, 2]) + Int32.Parse(atributoss[1, colum]);
                            calculo = ((decimal)numerador / (decimal)denominador);
                            calculo2 = calculo2 * calculo;
                            suavizado[k, j] = calculo.ToString();
                            suavizado[k, 1] = clases[k, 1];
                            numerador = 0;
                            colum = colum + 2;
                        }

                        calculo2 = calculo2 * (Convert.ToDecimal(clases[k, 2]) / Convert.ToDecimal(fila));
                        suavizado[k, col + 1] = calculo2.ToString();
                        colum = 2;
                        auxi[k] = calculo2;
                        valorauxi[k] = clases[k, 1];
                        calculo2 = 1;

                    }
                    //se obteiene l mayor de las evaluaciones de las distintas clases
                    decimal mayorfinal = 0;
                    int nume = 0;
                    for (int a = 1; a <= totalclase; a++)
                    {
                        if (auxi[a] > mayorfinal)
                        {
                            mayorfinal = auxi[a];
                            nume = a;
                        }

                    }
                    //se asigna la clase que se determino
                    for (int a = 1; a <= totalclase; a++)
                    {

                        if (auxi[a] == mayorfinal)
                        {
                            laplace2[i, col] = valorauxi[a];
                        }
                    }
                    mayorfinal = 0;
                    calculo2 = 1;

                } // termina for 

                //se revisa  acuantos elementos se acertaron
                int total = 0;
                for (int i = 1; i <= evaluar; i++)
                {
                    if (laplace[i, col] == laplace2[i, col])
                    {
                        total = total + 1;
                    }
                }

                decimal[,] matrizc = new decimal[totalclase + 3, totalclase + 3];
                decimal porcentaje = 0;
                decimal[] metricas = new decimal[5];
                decimal[,] metricas2 = new decimal[totalclase + 1, 4];
                string[,] metricas3 = new string[totalclase + 2, 5];


                denominador = fila - evaluar;
                total_elementos.Text = evaluar.ToString() + "  100%";
                porcentaje = (total * 100) / evaluar;
                total_aciertos.Text = total.ToString() + "  " + porcentaje.ToString() + "%";
                decimal sumar = 0;
                //se realiza la matriz de confusion
                for (int i = 1; i <= evaluar; i++)
                {
                    if (laplace[i, col] == laplace2[i, col])
                    {
                        for (int j = 1; j <= totalclase; j++)
                        {
                            if (laplace[i, col] == clases[j, 1])
                            {
                                sumar = matrizc[j, j];
                                sumar = sumar + 1;
                                matrizc[j, j] = sumar;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 1; j <= totalclase; j++)
                        {
                            if (laplace[i, col] == clases[j, 1])
                            {
                                for (int k = 1; k <= totalclase; k++)
                                {
                                    if (laplace2[i, col] == clases[k, 1])
                                    {
                                        sumar = matrizc[j, k];
                                        sumar = sumar + 1;
                                        matrizc[j, k] = sumar;
                                    }
                                }
                            }
                        }
                    }
                }
                //se obtiene el valor real de cada clase y la porobabilidad de cada clase
                for (int j = 1; j <= totalclase; j++)
                {
                    for (int k = 1; k <= totalclase; k++)
                    {
                        matrizc[j, totalclase + 1] = matrizc[j, totalclase + 1] + matrizc[j, k];
                        matrizc[totalclase + 1, j] = matrizc[totalclase + 1, j] + matrizc[k, j];
                    }
                }
                matrizc[totalclase + 1, totalclase + 1] = evaluar;

                //se determina la presicion de cada clase
                for (int j = 1; j <= totalclase; j++)

                {
                    if (matrizc[j, totalclase + 1] == 0)
                    {
                        metricas2[j, 1] = 0;
                    }

                    else
                    {
                        metricas2[j, 1] = matrizc[j, j] / matrizc[j, totalclase + 1];
                    }

                }
                //se determina el recall de cada clase
                for (int j = 1; j <= totalclase; j++)
                {
                    if (matrizc[totalclase + 1, j] == 0)
                    {
                        metricas2[j, 2] = 0;
                    }
                    else
                    {
                        metricas2[j, 2] = matrizc[j, j] / matrizc[totalclase + 1, j];
                    }

                }
                decimal diagonal = 0;
                //se determina la medida f1 de cada clase
                for (int j = 1; j <= totalclase; j++)
                {
                    if (metricas2[j, 1] == 0 || metricas2[j, 2] == 0)
                    {
                        metricas2[j, 3] = 0;
                    }
                    else
                    {
                        metricas2[j, 3] = (2 * metricas2[j, 1] * metricas2[j, 2]) / (metricas2[j, 1] + metricas2[j, 2]);
                    }
                    diagonal = diagonal + matrizc[j, j];
                }
                diagonal = diagonal / evaluar;

                accuracy_final.Text = decimal.Round(diagonal, 8).ToString();

                metricas3[1, 1] = " ";
                metricas3[1, 2] = "Presision";
                metricas3[1, 3] = "Recall";
                metricas3[1, 4] = "Medida F1";
                //se guardan las metricas en formato string
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 2; k <= totalclase + 1; k++)
                    {
                        if (j != 1)
                        {
                            metricas3[k, j] = metricas2[k - 1, j - 1].ToString();

                        }
                    }
                }

                for (int k = 2; k <= totalclase + 1; k++)
                {
                    metricas3[k, 1] = clases[k - 1, 1];
                }

                //se crea datagrid para mostrar las metricas
                DataGridView dgv = new DataGridView();
                DataTable Tabla3 = new DataTable();
                DataRow Renglon;

                dgv.Size = new Size(450, 150);
                dgv.Location = new Point(40, 100);
                this.Controls.Add(dgv);

                for (int j = 1; j <= 4; j++)
                {
                    Tabla3.Columns.Add(new DataColumn(metricas3[1, j]).ToString());

                    //Tabla.Width = 118;
                    //dar color a encabezado de datagrid
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
                    dgv.AllowUserToAddRows = false;
                    dgv.AllowUserToDeleteRows = false;
                }

                for (int i = 2; i <= totalclase + 1; i++)
                {
                    Renglon = Tabla3.NewRow();
                    for (int j = 0; j < 4; j++)
                    {
                        Renglon[j] = metricas3[i, j + 1];
                    }
                    Tabla3.Rows.Add(Renglon);
                }
                dgv.DataSource = Tabla3;


                //se crea datagrid para mostrar la matriz de confusion
                DataGridView dgv1 = new DataGridView();
                DataTable Tabla1 = new DataTable();
                DataRow Renglon1;

                dgv1.Size = new Size(450, 150);
                dgv1.Location = new Point(40, 330);
                this.Controls.Add(dgv1);

                for (int j = 1; j <= totalclase; j++)
                {
                    Tabla1.Columns.Add(new DataColumn(clases[j, 1]));

                    //Tabla.Width = 118;
                    //dar color a encabezado de datagrid
                    dgv1.EnableHeadersVisualStyles = false;
                    dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
                    dgv1.AllowUserToAddRows = false;
                    dgv1.AllowUserToDeleteRows = false;
                }

                for (int i = 1; i <= totalclase; i++)
                {
                    Renglon1 = Tabla1.NewRow();
                    for (int j = 0; j < totalclase; j++)
                    {
                        Renglon1[j] = matrizc[i, j + 1];
                    }
                    Tabla1.Rows.Add(Renglon1);
                }
                dgv1.DataSource = Tabla1;
            }
        }
    }
}
