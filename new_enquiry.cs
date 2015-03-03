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
    public partial class new_enquiry : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;

        
        public void list()
        {
            listView1.Items.Clear();
            adp = new OleDbDataAdapter("select id,aname,contact,remark from client where custid=0", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][3].ToString());
            }
        }

        public new_enquiry()
        {
            InitializeComponent();
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            checkBox1.Checked = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text.Trim() == "")
                {
                    textBox2.Text = "-";
                }
                if (textBox3.Text.Trim() == "")
                {
                    textBox3.Text = "0";
                }
                if (textBox4.Text.Trim() == "")
                {
                    textBox4.Text = "-";
                }
                if (textBox5.Text.Trim() == "")
                {
                    textBox5.Text = "-";
                }


                if (textBox6.Text.Trim() == "")
                {
                    textBox6.Text = "-";
                }
                int id = 0;
                try
                {
                    adp = new OleDbDataAdapter("select max(id) from client ", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    id = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                }
                catch (Exception)
                {
                    id = 0;
                }
                string ddd;
                if (dateTimePicker1.Value.Month == DateTime.Now.Month && dateTimePicker1.Value.Day == DateTime.Now.Day && dateTimePicker1.Value.Year == DateTime.Now.Year)
                {
                    ddd = "0/0/0";
                }
                else
                    ddd = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
               // MessageBox.Show(ddd);
                 
                adp = new OleDbDataAdapter("insert into client values(" + (id + 1) + ",'" + textBox1.Text + "','" +ddd + "',0,'',''," + textBox3.Text + ",'" + textBox4.Text + "',0,0,'','','','','','',0,'" + textBox2.Text + "','" + textBox6.Text + "','','" + DateTime.Now.Date.ToShortDateString() + "','yes','" + textBox5.Text + "','','','','')", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                MessageBox.Show("Record Inserted..\n Your ID is:" + (id + 1));
                clear();
                list();
            }
            else
                MessageBox.Show("Error.. Insert Name");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void new_enquiry_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            list();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("update client set remark='" + textBox7.Text + "' where id=" + listView1.SelectedItems[0].SubItems[0].Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                MessageBox.Show("Remark Inserted..");
                list();
            }
            else
                MessageBox.Show("Error... Select Name from List.");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                label3.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Admission a = new Admission();
            a.id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            a.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox5.Visible = true;
            }
            else
                textBox5.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from client where id=" + listView1.SelectedItems[0].SubItems[0].Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                list();
            }
            else
                MessageBox.Show("Error.. Select ID from list");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
