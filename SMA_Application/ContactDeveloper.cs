using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMA_Application.Properties;

namespace SMA_Application
{
    public partial class ContactDeveloper : Form
    {
        int co;
        Settings st = new Settings();
        public ContactDeveloper()
        {
            InitializeComponent();
            co = 0;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string unlockingCode = "itworldinnovate2019";
            if(unlock.Text==unlockingCode)
            {
                st.ApplicationCount -= 5000;
                st.Save();
                MessageBox.Show("Unlocking Successfully Applied!!!", "Unlocking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("INVALID UNLOCKING CODE!!!", "Unlocking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                unlock.Text = "";

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AppDeveloper app = new AppDeveloper();
            app.ShowDialog();
        }

        private void ContactDeveloper_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Start();
            t.Tick += t_Tick;
        }

        void t_Tick(object sender, EventArgs e)
        {
           if(co==0)
           {
               pictureBox1.Visible = false;
               co = 1;
           }
           else if(co==1)
           {
               pictureBox1.Visible = true;
               co = 0;
           }
        }
    }
}
