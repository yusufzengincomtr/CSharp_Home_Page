using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Guna.UI2.WinForms;
using CefSharp;
using CefSharp.WinForms;
namespace NewHomePage
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void degerler()
        {
            lbldate.Text = DateTime.Now.ToShortDateString();
            label11.Text = DateTime.Now.ToShortTimeString();
            string api = "0fd56bbbea6bd4eac0800ce02e0ab227";
            string con = "https://api.openweathermap.org/data/2.5/weather?q=" + comboBox1.Text + "&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(con);
            var sıcaklık = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var ruzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            lblsıcaklık.Text = sıcaklık.ToString();
            lblruzgar.Text = ruzgar + " m/s";
            lblnem.Text = nem + " %";
            lbldurum.Text = durum;
            lblsc.Text = sıcaklık.ToString();
        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 142, b.Location.Y - 30);
            imgSlide.SendToBack();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_CheckedChanged_1(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }
      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int sayı = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
          //  sayı++;
          //  gunaCircleProgressBar1.Value = sayı;
            


        }
        ChromiumWebBrowser chrome;
        private void Form2_Load(object sender, EventArgs e)
        {
            CefSettings ayar = new CefSettings();
            if (Cef.IsInitialized == false)
            {
                Cef.Initialize(ayar);
                chrome = new ChromiumWebBrowser("");

            }
            this.pnlhaber.Controls.Add(chrome);
            chrome.Load("https://www.haberler.com/");

            timersaniye.Start();
            timerdk.Start();
            timerst.Start();
            lbldate.Text = DateTime.Now.ToShortDateString();
            label11.Text = DateTime.Now.ToShortTimeString();
            string api = "0fd56bbbea6bd4eac0800ce02e0ab227";
            string con = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(con);
            var sıcaklık = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var ruzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            lblsıcaklık.Text = sıcaklık.ToString();
            lblruzgar.Text = ruzgar + " m/s";
            lblnem.Text = nem + " %";
            lbldurum.Text = durum;
            lblsc.Text = sıcaklık.ToString();

            pnlsaat.Visible = true;
            pnlhava.Visible = false;
            pnlhaber.Visible = false;
            mapControl1.Visible = false;
        }
       
        private void timersaniye_Tick(object sender, EventArgs e)
        {
        
            string a = DateTime.Now.Second.ToString();
            lblsecond.Text = a;
            gunaCircleProgressBar3.Value = int.Parse(a.ToString());

        }

        private void timerdk_Tick(object sender, EventArgs e)
        {
            string b = DateTime.Now.Minute.ToString();
            lblmınut.Text = b;
            gunaCircleProgressBar2.Value = int.Parse(b.ToString());
        }

        private void timerst_Tick(object sender, EventArgs e)
        {
            string c = DateTime.Now.Hour.ToString();
            lblsaat.Text = c;
            gunaCircleProgressBar1.Value = int.Parse(c.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            degerler();

            lblcıty.Text = comboBox1.SelectedItem + ", TR";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
            pnlhava.Visible = true;
            pnlsaat.Visible = false;
            pnlhaber.Visible = false;
            mapControl1.Visible = false;

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlsaat.Visible = true;
            pnlhava.Visible = false;
            pnlhaber.Visible = false;
            mapControl1.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            pnlhaber.Visible = true;
            pnlsaat.Visible = false;
            pnlhava.Visible = false;
            mapControl1.Visible = false;
          
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            pnlhaber.Visible = false;
            pnlsaat.Visible = false;
            pnlhava.Visible = false;
            mapControl1.Visible = true;
        }
    }
}
