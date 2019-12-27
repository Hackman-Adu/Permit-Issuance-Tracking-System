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
using System.Data.OleDb;
using System.IO;




namespace SMA_Application
{
    public partial class UserLogin : Form
    {
        Settings st = new Properties.Settings();
        OleDbConnection connection;
        OleDbCommand command;
        string connectionstring;
        OleDbDataReader reader;
        
        public UserLogin()
        {
            InitializeComponent();
            string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)+"\\PITS"; 
            if(!Directory.Exists(dbpath))
            {
                Directory.CreateDirectory(dbpath);
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", dbpath);
            connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\SMA_DATABASE.mdb";
            connection = new OleDbConnection(connectionstring);
            Timer t = new Timer();
            t.Interval = 25;
            t.Tick += t_Tick;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            label5.Left -=3;
            if(label5.Left<0-label5.Width)
            {
                label5.Left = this.Width;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           string file=Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\PITS\\SMA_DATABASE.mdb";
           string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Backup File PPD";
           if(!Directory.Exists(path))
           {
               Directory.CreateDirectory(path);
           }
           string file2 = path + "\\PPD.mdb";
           File.Copy(file, file2,true);
           Application.Exit();
            
          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
         
        }

        

        private void UserLogin_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.user_logo;
            GettingUsers();
            comboBox1.Items.Remove("Developer");
            dename.Text = st.DepartmentName.ToUpper();
            this.KeyPreview = true;
            this.KeyDown += UserLogin_KeyDown;

            
        }

        void UserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control&&e.Alt&&e.Shift&&e.KeyCode==Keys.H)
            {
                 comboBox1.Items.Add("Developer");
                if(!comboBox1.Items.Contains("Developer"))
                {
                    comboBox1.Items.Add("Developer");
                }
                   
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text =="Select your username")
            {
                MessageBox.Show("No user selected", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            connection.Open();
            string select = "SELECT * FROM Users_Information WHERE Username='" + comboBox1.Text + "' and User_Password='" + Secured.Encrytion(pass.Text.Trim()) + "'";
            command = new OleDbCommand(select, connection);
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                st.UserID = Secured.Decryption(reader["User_ID"].ToString());
                st.UserType = reader["Access_Group"].ToString();
                st.FirstName = reader["FirstName"].ToString();
                st.LastName = reader["LastName"].ToString();
                st.LoginDate = DateTime.Now.ToLongDateString().ToString();
                st.LoginTimes = DateTime.Now.ToString("hh:mm:ss");
                st.Save();
                Form1 form = new Form1();
                this.Hide();
                form.Show();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Wrong password for username " + comboBox1.Text, "User Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void GettingUsers()
        {
            connection.Open();
            string selecting = "SELECT * FROM Users_Information";
            command = new OleDbCommand(selecting, connection);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add(reader["Username"].ToString());
                
            }
            connection.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            string selectImage = "SELECT * FROM Users_Information WHERE Username='" + comboBox1.Text + "'";
            command = new OleDbCommand(selectImage, connection);
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                byte[] image = (byte[])(reader["User_Image"]);
                System.IO.MemoryStream mm = new System.IO.MemoryStream(image);
                pictureBox1.Image= Image.FromStream(mm);
            }
            connection.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(ch==13)
            {
                pass.Focus();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void pass_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            pass.Focus();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            AppDeveloper app = new AppDeveloper();
            app.ShowDialog();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            string fn = st.FirstName;
            string ln = st.LastName;
            string full=fn+" "+ln;
            MessageBox.Show("The last user login Details:\n"+"User Full Name: " + full+Environment.NewLine+"Date: "+st.LoginDate+Environment.NewLine+"Login Time: "+ st.LoginTimes+Environment.NewLine+"Logout Time: "+st.LogoutTime, "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ForgotPassword pas = new ForgotPassword();
            pas.ShowDialog();
        }

        private void UserLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            bunifuImageButton1_Click(this, e);
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                
                    button8_Click(pass, e);
                
            }
        }

        
        
    }
}
