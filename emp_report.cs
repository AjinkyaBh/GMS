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
    public partial class emp_report : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public emp_report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void emp_report_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            textBox1.Text = "Text";
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                adp = new OleDbDataAdapter("select * from client1 where aname like '" + textBox1.Text + "%'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i]["regid"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["aname"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["contact"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["email"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["address"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["econtactper"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["econtact"].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["remark"].ToString());
                }
            }
            catch (Exception) { }
        }
    }
}
