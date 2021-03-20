﻿using PR3_EQ5_TM.Componentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace PR3_EQ5_TM
{
    public partial class Pantalla : Form
    {
        private List<Grafica> Graficas;

        public Pantalla()
        {
            InitializeComponent();
        }

        private void Pantalla_Load(object sender, EventArgs e)
        {
            int x = 5, y = 5;
            Graficas = new List<Grafica>();

            for (int i = 0; i < 28; i++) 
            {
              
                Graficas.Add(new Grafica());
                switch (i)
                {
                    case 7:
                        x = 5;
                        y = Graficas[i].Height + 10;
                        Graficas[i].Left = x;
                        Graficas[i].Top  = y;
                        break;
                    case 14:
                        x = 5;
                        y = Graficas[i].Height * 2 + 15;
                        Graficas[i].Left = x;
                        Graficas[i].Top = y;
                        break;
                    case 21:
                        x = 5;
                        y = Graficas[i].Height * 3 + 20;
                        Graficas[i].Left = x;
                        Graficas[i].Top = y;
                        break;
                    default:
                        Graficas[i].Top = y;
                        Graficas[i].Left = x;
                        break;
                }

                x += Graficas[i].Width + 5;
                pnlGraficas.Controls.Add(Graficas[i]);
            }

            #region version de Alan
            //int i = 0;
            //int Max = 28;
            //int Max2 = 5;
            //g1 = new List<Grafica>(Max);
            //int Ph = (pnlGraficas.Height) / 4, Pw = (pnlGraficas.Width-10) / 7;
            //int A = 0;
            //int H = 0;
            //Random Alea = new Random();
            //int[] NumAlea = new int[Max2];
            //int[] NumAlea2 = { 1,2,8,5,4} ;
            //int iA=0;
            //while (iA < Max2)
            //{
            //    NumAlea[iA] = Convert.ToInt32(Alea.Next(1, 20));
            //    iA++;
            //}

            //while (i < Max)
            //{
            //    if (i==7 || i==14 || i==21)
            //    {
            //        A++;
            //        H = 0;
            //    }
            //    g1.Add(new Grafica(Pw-10, Ph-20, NumAlea2));
            //    g1[i].Location = new Point(Pw * H, 5+ Ph * A);
            //    pnlGraficas.Controls.Add(g1[i]);
            //    H++;
            //    i++;
            //}
            #endregion

        }
    }
}
