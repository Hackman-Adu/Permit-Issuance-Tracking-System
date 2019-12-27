using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMA_Application.Properties;
using Bunifu.Framework.UI;

namespace SMA_Application
{
    public partial class Department : Form
    {
        Settings st = new Settings();
        Form1 form = new Form1();
        public Department()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Department_KeyDown;

 
        }

        void Department_KeyDown(object sender, KeyEventArgs e)
        {
            form.Form1_KeyDown(this, e);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            deptName.Text = st.DepartmentName.ToUpper();
            proName.Text = st.ProjectName.ToUpper();
            deptRegion.Text = st.RegionName.ToUpper();
            EmailA.Text= st.EmailAddress.ToUpper();
            if(st.Telephone!=0)
            {
                tel.Text = st.Telephone.ToString();
            }
            else
            {
                tel.Text = "";
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if(checkBox1.Checked==true)
           {
               foreach (Control c in groupBox1.Controls)
               {
                   if (c is BunifuMetroTextbox)
                   {
                       BunifuMetroTextbox tt = c as BunifuMetroTextbox;
                       tt.KeyPress += tt_KeyPress;
                   }
               }
           }
            else if(checkBox1.Checked==false)
           {
               foreach (Control c in groupBox1.Controls)
               {
                   if (c is BunifuMetroTextbox)
                   {
                       BunifuMetroTextbox ttt = c as BunifuMetroTextbox;
                       ttt.KeyPress += ttt_KeyPress;
                   }
               }
           }
        }

        void ttt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        void tt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            st.DepartmentName = deptName.Text;
            st.ProjectName = proName.Text;
            st.RegionName = deptRegion.Text;
            st.EmailAddress = EmailA.Text;
            if(tel.Text=="")
            {
                int i = 0;
                st.Telephone = i;
            }
            else
            {
                st.Telephone = long.Parse(tel.Text);
            }
            st.Save();

        }

       

        

    }
}
