using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matriz
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempindex;
        private Form activeForm;
        //constructor
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }
        //metodos
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempindex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempindex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelImagen.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control btnSuma in panelMenu.Controls)
            {
                if (btnSuma.GetType() == typeof(Button))
                {
                    btnSuma.BackColor = Color.FromArgb(51, 51, 76);
                    btnSuma.ForeColor = Color.Gainsboro;
                    btnSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void btnSuma_Click(object sender, EventArgs e)
        {
            OpenChildForm(new matriz.FORMS.FormSuma(), sender);
            lblTitle.Text = "Suma de matrices";
            // ActivateButton(sender);
        }

        private void btnResta_Click(object sender, EventArgs e)
        {

            OpenChildForm(new matriz.Forms.Resta(), sender);
            //ActivateButton(sender);
            lblTitle.Text = "Resta de matrices";

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            OpenChildForm(new matriz.Forms.Producto(), sender);
            //ActivateButton(sender);
            lblTitle.Text = "Multiplicación de matrices";

        }

        private void btnEscala_Click(object sender, EventArgs e)
        {
            OpenChildForm(new matriz.Forms.Escala(), sender);
            //ActivateButton(sender);
            lblTitle.Text = "Escala de matrices";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new matriz.Forms.Trasposicion(), sender);
            // ActivateButton(sender);
            lblTitle.Text = "Transposición de matrices";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new matriz.Forms.Introducción(), sender);
            lblTitle.Text = "Introducción a matrices";

        }

        private void pictureBox7_Click(object sender, EventArgs e)
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
                this.btnSuma.Focus();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }//ToLonDateString

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Fecha y Hora al día de hoy";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
    }
}
