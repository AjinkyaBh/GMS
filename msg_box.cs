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
    public partial class msg_box : Form
    {
        OleDbConnection con;
        DataSet ds;
        OleDbDataAdapter adt;
        int d = 1;

        public string pathh = Application.StartupPath.ToString();

        public msg_box()
        {
            InitializeComponent();
        }


        public void list()
        {
            if (checkBox1.Checked == false)
            {
                listView1.Items.Clear();
                string mon;
                //if (dateTimePicker1.Value.Month < 10)
                //{
                //    mon = "0" + dateTimePicker1.Value.Month;
                //}
                //else
                {
                    mon = dateTimePicker1.Value.Month + "";
                }
                string day;
                //if (dateTimePicker1.Value.Day < 10)
                //{
                //    day = "0" + dateTimePicker1.Value.Day;
                //}
                //else
                {
                    day = dateTimePicker1.Value.Day + "";
                }
                //MessageBox.Show("select custid,aname,dob,contact from client where dob like '" + mon + "/" + day+ "/%' order by custid");
                adt = new OleDbDataAdapter("select custid,aname,dob,contact from client where dob like '" + mon + "/" + day+ "/%' order by custid", con);
                ds = new DataSet();
                adt.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i]["custid"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["aname"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["dob"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["contact"].ToString());

                }
            }
            else
            {
                adt = new OleDbDataAdapter("select custid,aname,dob,contact from client order by custid", con);
                ds = new DataSet();
                adt.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i]["custid"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["aname"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["dob"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["contact"].ToString());

                }
            }
        }

        private void msg_box_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            list();
            adt = new OleDbDataAdapter("select title from add_remove_msg", con);
            ds = new DataSet();
            adt.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            list();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                try
                {
                    adt = new OleDbDataAdapter("select max(msgid) from msg", con);
                    ds = new DataSet();
                    adt.Fill(ds, "list");
                    d = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                    d++;
                }
                catch (Exception) { d = 1; };
                adt = new OleDbDataAdapter("insert into msg values (" + d + "," + listView1.Items[i].SubItems[0].Text + ",'" + System.DateTime.Today + "','" + textBox1.Text + "')", con);
                ds = new DataSet();
                adt.Fill(ds, "list");


            }
            MessageBox.Show("Message Sent to all successfully..");
            textBox1.Text = "";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            list();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            adt = new OleDbDataAdapter("select msg_text from add_remove_msg where title='" +comboBox1.Text + "'", con);
            ds = new DataSet();
            adt.Fill(ds, "list");

            textBox1.Text = ds.Tables["list"].Rows[0][0].ToString();

            
        }
    }
}
