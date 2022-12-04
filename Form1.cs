
using LoginSysten;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




    namespace evaluation_form
    {
        public partial class Form1 : Form
        {
            Config db = new Config();
            public Form1()
            {
                InitializeComponent();
            db.Connect("Exam");
        }

            private void Form1_Load(object sender, EventArgs e)
            {
                    
           
            }

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {


            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                textBox1.Visible = false;
                label1.Visible = false;
            }
            else if (checkBox1.Checked == false)
            {
                checkBox2.Checked = true;
                textBox1.Visible = true;
                label1.Visible = true;

            }

            }

            private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {
           
            if (checkBox2.Checked == true)
                {
                checkBox1.Checked = false;
                textBox3.Visible=false;
                textBox4.Visible=false;
                textBox5.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;



            }
                else if (checkBox2.Checked == false)
                {
                checkBox1.Checked = true;
                textBox3.Visible = true;
                textBox4.Visible =true;
                textBox5.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;



            }
            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {
           // db.Execute("INSERT INTO `question` (`num_question`, `question`) VALUES ( '" + textBox8.Text + "','" + textBox2.Text + "');");
        }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
           // db.Execute("INSERT INTO `reponce qd '(' reponce ' ) VALUES ( '" + textBox1.Text + "');");
            }
    

            private void textBox3_TextChanged(object sender, EventArgs e)
            {
           // db.Execute("INSERT INTO `rponce qd` (`num_question`, `option1`) VALUES ( '" + textBox8.Text + "','" + textBox3.Text + "');");

        }

            private void textBox4_TextChanged(object sender, EventArgs e)
            {
            //db.Execute("INSERT INTO `reponce qsm` (`num_question`, `option1`) VALUES ( '" + textBox8.Text + "','" + textBox4.Text + "');");
        }

            private void textBox5_TextChanged(object sender, EventArgs e)
            {
            //db.Execute("INSERT INTO `reponce qsm` (`num_question`, `option1`) VALUES ( '" + textBox8.Text + "','" + textBox5.Text + "');");
        }

            private void textBox6_TextChanged(object sender, EventArgs e)
            {
            //db.Execute("INSERT INTO `reponse` (`reponce`) VALUES ( '" + textBox6.Text + "');");
            }

    

            private void button4_Click(object sender, EventArgs e)
            {
            this.Close();
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
            //db.Execute("INSERT INTO `exam1` (`duree`) VALUES ( '" + textBox7.Text + "');");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
          //db.Execute("INSERT INTO `question` (`num_question`) VALUES ( '" + textBox8.Text + "');");
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
           db.Execute("INSERT INTO `reponce qsm` (`num_question`, `option1`,'option2','option3') VALUES ( '" + textBox8.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "');");
            db.Execute("INSERT INTO `question` (`num_question`, `question`) VALUES ( '" + textBox8.Text + "','" + textBox2.Text + "');");
            db.Execute("INSERT INTO `reponse qd` (`reponse`,`num_question ` ) VALUES ( '" + textBox8.Text + "','" + textBox1.Text + "');");
            db.Execute("INSERT INTO `exam1` (`duree` ) VALUES ( '" + textBox7.Text + "');");
            MessageBox.Show("votre examen a ete créer");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                foreach (var c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).Text = String.Empty;
                    }
                }
            }
        }
    }
    

namespace LoginSysten
{
    public class Config
    {
        string ConectionString = "";
        public MySqlConnection connection = null;
        public string server = "127.0.0.1";
        public string user = "root";
        public string password = "";
        DataSet ds;
        DataTable dt;
        public string Table = "exam1";
        public string Table1 = "question";
        public string Table2 = "reponse";
        public string Table3 = "reponce qsm";
        public string Table4 = "reponse qd";
        public string ConnectionType = "";
        string RecordSource = "";

        DataGridView tempdata;

        public Config()
        {

        }

        
        public void Connect(string database_name)
        {
            try
            {

                ConectionString = "SERVER=" + server + ";" + "DATABASE=" + database_name + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";

                connection = new MySqlConnection(ConectionString);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        
        public void ExecuteSql(string Sql_command)
        {

            nowquiee(Sql_command);

        }

        
        public void nowquiee(string sql_comm)
        {
            try
            {
                MySqlConnection cs = new MySqlConnection(ConectionString);
                cs.Open();
                MySqlCommand myc = new MySqlCommand(sql_comm, cs);
                myc.ExecuteNonQuery();
                cs.Close();


            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }


        public void Execute(string Sql_command)
        {
            RecordSource = Sql_command;
            ConnectionType = Table;
            dt = new DataTable(ConnectionType);
            try
            {
                string command = RecordSource.ToUpper();


                MySqlDataAdapter da2 = new MySqlDataAdapter(RecordSource, connection);

                DataSet tempds = new DataSet();
                da2.Fill(tempds, ConnectionType);
                da2.Fill(tempds);



            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }


        public string Results(int ROW, string COLUMN_NAME)
        {
            try
            {
                return dt.Rows[ROW][COLUMN_NAME].ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return "";

            }
        }


        public void ExecuteSelect(string Sql_command)
        {
            RecordSource = Sql_command;
            ConnectionType = Table;

            dt = new DataTable(ConnectionType);
            try
            {
                string command = RecordSource.ToUpper();
                MySqlDataAdapter da = new MySqlDataAdapter(RecordSource, connection);
                ds = new DataSet();
                da.Fill(ds, ConnectionType);
                da.Fill(dt);
                tempdata = new DataGridView();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }


        public int Count()
        {
            return dt.Rows.Count;
        }
    }
}
