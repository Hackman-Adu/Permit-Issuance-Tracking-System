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
using Bunifu.Framework.UI;
using System.IO;


namespace SMA_Application
{
    public partial class UsersForm : Form
    {
        Settings st = new Properties.Settings();
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader reader;
        byte[] image;
        MemoryStream ms;
        Form1 form1 = new Form1();
        string connectionstring;
        public UsersForm()
        {
           
            InitializeComponent();
            string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\PITS";
            if (!Directory.Exists(dbpath))
            {
                Directory.CreateDirectory(dbpath);
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", dbpath);
            connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\SMA_DATABASE.mdb";
            connection = new OleDbConnection(connectionstring);
            this.KeyPreview = true;
            this.KeyDown += UsersForm_KeyDown;
           
        }

        void UsersForm_KeyDown(object sender, KeyEventArgs e)
        {
            form1.Form1_KeyDown(this, e);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            User_Picture.Image = Properties.Resources.user_logo;
            if(st.UserType=="User")
            {
                comboBox1.Enabled = false;
            }
            ToolTip tool = new ToolTip();
            tool.ToolTipTitle = "User Profile Picture";
            tool.IsBalloon = true;
            tool.SetToolTip(User_Picture, "Double Click on picture to set to default profile picture");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {   if(st.UserType=="User")
            {
            MessageBox.Show("Access Denied!!!\nYou are not an Administrator", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
            }
            try
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is BunifuMetroTextbox)
                    {
                        BunifuMetroTextbox t = c as BunifuMetroTextbox;
                        if (string.IsNullOrWhiteSpace(c.Text))
                        {
                            MessageBox.Show("All fields are required");
                            return;
                        }
                    }

                }
                if (password1.Text != password2.Text)
                {
                    MessageBox.Show("Password do not match", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBox1.Text == "Select Access Group")
                {
                    MessageBox.Show("Select Access Group", "Inserting New User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                ms = new MemoryStream();
                User_Picture.Image.Save(ms, User_Picture.Image.RawFormat);
                image = ms.ToArray();
                connection.Open();
                string select = "SELECT * FROM Users_Information WHERE User_ID ='" + Secured.Encrytion(userid.Text.Trim()) + "'";
                command = new OleDbCommand(select, connection);
                reader = command.ExecuteReader();
                if(!reader.Read())
                {reader.Close();
                    string insertinto = "INSERT INTO Users_Information(User_ID,FirstName,LastName,Username,Access_Group,User_Password,User_Image)VALUES(@id,@fn,@ln,@username,@group,@pass,@img)";
                    command = new OleDbCommand(insertinto, connection);
                    command.Parameters.AddWithValue("@id", Secured.Encrytion(userid.Text.Trim()));
                    command.Parameters.AddWithValue("@fn", firstname.Text);
                    command.Parameters.AddWithValue("@ln", lastname.Text);
                    command.Parameters.AddWithValue("@username", username.Text);
                    command.Parameters.AddWithValue("@group", comboBox1.Text);
                    command.Parameters.AddWithValue("@pass", Secured.Encrytion(password1.Text.Trim()));
                    command.Parameters.AddWithValue("@img", image);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Information successfully saved", "Inserting New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                }
                else
                {   reader.Close();
                    MessageBox.Show("User of ID " + userid.Text + " already exists", "Adding New User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    connection.Close();
                }
                

               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                    OpenFileDialog open = new OpenFileDialog();
                    open.Title = "Choosing An Image";
                    open.Filter = "Image Files Only|*.jpg";
                    open.RestoreDirectory = true;
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        User_Picture.Image = Image.FromFile(open.FileName);
                        

                    }
  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private void ClearAll()
        {
            foreach(Control c in groupBox1.Controls)
            {
                if(c is BunifuMetroTextbox)
                {
                    BunifuMetroTextbox t = c as BunifuMetroTextbox;
                    t.Text = "";

                }
            }
            User_Picture.Image = Properties.Resources.user_logo;
            search.Text = "";
            comboBox1.Text = "Select Access Group";
            button2.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (search.Text == "" || search.Text == "enter User ID")
            {
                MessageBox.Show("No User Specified", "User Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(st.UserType=="Administrator")
            {
                try
                {
                    connection.Open();
                    string selecting = "SELECT * FROM Users_Information WHERE User_ID='" + Secured.Encrytion(search.Text.Trim()) + "'";
                    command = new OleDbCommand(selecting, connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        button2.Enabled = false;
                        userid.Text = search.Text;
                        firstname.Text = reader["FirstName"].ToString();
                        lastname.Text = reader["LastName"].ToString();
                        username.Text = reader["Username"].ToString();
                        comboBox1.Text = reader["Access_Group"].ToString();
                        password1.Text = Secured.Decryption(reader["User_Password"].ToString());
                        password2.Text = Secured.Decryption(reader["User_Password"].ToString());
                        byte[] image = (byte[])(reader["User_Image"]);
                        System.IO.MemoryStream mm = new System.IO.MemoryStream(image);
                        User_Picture.Image = Image.FromStream(mm);
                        connection.Close();

                    }
                    else
                    {
                        MessageBox.Show("User of ID " + search.Text + " does not exist", "Searh Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An erro has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }
            }
            else if(st.UserType=="User"&&search.Text!=st.UserID)
            {
                MessageBox.Show("Access Denied!!!\nYou are not an Administrator\nYou can only search and update your info", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            
            }
        else if(st.UserType=="User"&& search.Text==st.UserID)
        {
            try
            {
                connection.Open();
                string selecting = "SELECT * FROM Users_Information WHERE User_ID='" + Secured.Encrytion(search.Text.Trim()) + "'";
                command = new OleDbCommand(selecting, connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userid.Text = search.Text;
                    firstname.Text = reader["FirstName"].ToString();
                    lastname.Text = reader["LastName"].ToString();
                    username.Text = reader["Username"].ToString();
                    comboBox1.Text = reader["Access_Group"].ToString();
                    password1.Text = Secured.Decryption(reader["User_Password"].ToString());
                    password2.Text = Secured.Decryption(reader["User_Password"].ToString());
                    byte[] image = (byte[])(reader["User_Image"]);
                    System.IO.MemoryStream mm = new System.IO.MemoryStream(image);
                    User_Picture.Image = Image.FromStream(mm);
                    connection.Close();

                }
                else
                {
                    MessageBox.Show("User of ID " + search.Text + " does not exist", "Searh Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An erro has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {if(search.Text==""||search.Text=="enter User ID")
            {
                MessageBox.Show("No User Specified", "User Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is BunifuMetroTextbox)
                    {
                        BunifuMetroTextbox t = c as BunifuMetroTextbox;
                        if (string.IsNullOrWhiteSpace(c.Text))
                        {
                            MessageBox.Show("All fields are required");
                            return;
                        }
                    }

                }
                if (password1.Text != password2.Text)
                {
                    MessageBox.Show("Password do not match", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MemoryStream ms = new MemoryStream();
                User_Picture.Image.Save(ms, User_Picture.Image.RawFormat);
                byte[] images = ms.ToArray();
                connection.Open();

                string update = "UPDATE Users_Information SET User_ID=@id,FirstName=@fn,LastName=@ln,Username=@user,Access_Group=@group,User_Password=@pass,User_Image=@img WHERE User_ID='" + Secured.Encrytion(search.Text.Trim()) + "'";
                command = new OleDbCommand(update, connection);
                command.Parameters.AddWithValue("@id", Secured.Encrytion(userid.Text.Trim()));
                command.Parameters.AddWithValue("@fn", firstname.Text);
                command.Parameters.AddWithValue("@ln", lastname.Text);
                command.Parameters.AddWithValue("@user", username.Text);
                command.Parameters.AddWithValue("@group", comboBox1.Text);
                command.Parameters.AddWithValue("@pass", Secured.Encrytion(password1.Text.Trim()));
                command.Parameters.AddWithValue("@img", images);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Information successfully updated", "Updating User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }


            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Do you want to permanently delete this user?", "Deleting A User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(r==DialogResult.Yes)
                {
                    connection.Open();
                    string delete = "DELETE FROM Users_Information WHERE User_ID='" + Secured.Encrytion(search.Text.Trim()) + "'";
                    command = new OleDbCommand(delete, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("User of ID " + search.Text + " successfully deleted", "Deleting A User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();

                }
                else
                {
                    MessageBox.Show("Deletion Aborted!!!", "Deleting Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void search_Enter(object sender, EventArgs e)
        {
            if(search.Text=="enter User ID")
            {
                search.Text = "";
                search.ForeColor = Color.White;
            }
            
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(search.Text))
            {
                search.Text = "enter User ID";
                search.ForeColor = Color.Silver;
            }
        }

        private void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(ch==13)
            {
                button3_Click(search, e);
            }
        }

        private void password1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void User_Picture_DoubleClick(object sender, EventArgs e)
        {
            User_Picture.Image = Image.FromFile("user_logo.png");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        
        
    
       
    }
}
