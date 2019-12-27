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
using System.IO;

namespace SMA_Application
{
    public partial class Form1 : Form
    {
        Settings st = new Settings();
        public Form1()
        {
            InitializeComponent();
            Timer tt = new Timer();
            tt.Tick += tt_Tick;
            tt.Interval = 5;
            tt.Start();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;   
            this.ContextMenuStrip = contextMenuStrip1;
            
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] pictures = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (pictures != null)
                {
                    this.BackgroundImage = Image.FromFile(pictures[0]);
                    st.DefaultImage = pictures[0].ToString();
                    st.Save();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
          
          if (e.KeyCode == Keys.Escape)
          {
              bunifuImageButton1_Click(this, e);
          }
              
            
        }

        void tt_Tick(object sender, EventArgs e)
        {
            label1.Left -= 1;
            if(label1.Left<0-label1.Width)
            {
                label1.Left = this.Width;
            }
            label2.Text = DateTime.Now.ToLongDateString() + "  Current Time: " + DateTime.Now.ToString("hh:mm:ss");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //btn1.Enabled = false;
            ToolTip t = new ToolTip();
            t.ToolTipTitle = "SMA";
            t.SetToolTip(logout, "Logout");
            t.SetToolTip(roundPictureBox1, "Click to change image");
            t.IsBalloon = true;
            label5.Text ="[ "+ st.FirstName + " " + st.LastName+" ]";
            label6.Text = "[ " + st.UserType + "]";
            deptL.Text = st.DepartmentName.ToUpper();
           
            this.BackgroundImage = Image.FromFile(st.DefaultImage);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {

                btn1.Image = Properties.Resources.max;
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                btn1.Image = Properties.Resources.NORMAL;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Inserting Logo";
            open.Filter = "Image Files|*.jpg";
            if(open.ShowDialog()==DialogResult.OK)
            {
                roundPictureBox1.Image = Image.FromFile(open.FileName);
            }
        }

       public void button5_Click(object sender, EventArgs e)
        {
            Form fs = Application.OpenForms["ApplicantEntryForm"];
            if(fs!=null)
            {
                if(fs.WindowState==FormWindowState.Minimized)
                {
                    fs.WindowState = FormWindowState.Normal;

                }
                else
                {
                    fs.Show();
                    fs.BringToFront();
                }
            }
            else
            {
                ApplicantEntryForm app = new ApplicantEntryForm();
                app.Show();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form forms in Application.OpenForms)
                {
                    if (forms == null)
                    {
                      
                    }
                    else
                    {
                        forms.Hide();

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            st.LogoutTime = DateTime.Now.ToString("hh:mm:ss");
            st.Save();
            UserLogin login = new UserLogin();
            this.Hide();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form fs = Application.OpenForms["UsersForm"];
            if (fs != null)
            {
                if (fs.WindowState == FormWindowState.Minimized)
                {
                    fs.WindowState = FormWindowState.Normal;

                }
                else
                {
                    fs.Show();
                    fs.Activate();
                }
            }
            else
            {
                UsersForm app = new UsersForm();
                app.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Department dept = new Department();
            if(dept.ShowDialog()==DialogResult.OK)
            {
               deptL.Text= dept.deptName.Text.ToUpper();
               
            }
        }

        private void useDefaultImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagefile = "bgImage.png";
            this.BackgroundImage = Image.FromFile(imagefile);
            st.DefaultImage = imagefile;
            st.Save();
        }

        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            open.InitialDirectory = path;
            open.Title = "Changing Background Image";
            open.Filter = "All Image Files[*.jpg;*.png;*.bmp;*.jpeg;*.jpe]|*.jpg;*.png;*.bmp;*.jpeg;*.jpe";
            if(open.ShowDialog()==DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(open.FileName);
                st.DefaultImage = open.FileName;
                st.Save();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            string file = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\PITS\\SMA_DATABASE.mdb";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Backup File PPD";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string file2 = path + "\\PPD.mdb";
            File.Copy(file, file2, true);
            Application.Exit();
        }

       

        
    }
}
