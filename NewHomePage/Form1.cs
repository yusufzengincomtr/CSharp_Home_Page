using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewHomePage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool opc = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!opc)
            {
                this.Opacity += 0.009;
            }
            if (this.Opacity == 1.0)
            {
                opc = true;
            }
            if (opc)
            {
                this.Opacity -= 0.009;
                if (this.Opacity==0)
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    timer1.Enabled = false;
                    this.Hide();
                }
            }
        }
    }
}
