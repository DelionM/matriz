﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matriz.FORMS
{
    public partial class FormSuma : Form
    {
       
        public FormSuma()
        {
            InitializeComponent();
            LoadTheme();
        }
        //matriz a 
        int a1, a2, a3, b1, b2, b3, c1, c2, c3;
        //matriz b
        int Ba1, Ba2, Ba3, Bb1, Bb2, Bb3, Bc1, Bc2, Bc3;
        private void LoadTheme()
        {
            foreach (Control btnResolver in this.Controls)
            {
                if (btnResolver.GetType() == typeof(Button))
                {
                    Button btn = (Button)btnResolver;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void btnaleatorio_Click(object sender, EventArgs e)
        {
            aleatorio();
        }
        private void aleatorio()
        {
            Random rnd = new Random();

            txbA1.Text = Convert.ToString(rnd.Next(-100, 100));
            txbA2.Text = Convert.ToString(rnd.Next(-10, 100));
            txtA3.Text = Convert.ToString(rnd.Next(-100, 100));

            txtb1.Text = Convert.ToString(rnd.Next(-100, 100));
            txtb2.Text = Convert.ToString(rnd.Next(-100, 100));
            txtb3.Text = Convert.ToString(rnd.Next(-100, 100));

            txtc1.Text = Convert.ToString(rnd.Next(-100, 100));
            txtc2.Text = Convert.ToString(rnd.Next(-100, 100));
            txtc3.Text = Convert.ToString(rnd.Next(-100, 100));
            txtBA1.Text = Convert.ToString(rnd.Next(-100, 100));
            txtBA2.Text = Convert.ToString(rnd.Next(-100, 100));
            txtBA3.Text = Convert.ToString(rnd.Next(-100, 100));

            txtBB1.Text = Convert.ToString(rnd.Next(-100, 100));
            txtBB2.Text = Convert.ToString(rnd.Next(-100, 100));
            txtBB3.Text = Convert.ToString(rnd.Next(-100, 100));

            txtCC1.Text = Convert.ToString(rnd.Next(-100, 100));
            txtCC2.Text = Convert.ToString(rnd.Next(-100, 100));
            txtCC3.Text = Convert.ToString(rnd.Next(-100, 100));
        }

        private void ResC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloqueaNum(e);
        }

        //sumas
        int sra1 = 0, sra2 = 0, sra3 = 0, srb1 = 0, srb2 = 0, srb3 = 0, src1 = 0, src2 = 0, src3 = 0;

        private void btnSalir_Click(object sender, EventArgs e)
        {
           Salir();
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.txbA1.Focus();
            }
        }

       
           private void btnBorra_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void Convertir()
        {
            //MATRIZ A 
            a1 = Convert.ToInt32(txbA1.Text);
            a2 = Convert.ToInt32(txbA2.Text);
            a3 = Convert.ToInt32(txtA3.Text);

            b1 = Convert.ToInt32(txtb1.Text);
            b2 = Convert.ToInt32(txtb2.Text);
            b3 = Convert.ToInt32(txtb3.Text);

            c1 = Convert.ToInt32(txtc1.Text);
            c2 = Convert.ToInt32(txtc2.Text);
            c3 = Convert.ToInt32(txtc3.Text);

            //MATRIZ B
            Ba1 = Convert.ToInt32(txtBA1.Text);
            Ba2 = Convert.ToInt32(txtBA2.Text);
            Ba3 = Convert.ToInt32(txtBA3.Text);

            Bb1 = Convert.ToInt32(txtBB1.Text);
            Bb2 = Convert.ToInt32(txtBB2.Text);
            Bb3 = Convert.ToInt32(txtBB3.Text);

            Bc1 = Convert.ToInt32(txtCC1.Text);
            Bc2 = Convert.ToInt32(txtCC2.Text);
            Bc3 = Convert.ToInt32(txtCC3.Text);
        }
        private void Sumas()
        {
            sra1 = a1 + Ba1;
            sra2 = a2 + Ba2;
            sra3 = a3 + Ba3;
            srb1 = b1 + Bb1;
            srb2 = b2 + Bb2;
            srb3 = b3 + Bb3;
            src1 = c1 + Bc1;
            src2 = c2 + Bc2;
            src3 = c3 + Bc3;
        }

        private void ResultadosCombertir()
        {
            ResA1.Text = Convert.ToString(sra1);
            ResA2.Text = Convert.ToString(sra2);
            ResA3.Text = Convert.ToString(sra3);

            ResB1.Text = Convert.ToString(srb1);
            ResB2.Text = Convert.ToString(srb2);
            ResB3.Text = Convert.ToString(srb3);

            ResC1.Text = Convert.ToString(src1);
            ResC2.Text = Convert.ToString(src2);
            ResC3.Text = Convert.ToString(src3);
        }

       
        private void limpiar()
        {
            txbA1.Clear();
            txbA2.Clear();
            txtA3.Clear();
            txtb1.Clear();
            txtb2.Clear();
            txtb3.Clear();
            txtc1.Clear();
            txtc2.Clear();
            txtc3.Clear();
            txtBA1.Clear();
            txtBA2.Clear();
            txtBA3.Clear();
            txtBB1.Clear();
            txtBB2.Clear();
            txtBB3.Clear();
            txtCC1.Clear();
            txtCC2.Clear();
            txtCC3.Clear();
            ResA1.Clear();
            ResA2.Clear();
            ResA3.Clear();
            ResB1.Clear();
            ResB2.Clear();
            ResB3.Clear();
            ResC1.Clear();
            ResC2.Clear();
            ResC3.Clear();
        }
        private void btnResolver_Click(object sender, EventArgs e)
        {
            try
            {
                Convertir();
                Sumas();
                ResultadosCombertir();
        }
            catch 
            {
                MessageBox.Show("Por Favor Ingresa Todos Los Datos Correspondientes", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public static void BloqueaNum(KeyPressEventArgs pE)
        {
            //Para obligar a que sólo se introduzcan números

            if (Char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar)) //permitir teclas de control como retroceso
            {
                pE.Handled = false;
            }
            else if (Char.IsWhiteSpace(pE.KeyChar)) //no permitir teclas de control como espacio
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '-')//permitir tecla -
            {
                pE.Handled = false;
            }
            else if (Char.IsPunctuation(pE.KeyChar))// no permitir teclas de puntuacion
            {
                pE.Handled = true;
            }
            else //el resto de teclas pulsadas se desactivan
            {
                pE.Handled = true;
            }
        }
    }
}
