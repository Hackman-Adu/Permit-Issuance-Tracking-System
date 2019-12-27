using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace SMA_Application
{
    public partial class AppDeveloper : Form
    {
        public AppDeveloper()
        {
            InitializeComponent();
        }

        

        

        private void AppDeveloper_Load(object sender, EventArgs e)
        {
            foreach(Control c in groupBox1.Controls)
            {
                if(c is BunifuMetroTextbox)
                {
                    BunifuMetroTextbox t = c as BunifuMetroTextbox;
                    t.KeyPress += t_KeyPress;
                }
            }
        }

        void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://mailto:itworldinnovate@gmail.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.itworldinnovate.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
