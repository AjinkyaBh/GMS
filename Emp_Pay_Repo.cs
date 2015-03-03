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
    public partial class Emp_Pay_Repo : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public string user = "";
        public Emp_Pay_Repo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (user == "emp")
            {
                try
                {
                    adp = new OleDbDataAdapter("select aname from client1 where regid='" + textBox1.Text + "' and ref='trtr'", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    label7.Text = ds.Tables["list"].Rows[0][0].ToString();
                }
                catch (Exception)
                {
                    label7.Text = "-";
                }
            }
            else
            {
                try
                {
                    adp = new OleDbDataAdapter("select aname from client1 where regid=" + textBox1.Text + " and ref<>'trtr'", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    label7.Text = ds.Tables["list"].Rows[0][0].ToString();
                }
                catch (Exception)
                {
                    label7.Text = "-";
                }
            }
        }

        private void Emp_Pay_Repo_Load(object sender, EventArgs e)
        {
            string[] month = {"Jan","Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            comboBox1.Text = month[DateTime.Now.Month - 1];
            comboBox2.Text = (DateTime.Now.Year).ToString();
            if (user != "emp")
            {
                label1.Text = "Customer Attendence";
                this.Text = "Customer Attendence";
            }
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            
            if (user == "emp")
            {
                adp = new OleDbDataAdapter("select regid,aname from client1 where ref='trtr' order by regid", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView2.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                    listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                }
            }
            else
            {
                adp = new OleDbDataAdapter("select custid,aname from client1 where ref<>'trtr' and custid<>0 order by custid", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView2.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                    listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label7.Text = listView2.SelectedItems[0].SubItems[1].Text;
                textBox1.Text = listView2.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception) { label7.Text = "-"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user == "emp")
            {
                listView1.Items.Clear();
                if (label7.Text == "-")
                {
                    adp = new OleDbDataAdapter("select c.regid,c.aname,a.dd,a.mm,a.yy,a.pay from client1 c,payment_info a where c.ref='trtr' and c.regid=a.regid and a.mm=" + (comboBox1.SelectedIndex + 1) + " and a.yy=" + comboBox2.Text + " order by a.dd,a.mm,a.yy", con);
                }
                else
                    adp = new OleDbDataAdapter("select c.regid,c.aname,a.dd,a.mm,a.yy,a.pay from client1 c,payment_info a where c.ref='trtr' and c.regid=a.regid and a.mm=" + (comboBox1.SelectedIndex + 1) + " and a.yy=" + comboBox2.Text + " and a.regid='" + textBox1.Text + "' order by a.dd,a.mm,a.yy", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString() + "/" + ds.Tables["list"].Rows[i][3].ToString() + "/" + ds.Tables["list"].Rows[i][4].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][5].ToString());

                }
            }
            else
            {
                listView1.Items.Clear();
                if (label6.Text == "-")
                {
                    adp = new OleDbDataAdapter("select c.id,c.aname,a.dd,a.mm,a.yy,a.pay from client1 c,payment_info a where c.ref<>'trtr' and c.custid=a.cid and a.mm=" + (comboBox1.SelectedIndex + 1) + " and a.yy=" + comboBox2.Text + " order by a.dd,a.mm,a.yy", con);
                }
                else
                    adp = new OleDbDataAdapter("select c.id,c.aname,a.dd,a.mm,a.yy,a.pay from client1 c,payment_info a where c.ref<>'trtr' and c.custid=a.cid and a.mm=" + (comboBox1.SelectedIndex + 1) + " and a.yy=" + comboBox2.Text + " and a.cid=" + textBox1.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString() + "/" + ds.Tables["list"].Rows[i][3].ToString() + "/" + ds.Tables["list"].Rows[i][4].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][5].ToString());

                }
            }
        }
    }
}
