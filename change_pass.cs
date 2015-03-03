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
    public partial class change_pass : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public string user="";
        public string priority = "";
        public void list()
        {
            listView1.Items.Clear();
            adp = new OleDbDataAdapter("select* from user_info", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString());
            }
        }

        public change_pass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    adp = new OleDbDataAdapter("update user_info set pass='" + textBox2.Text + "' where username='"+textBox1.Text+"'", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                    MessageBox.Show("Error.. Password not match.");
            }
            else
                MessageBox.Show("Error.. Insert all details.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    adp = new OleDbDataAdapter("insert into user_info values('" + textBox1.Text + "','"+textBox2.Text+"','"+comboBox1.Text+"')", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    list();
                }
                else
                    MessageBox.Show("Error.. Password not match.");
            }
            else
                MessageBox.Show("Error.. Insert all details.");
        }

        private void change_pass_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            list();
            textBox1.Text = user;
            if (priority != "Admin")
            {
                textBox1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from user_info where username='" + listView1.SelectedItems[0].SubItems[0].Text + "'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                list();
            }
            else
                MessageBox.Show("Error.. Select user first.");
        }
    }
}
