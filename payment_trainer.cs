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
    public partial class payment_trainer : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public payment_trainer()
        {
            InitializeComponent();
        }

        public void paylist()
        {
            listView2.Items.Clear();
            adp = new OleDbDataAdapter("select dd,mm,yy,pay,remark,pid from payment_info where regid='" + textBox2.Text + "'", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView2.Items.Add(ds.Tables["list"].Rows[i][0].ToString() + "/" + ds.Tables["list"].Rows[i][1].ToString() + "/" + ds.Tables["list"].Rows[i][2].ToString());
                listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][3].ToString());
                listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][4].ToString());
                listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][5].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            adp = new OleDbDataAdapter("select aname from client1 where aname like'" + textBox1.Text + "%' and ref='trtr' order by aname", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables["list"].Rows[i]["aname"].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("select regid from client1 where aname='" + listBox1.SelectedItem.ToString() + "' and ref='trtr' and custid<>0", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                textBox2.Text = ds.Tables["list"].Rows[0][0].ToString();
            }
        }

        private void payment_trainer_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            comboBox1.Text = DateTime.Now.Month.ToString();
            comboBox2.Text = DateTime.Now.Year.ToString();
            textBox1.Text = "Text";
            textBox1.Text = "";
        }

        public void clear()
        {
            textBox4.Text = "";
            label9.Text = "-";
            label10.Text = "-";
            label11.Text = "-";
            label13.Text = "-";
            label12.Text = "0";
            textBox3.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                try
                {
                    //MessageBox.Show("1");
                    adp = new OleDbDataAdapter("select aname,address,contact,email from client1 where regid='" + textBox2.Text + "' and ref='trtr'", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    //MessageBox.Show("2");
                    label9.Text = ds.Tables["list"].Rows[0][0].ToString();
                    label10.Text = ds.Tables["list"].Rows[0][1].ToString();
                    label11.Text = ds.Tables["list"].Rows[0][2].ToString();
                    label13.Text = ds.Tables["list"].Rows[0][3].ToString();
                    listView1.Items.Clear();
                    //MessageBox.Show("3");
                    adp = new OleDbDataAdapter("select c.cid,i.aname from cust_info_m c,client i where c.cid=i.custid and c.trainer='" + label9.Text + "' and c.mm=" + comboBox1.Text + " and c.yy=" + comboBox2.Text + "", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                    {
                        listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                        listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                    }
                    
                    paylist();
                }
                catch (Exception)
                {
                    clear();
                }
            }
            else
            {
                clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                adp = new OleDbDataAdapter("select c.cid,i.aname from cust_info_m c,client i where c.cid=i.custid and c.trainer='" + label9.Text + "' and c.mm=" + comboBox1.Text + " and c.yy=" + comboBox2.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                }
            }
            catch (Exception) {  }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                adp = new OleDbDataAdapter("select c.cid,i.aname from cust_info_m c,client i where c.cid=i.custid and c.trainer='" + label9.Text + "' and c.mm=" + comboBox1.Text + " and c.yy=" + comboBox2.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                }
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox3.Text) > 0 )
                {
                    int max = 0;
                    try
                    {
                        adp = new OleDbDataAdapter("select max(pid) from payment_info", con);
                        ds = new DataSet();
                        adp.Fill(ds, "list");
                        max = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                    }
                    catch (Exception) { }
                    max++;
                    adp = new OleDbDataAdapter("insert into payment_info values(" + max + "," + DateTime.Now.Day + "," + DateTime.Now.Month + "," + DateTime.Now.Year + ",0," + textBox3.Text + ",'" + textBox4.Text + "','','"+textBox2.Text+"')", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    clear();
                    MessageBox.Show("Record Inserted..");
                    paylist();
                }
                else
                    MessageBox.Show("Error..");
            }
            catch (Exception)
            {
                MessageBox.Show("Error..");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from payment_info where pid=" + listView2.SelectedItems[0].SubItems[3].Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                paylist();
            }
            else
                MessageBox.Show("Error.. Select Payment first.");
        }
    }
}
