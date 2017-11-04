using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalizatorauto
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double L = 0.04;
            this.label1.Text = "L";
            this.textBox1.Text = Convert.ToString(L);
            this.label2.Text = "U";
            this.textBox2.Text = "1,5";
            this.label3.Text = "E";
            this.textBox3.Text = "0,45";
            this.label4.Text = "dsh";
            this.textBox4.Text = "0,004";
            this.label5.Text = "Sc";
            this.textBox5.Text = "0,7";
            this.label6.Text = "n";
            this.textBox6.Text = "1000";
            this.label7.Text = "C";
            this.textBox7.Text = "1,0";
            this.vyw.Text = "Вычислить";
            this.button2.Text = "Анимация";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            double[] p = new double[1001];
            double[] c = new double[1001];
            double h, a, b, Re, Sc, L, E, U, dsh, v = 65.0 * Math.Pow(10, -6), de;
            L = Convert.ToDouble(this.textBox1.Text);
            U = Convert.ToDouble(this.textBox2.Text);
            E = Convert.ToDouble(this.textBox3.Text);
            dsh = Convert.ToDouble(this.textBox4.Text);
            Sc = Convert.ToDouble(this.textBox5.Text);
            n = Convert.ToInt32(this.textBox6.Text);
            c[0] = Convert.ToDouble(this.textBox7.Text);
            p[0] = 0.001;
            this.textBox8.Text = null;
            chart1.Series[0].Points.Clear();
            de = (double) 4.0 * E * dsh / 6.0 /(1.0 - E);
            Re = (double) U * de /(E * v);
            a = (double) Re * Sc *( E * L /de);
            //a = 1.5;
            b = (double) 0.395 * Math.Pow(Re, 0.5) * Math.Pow(Sc, 0.3) * (4.0 * E * Math.Pow(L, 2) / Math.Pow(de, 2));
            //b = 1.0;
            h = (double) 0.1 / n;

            //this.textBox9.Text = Convert.ToString(a);
           // this.textBox10.Text = Convert.ToString(b);

            for (int i = 1; i <= c.Length; i++)
            {
                
                p[i] = p[i - 1] + h * (a * p[i - 1] - b * c[i - 1]);
                c[i] = c[i - 1] + h * (p[i - 1]);
                if (c[i] > -0.1/n)
                {
                    this.chart1.Series[0].Points.AddXY(i, c[i]);
                    this.textBox8.Text = "\n" + textBox8.Text + "\n" + Convert.ToString(c[i]);
                    
                }
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.ScrollBars = ScrollBars.Vertical;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Show();
        }
    }
}
