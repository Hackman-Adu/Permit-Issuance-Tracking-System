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
using System.Data.OleDb;
using System.IO;

namespace SMA_Application
{
    public partial class ApplicantEntryForm : Form
    {
       List<string>comboitems;
        OleDbConnection connection;
        OleDbCommand command;
        string connectionstring;
        OleDbDataReader reader;
        Form1 form1 = new Form1();

        public ApplicantEntryForm()
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
            comboitems=new List<string>();
            
            comboitems.Add("Residential");
            comboitems.Add("Commercial");
            comboitems.Add("Education");
            comboitems.Add("Mixed Use");
            comboitems.Add("Civic and Culture");
            foreach(string name in comboitems)
            {
                zoning.Items.Add(name);
            }
            this.KeyPreview = true;
            this.KeyDown += ApplicantEntryForm_KeyDown;
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
            BunifuMetroTextbox t = sender as BunifuMetroTextbox;
            if(e.KeyChar==13)
            {
                this.SelectNextControl(t, true, true, true, true);
            }
        }

        void ApplicantEntryForm_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.Control&&e.KeyCode==Keys.B)
           {
               button5_Click(this, e);
           }
           if(e.Control&&e.KeyCode==Keys.M)
           {
               button7_Click(this, e);
           }
           if (e.Control && e.KeyCode == Keys.U)
           {
               button8_Click(this, e);
           }
        }
        
            

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
/// <summary>
/// Method for clearing all text fields
/// </summary>
        public void ClearAll()
        {
            foreach (Control c in this.groupBox1.Controls)
            {
                if (c is BunifuMetroTextbox)
                {
                    BunifuMetroTextbox t = c as BunifuMetroTextbox;
                    t.Text = "";
                }
            }
            foreach (Control c in this.groupBox2.Controls)
            {
                if (c is BunifuMetroTextbox)
                {
                    BunifuMetroTextbox t = c as BunifuMetroTextbox;
                    t.Text = "";
                }
            }
            remarks.Clear();
            zoning.Text = "Select Zoning";
            gen.Text = "Select Gender";
            AppDate.Value = DateTime.Now;
            permitI.Value = DateTime.Now;

        }

        private void ApplicantEntryForm_Load(object sender, EventArgs e)
        {
            GettingforZoning();
            NumberOfApplicants();
            Getting();
            gen.KeyPress += gen_KeyPress;
            tel.KeyPress += tel_KeyPress;
            

            foreach (Control c1 in groupBox2.Controls)
            {
                if (c1 is BunifuMetroTextbox)
                {
                    c1.KeyPress += c1_KeyPress;
                }
            }
            Duration.KeyPress += Duration_KeyPress;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach(string f in zoning.Items)
            {
                collection.Add(f);
            }
            zoning.AutoCompleteCustomSource = collection;
           


        }

        void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }
        private void Getting()
        {
            try
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                connection.Open();
                string select = "SELECT * FROM Applicants_Information";
                command = new OleDbCommand(select, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    collection.Add(reader["DevelopmentNo"].ToString());

                }
                reader.Close();
                textBox1.AutoCompleteCustomSource = collection;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        void gen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        void Duration_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        void c1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
            BunifuMetroTextbox t = sender as BunifuMetroTextbox;
            if(t.Text.Contains('.'))
            {
                if(e.KeyChar=='.')
                {
                    e.Handled = true;
                }
               
            }
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (zoning.Text == "Select Zoning")
            {
                MessageBox.Show("Specify Zoning", "New Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (gen.Text == "Select Gender")
            {

                MessageBox.Show("Specify Gender", "New Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(tel.Text.Length!=9)
            {
                MessageBox.Show("Incorrect phone number\nPhone number must be a length of 9", "New Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                connection.Open();
                string select = "SELECT * FROM Applicants_information WHERE DevelopmentNo='" + devNo.Text + "'";
                command = new OleDbCommand(select, connection);
                reader = command.ExecuteReader();
                if(!reader.Read())
                {
                   
                    string insert = "INSERT INTO Applicants_Information(DevelopmentNo,AppZoning,ProposedDev,ApplicantPhone,AppGender,DateApplication,AppCurrentState,SPC_Decision,DatePermitIssued,AppDuration,PermitFees,SubmissionFees,AppRemarks) VALUES (@no,@zoning,@proD,@tel,@gender,@AppDate,@current,@spc,@dateS,@duration,@permitFees,@SubFees,@remarks)";
                    command = new OleDbCommand(insert, connection);
                    command.Parameters.AddWithValue("@no", devNo.Text);
                    command.Parameters.AddWithValue("@zoning", zoning.Text);
                    command.Parameters.AddWithValue("@proD", proposedD.Text);
                    command.Parameters.AddWithValue("@tel", int.Parse(tel.Text));
                    command.Parameters.AddWithValue("@gender", gen.Text);
                    command.Parameters.AddWithValue("@AppDate", AppDate.Value);
                    command.Parameters.AddWithValue("@current", CurrentS.Text);
                    command.Parameters.AddWithValue("@spc", spc.Text);
                    command.Parameters.AddWithValue("@dateS", permitI.Value);
                    command.Parameters.AddWithValue("@duration", int.Parse(Duration.Text));
                    command.Parameters.AddWithValue("@permitFees",double.Parse(PermitFees.Text));
                    command.Parameters.AddWithValue("@SubFees", double.Parse(subFees.Text));
                    command.Parameters.AddWithValue("@remarks", remarks.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Applicant Information successfully saved", "Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    connection.Close();
                    Getting();
                    NumberOfApplicants();
                }
                else
                {

                    MessageBox.Show("Applicant of Development Application Number " + devNo.Text + " already exist in the database", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    connection.Close();
                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (zoning.Text == "Select Zoning")
            {
                MessageBox.Show("Specify Zoning", "New Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (gen.Text == "Select Gender")
            {

                MessageBox.Show("Specify Gender", "New Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (tel.Text.Length != 9)
            {
                MessageBox.Show("Incorrect phone number\nPhone number must be a length of 9", "New Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                connection.Open();
                string updating = "UPDATE Applicants_Information SET DevelopmentNo=@no,AppZoning=@zoning,ProposedDev=@proD,ApplicantPhone=@tel,AppGender=@gender,DateApplication=@AppDate,AppCurrentState=@current,SPC_Decision=@spc,DatePermitIssued=@DateS,AppDuration=@duration,PermitFees=@permitFees,SubmissionFees=@SubFees,AppRemarks=@remarks WHERE DevelopmentNo='" + devNo.Text + "'";
                command = new OleDbCommand(updating, connection);
                command.Parameters.AddWithValue("@no", devNo.Text);
                command.Parameters.AddWithValue("@zoning", zoning.Text);
                command.Parameters.AddWithValue("@proD", proposedD.Text);
                command.Parameters.AddWithValue("@tel", int.Parse(tel.Text));
                command.Parameters.AddWithValue("@gender", gen.Text);
                command.Parameters.AddWithValue("@AppDate", AppDate.Value);
                command.Parameters.AddWithValue("@current", CurrentS.Text);
                command.Parameters.AddWithValue("@spc", spc.Text);
                command.Parameters.AddWithValue("@dateS", permitI.Value);
                command.Parameters.AddWithValue("@duration", int.Parse(Duration.Text));
                command.Parameters.AddWithValue("@permitFees", double.Parse(PermitFees.Text));
                command.Parameters.AddWithValue("@SubFees", double.Parse(subFees.Text));
                command.Parameters.AddWithValue("@remarks", remarks.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Applicant Information successfully updated", "Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrWhiteSpace(devNo.Text))
           {
               MessageBox.Show("No Applicant Specified", "Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               return;
           }
           DialogResult r = MessageBox.Show("Do you want to permanently delete this applicant from the database?", "Applicant Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(r==DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    string delete = "DELETE FROM Applicants_Information WHERE DevelopmentNo='" + devNo.Text + "'";
                    command = new OleDbCommand(delete, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Applicant successfully deleted", "Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    Getting();
                    NumberOfApplicants();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {if(string.IsNullOrWhiteSpace(textBox1.Text))
        {
            MessageBox.Show("Application number not specified", "Search", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox1.Focus();
            return;
        }
            try
            {
                connection.Open();
                string select = "SELECT * FROM Applicants_information WHERE DevelopmentNo='" + textBox1.Text + "'";
                command = new OleDbCommand(select, connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    devNo.Text = reader["DevelopmentNo"].ToString();
                    zoning.Text = reader["AppZoning"].ToString();
                    proposedD.Text = reader["ProposedDev"].ToString();
                    tel.Text = reader["ApplicantPhone"].ToString();
                    gen.Text = reader["AppGender"].ToString();
                    AppDate.Value = DateTime.Parse(reader["DateApplication"].ToString());
                    CurrentS.Text = reader["AppCurrentState"].ToString();
                    spc.Text = reader["SPC_Decision"].ToString();
                    permitI.Value = DateTime.Parse(reader["DatePermitIssued"].ToString());
                    Duration.Text = reader["AppDuration"].ToString();
                    PermitFees.Text = reader["PermitFees"].ToString();
                    remarks.Text = reader["AppRemarks"].ToString();
                    subFees.Text = reader["SubmissionFees"].ToString();
                    connection.Close();


                }
                else
                {

                    MessageBox.Show("This Applicant does not exist in the database", "Searh Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }



        }
        public void NumberOfApplicants()
        {
            try
            {
                connection.Open();
            string count = "SELECT COUNT(*) FROM Applicants_Information";
            command = new OleDbCommand(count, connection);
            int number=Convert.ToInt32(command.ExecuteScalar());
            string a=number.ToString("N");
            num.Text = a.Replace(".00", "");
            connection.Close();
            
            }
            catch (Exception ex)
             {
                    MessageBox.Show(ex.Message);
                    connection.Close();
              }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BackupDB backup = new BackupDB();
            backup.ShowDialog();

            
        }

        private void zoning_Leave(object sender, EventArgs e)
        {   string a=zoning.Text;
            if(zoning.Text!="Select Zoning"&& !zoning.Items.Contains(a))
            {
                zoning.Items.Add(zoning.Text);
            }
        }
        private void GettingforZoning()
        {
            try
            {

                connection.Open();
                string select = "SELECT DISTINCT AppZoning FROM Applicants_information";
                command = new OleDbCommand(select, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!zoning.Items.Contains(reader["AppZoning"].ToString()))
                    {
                        zoning.Items.Add(reader["AppZoning"].ToString());
                    }
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form fs = Application.OpenForms["ExternalData"];
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
                ExternalData ext = new ExternalData();
                ext.Show();
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NumberOfApplicants();
            ApplicantEntryForm_Load(this, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Form fs = Application.OpenForms["Multisearch"];
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
                Multisearch mult = new Multisearch();
                mult.Show();
                this.Close();
            }
        }


    }
}
