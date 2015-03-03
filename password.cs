using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GMS
{
    public partial class password : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        int dd, mm, yy;
        public string login = "";
        public string user = "";
        public void ThreadProc()
        {
            Application.Run(new Home_Page(login,user));
        }

        public password()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adp = new OleDbDataAdapter("select pass,priority from user_info where username='"+textBox1.Text+"'", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            if (ds.Tables["list"].Rows.Count > 0)
            {
                if (ds.Tables["list"].Rows[0][0].ToString() == textBox2.Text)
                {
                    login = ds.Tables["list"].Rows[0][1].ToString();
                    user = textBox1.Text;
                    this.Close();
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                    t.Start();
                }
                else
                {
                    MessageBox.Show("Error.. Insert Correct User name or Password.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            MessageBox.Show("Error.. Insert Correct User name or Password.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void password_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                adp = new OleDbDataAdapter("select pass,priority from user_info where username='" + textBox1.Text + "'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                if (ds.Tables["list"].Rows.Count > 0)
                {
                    if (ds.Tables["list"].Rows[0][0].ToString() == textBox2.Text)
                    {
                        login = ds.Tables["list"].Rows[0][1].ToString();
                        user = textBox1.Text;
                        this.Close();
                        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                        t.Start();
                    }
                    else
                    {
                        MessageBox.Show("Error.. Insert Correct User name or Password.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                MessageBox.Show("Error.. Insert Correct User name or Password.");
            }
        }
    }
}
