using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zaiwoneproje
{
    public partial class Form30 : Form
    {
        public Form30()
        {
            InitializeComponent();
        }
        bool islem = false;
        double i = 0.0;
        private void Form30_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1.5;
            progressBarControl1.EditValue = i;


            if (!islem)
            {
                this.Opacity += 0.06;
            }
            if (this.Opacity == 1.0)
            {
                islem = true;
            }
            if (islem == true)
            {
                this.Opacity -= 0.06;
                if (this.Opacity == 0)
                {
                    Form1 gtr = new Form1();
                    gtr.Show();
                    timer1.Enabled = false;
                }
            }
        }
    }
}
