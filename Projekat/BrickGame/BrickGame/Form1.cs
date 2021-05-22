using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int loptaX = 5;
        int loptaY = 5;
        int poeni = 0;


        private void kretanjeLopte()
        {
            lopta.Left += loptaX;
            lopta.Top += loptaY;

            if (lopta.Left + lopta.Width> ClientSize.Width|| lopta.Left<0)
            {
                loptaX = -loptaX;
            }
            if(lopta.Top<0|| lopta.Bounds.IntersectsWith(pokret.Bounds))
            {
                loptaY = -loptaY;
            }
        }

        private void brojPoena()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "cigla")
                {
                    if (lopta.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        loptaY = -loptaY;
                        poeni++;
                        label1.Text = "Rezultat: "+ poeni;
                    }
                }
            }
        }

        private void kraj()
        {
            if (poeni > 17)
            {
                timer1.Stop();
                MessageBox.Show("Pobedili ste!");
            }
            if (lopta.Top + lopta.Width > ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Kraj igre!");
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && pokret.Left>0)
            {
                pokret.Left -= 5;
            }
            if (e.KeyCode == Keys.Right && pokret.Right < 800)
            {
                pokret.Left += 5;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kretanjeLopte();
            brojPoena();
            kraj();
        }

       
    }
}
