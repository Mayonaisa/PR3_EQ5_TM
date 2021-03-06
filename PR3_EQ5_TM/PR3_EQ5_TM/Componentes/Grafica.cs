using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR3_EQ5_TM.Componentes
{
    class Grafica : Panel
    {
        // Variables globales

        private int[] numerosAleatorios; // Guarda los numerosAleatorios generados aleatoriamente
        private Rectangle[] rectangulosGraficados; // Grafica los numerosAleatorios del arreglo
        private int aux, avx, ba, bb, bc, bd, be, rectanguloMenor = -1, rectanguloMayor = -1, max;
        private double pv;
        private bool band;

        // Gráficos
        private Pen p;
        private Graphics g;
        private Brush pincelPrincipal, pincelSecundario;
        private Color colorPrimario, colorSecundario, colorFondo;

        public Grafica()
        // : base(parametros pero no tiene)
        {
            Colores();
            this.DoubleBuffered = true;
            this.Width = 150;
            this.Height = 100;
            this.Paint += new PaintEventHandler(Grafica_Paint);
            this.BackColor = colorFondo;
            //this.DoubleBuffered = true;

            // 10 int[] valoresIniciales = { 10, 4, 8, 9, 1, 1, 10, 9, 7, 9 };
            // 20 int[] valoresIniciales = { 18, 2, 5, 20, 4, 1, 20, 19, 12, 2, 9, 15, 9, 3, 7, 9, 4, 20, 16, 5 };
            // 30 
            int[] valoresIniciales = { 13, 11, 9, 5, 29, 23, 17, 21, 15, 3, 20, 3, 13, 23, 15, 30, 11, 16, 6, 29, 9, 11, 21, 11, 9, 17, 19, 7, 23, 15, 12, 13, 16 };
            // 40 int[] valoresIniciales = { 35, 37, 18, 6, 2, 32, 33, 23, 33, 17, 28, 6, 3, 9, 15, 10, 20, 35, 36, 17, 11, 31, 30, 3, 36, 32, 33, 32, 9, 36, 40, 25, 18, 26, 1, 34, 13, 26, 25, 9 };
            // 50 int[] valoresIniciales = { 37, 4, 37, 31, 8, 26, 32, 47, 19, 28, 35, 35, 4, 1, 31, 20, 3, 39, 21, 39, 32, 29, 22, 10, 16, 35, 12, 11, 18, 3, 17, 30, 25, 39, 29, 49, 17, 12, 18, 20, 37, 40, 46, 21, 17, 43, 5, 46, 23, 41 };

            max = valoresIniciales.Length;
            numerosAleatorios = valoresIniciales;
            this.Refresh();
            DibujarRectangulos();
           
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Grafica
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Grafica_Paint_1);
            this.ResumeLayout(false);

        }

        private void Grafica_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public Grafica(int alto, int ancho, int[] valores)
        // : base(parametros pero no tiene) 
        {
            this.Width = alto;
            this.Height = ancho;
            this.Paint += new PaintEventHandler(Grafica_Paint);
            this.BackColor = Color.White;
            numerosAleatorios = valores;
            DibujarRectangulos();
        }

        // Graficación

        private void Colores()
        {
            colorPrimario = new Color();
            colorPrimario = Color.DarkOrange;
            colorSecundario = new Color();
            colorSecundario = Color.FromArgb(0, 255, 151);
            colorFondo = new Color();
            colorFondo = Color.FromArgb(27, 38, 49);
        }

        private void DibujarRectangulos() 
        {
            rectangulosGraficados = new Rectangle[numerosAleatorios.Length]; // Crea el arreglo de rectangulos
            for (int numRec = 0; numRec < numerosAleatorios.Length; numRec++) // Genera los rectangulos con la lista de numerosAleatorios
            {
                if (numRec == 0)
                    rectangulosGraficados[numRec] = new Rectangle(0, this.Height / max * numRec + 1, this.Width / max * numerosAleatorios[numRec], this.Height / numerosAleatorios.Length - 2);
                else
                rectangulosGraficados[numRec] = new Rectangle(0, this.Height / max * numRec + 1, this.Width / max * numerosAleatorios[numRec], this.Height / numerosAleatorios.Length - 2);
            }
        }

        private void Animacion(int k, int w)
        {
            rectanguloMenor = k;
            rectanguloMayor = w;
            int distancia = rectangulosGraficados[rectanguloMayor].Top -rectangulosGraficados[rectanguloMayor].Top;
            int yk = rectangulosGraficados[rectanguloMenor].Top, 
                yw = rectangulosGraficados[rectanguloMayor].Top;

            while (rectangulosGraficados[rectanguloMenor].Top < yw)
            {
                
                rectangulosGraficados[rectanguloMenor].Location = new Point(0,(rectangulosGraficados[rectanguloMenor].Top) + this.Height / max * 1);
                rectangulosGraficados[rectanguloMayor].Location = new Point(0,(rectangulosGraficados[rectanguloMayor].Top) - this.Height / max * 1);

                this.Invoke(new MethodInvoker(Refresh));
                //Refresh();

                //g.FillRectangle(pincelSecundario, rectangulosGraficados[rectanguloMenor]);
                //g.FillRectangle(pincelSecundario, rectangulosGraficados[rectanguloMayor]);

                Thread.Sleep(10);

                //Invalidate();
            }
            //g.FillRectangle(pincelPrincipal, rectangulosGraficados[rectanguloMayor]);
            //g.FillRectangle(pincelPrincipal, rectangulosGraficados[rectanguloMayor]);
            rectanguloMenor = -1;
            rectanguloMayor = -1;
        } // Anima xd


        // Ordenación

        public void Ordenar(string métodoSelecionado) 
        {
            switch (métodoSelecionado)
            {
                case "Burbuja Tradicional":
                    BurbujaT();
                    break;
                case "Burbuja Mejorada":
                    BurbujaM();
                    break;
                case "Quicksort":
                    Quicksort(0, numerosAleatorios.Length - 1);
                    break;
                case "Shell":
                    Shell();
                    break;
                case "Inserción Simple":
                    Baraja();
                    break;
                case "Inserción Binaria":
                    Binario();
                    break;
                default:
                    MessageBox.Show("Selecione un método de ordenamiento");
                    break;
            }
            this.Invoke(new MethodInvoker(Refresh));
            //Refresh();
        }

        // Métodos

        #region Código de los métodos

        public void BurbujaT()
        {
            // Ordena la lista
            for (ba = 1; ba < numerosAleatorios.Length; ba++)
            {
                for (bb = numerosAleatorios.Length - 1; bb >= ba; bb--)
                {
                    if (numerosAleatorios[bb - 1] > numerosAleatorios[bb]) // Intercambio de datos
                    {
                        aux = numerosAleatorios[bb - 1];
                        Animacion(bb - 1, bb);
                        numerosAleatorios[bb - 1] = numerosAleatorios[bb];
                        numerosAleatorios[bb] = aux;
                        DibujarRectangulos();
                    }
                }
            }
        }              // Burbuja tradicional // Sí
        public void BurbujaM()
        {
            // Ordena la lista
            band = true; bd = 0;
            do
            {
                bd++;
                band = true;
                for (ba = 0; ba < numerosAleatorios.Length - bd; ba++)
                {
                    if (numerosAleatorios[ba] > numerosAleatorios[ba + 1])
                    {
                        aux = numerosAleatorios[ba];
                        Animacion(ba, ba + 1);
                        numerosAleatorios[ba] = numerosAleatorios[ba + 1];
                        numerosAleatorios[ba + 1] = aux;
                        DibujarRectangulos();
                        band = false;
                    }
                }
            }
            while (!band);
        }              // Burbuja mejorado // Sí
        public void Shell()
        {
            // Ordena la lista
            ba = numerosAleatorios.Length / 2;
            while (ba > 0)
            {
                band = true;
                while (band)
                {
                    band = false;
                    bb = 1;
                    while (bb <= (numerosAleatorios.Length - ba))
                    {
                        if (numerosAleatorios[bb - 1] > numerosAleatorios[(bb - 1) + ba]) // Intercambio de datos
                        {
                            aux = numerosAleatorios[(bb - 1) + ba];
                            Animacion(bb - 1, (bb - 1) + ba);
                            numerosAleatorios[(bb - 1) + ba] = numerosAleatorios[bb - 1];
                            numerosAleatorios[(bb - 1)] = aux;
                            DibujarRectangulos();
                            band = true;
                        }
                        bb++;
                    }
                }
                ba = ba / 2;
            }
        }                 // Shell // Sí
        public void Quicksort(int p, int u)
        {
            // Ordena la lista
            bc = (p + u) / 2;
            pv = numerosAleatorios[bc];
            ba = p;
            bb = u;
            do
            {
                while (numerosAleatorios[ba] < pv) ba++;
                while (numerosAleatorios[bb] > pv) bb--;
                if (ba <= bb)
                {
                    aux = numerosAleatorios[ba];
                    Animacion(ba, bb);
                    numerosAleatorios[ba] = numerosAleatorios[bb];
                    numerosAleatorios[bb] = aux;
                    DibujarRectangulos();
                    ba++;
                    bb--;
                }
            } while (ba <= bb);

            if (p < bb)
            {
                Quicksort(p, bb);
            }
            if (ba < u)
            {
                Quicksort(ba, u);
            }

        } // Quicksort // Sí
        public void Baraja()
        {
            // Ordena la lista
            for (ba = 0; ba < numerosAleatorios.Length; ba++)
            {
                aux = numerosAleatorios[ba];
                bc = ba - 1;
                while ((bc >= 0) && (aux < numerosAleatorios[bc])) // Intercambio de numerosAleatorios
                {
                    Animacion(bc, bc + 1);
                    numerosAleatorios[bc + 1] = numerosAleatorios[bc];
                    DibujarRectangulos();
                    bc--;
                }
                numerosAleatorios[bc + 1] = aux;
            }
        }                // Inserción directa // Sí
        public void Binario()
        {
            // Ordena la lista

            for (int ba = 0; ba < numerosAleatorios.Length; ba++)
            {
                aux = numerosAleatorios[ba];
                avx = ba;
                be = 0;
                bd = ba - 1;
                while (be <= bd)
                {
                    bc = (be + bd) / 2;
                    if (aux <= numerosAleatorios[bc])
                    {
                        bd = bc - 1;
                    }
                    else
                    {
                        be = bc + 1;
                    }
                }
                for (int bb = ba - 1; bb >= be; bb--)
                {
                    numerosAleatorios[bb + 1] = numerosAleatorios[bb];
                }
                Animacion(be, avx);
                numerosAleatorios[be] = aux;
                DibujarRectangulos();
            }
        }               // Inserción binaria // Sí

        #endregion

        // Eventos

        private void Grafica_Paint(object sender, PaintEventArgs e)
        {
            // Crea los graficos
            g = e.Graphics;
            p = new Pen(new SolidBrush(Color.Black));
            pincelPrincipal = new SolidBrush(colorPrimario);
            pincelSecundario = new SolidBrush(colorSecundario);

            // Dibuja rectangulo
            g.DrawRectangles(p, rectangulosGraficados);
            g.FillRectangles(pincelPrincipal, rectangulosGraficados);

            if (rectanguloMenor != -1 && rectanguloMayor != -1)
            {
                g.FillRectangle(pincelSecundario, rectangulosGraficados[rectanguloMenor]);
                g.FillRectangle(pincelSecundario, rectangulosGraficados[rectanguloMayor]);
            }
        }
    }
}