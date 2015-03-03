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
    public partial class Admission : Form
    {
        public int id = 0;
        int flag = 0;
        int flag1 = 0;
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public void clear()
        {
             textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;

            label19.Text = "-";
        }

        public Admission()
        {
            InitializeComponent();
        }

        public void list()
        {
            listView1.Items.Clear();
            adp = new OleDbDataAdapter("select * from client where custid<>0 order by custid", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count;i++ )
            {
                listView1.Items.Add(ds.Tables["list"].Rows[i]["custid"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["aname"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["address"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["contact"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["gender"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["coupleid"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("true" + flag1);
            if (textBox10.Text != "0")
            {
                if (flag == 1)
                {
                    if (flag1 == 0)
                    {
                        if (label23.Visible == false)
                        {
                            if (textBox1.Text != "")
                            {
                                if (textBox2.Text.Trim() == "")
                                {
                                    textBox2.Text = "-";
                                }
                                if (textBox4.Text.Trim() == "")
                                {
                                    textBox4.Text = "-";
                                }
                                if (textBox5.Text.Trim() == "")
                                {
                                    textBox5.Text = "0";
                                }
                                if (textBox6.Text.Trim() == "")
                                {
                                    textBox6.Text = "-";
                                }
                                if (textBox11.Text.Trim() == "")
                                {
                                    textBox11.Text = "-";
                                }
                                if (textBox7.Text.Trim() == "")
                                {
                                    textBox7.Text = "0";
                                }
                                if (textBox8.Text.Trim() == "")
                                {
                                    textBox8.Text = "0";
                                }
                                int id = 0;
                                try
                                {

                                    id = int.Parse(textBox10.Text);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Error.. Incorrect Admission ID.");

                                    id = 0;
                                }

                                string ddd;
                                if (dateTimePicker1.Value.Month == DateTime.Now.Month && dateTimePicker1.Value.Day == DateTime.Now.Day && dateTimePicker1.Value.Year == DateTime.Now.Year)
                                {
                                    ddd = "0/0/0";
                                }
                                else
                                    ddd = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
                        

                                adp = new OleDbDataAdapter("update client set gender='" + radioButton1.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set dob='" + ddd + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set profession='" + textBox4.Text + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set econtact=" + textBox7.Text + " where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                if (textBox9.Text != "")
                                {
                                    adp = new OleDbDataAdapter("update client set coupleid=" + textBox9.Text + " where id=" + textBox3.Text + "", con);
                                    ds = new DataSet();
                                    adp.Fill(ds, "list");
                                }
                                adp = new OleDbDataAdapter("update client set q1='" + checkBox1.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set q2='" + checkBox2.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set q3='" + checkBox3.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set q4='" + checkBox4.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set q5='" + checkBox5.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set q6='" + checkBox6.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set q7='" + checkBox7.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set q8='" + textBox12.Text + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set aname='" + textBox1.Text + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set address='" + textBox2.Text + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                try
                                {
                                    adp = new OleDbDataAdapter("update client set age=" + textBox8.Text + " where id=" + textBox3.Text + "", con);
                                    ds = new DataSet();
                                    adp.Fill(ds, "list");
                                }
                                catch (Exception) { }
                                adp = new OleDbDataAdapter("update client set contact=" + textBox5.Text + " where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set email='" + textBox6.Text + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                adp = new OleDbDataAdapter("update client set econtactper='" + textBox11.Text + "' where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");

                                adp = new OleDbDataAdapter("update client set custid=" + id + " where id=" + textBox3.Text + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                if (label19.Text != "-")
                                {
                                    adp = new OleDbDataAdapter("update client set coupleid=" + id + " where custid=" + textBox9.Text + "", con);
                                    ds = new DataSet();
                                    adp.Fill(ds, "list");
                                }
                                MessageBox.Show("Record Inserted.. Your Gym ID is" + id);
                                clear();
                                list();
                                textBox12.Text = "";
                            }
                            else
                                MessageBox.Show("Error.. Insert All Details.");
                        }
                        else
                            MessageBox.Show("Error.. Insert Available Admission ID.");
                    }
                    else
                        MessageBox.Show("Error.. Insert correct couple Id.");
                }
                else
                    MessageBox.Show("Error.. Insert Enquiry ID first.");
            }
            else
                MessageBox.Show("Error.. Insert Admission ID first.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Admission_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            textBox3.Text=id.ToString();
            list();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select * from client where id=" + textBox3.Text + " and custid=0", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                textBox1.Text = ds.Tables["list"].Rows[0]["aname"].ToString();
                textBox2.Text = ds.Tables["list"].Rows[0]["address"].ToString();
                textBox5.Text = ds.Tables["list"].Rows[0]["contact"].ToString();
                textBox6.Text = ds.Tables["list"].Rows[0]["email"].ToString();
                try
                {
                    dateTimePicker1.Value = DateTime.Parse(ds.Tables["list"].Rows[0]["dob"].ToString());
                }
                catch (Exception)
                { }
                flag = 1;
                label21.Visible = false ;
            }
            catch (Exception) 
            {
                flag = 0;
                label21.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox8.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                flag1 = 0;
                if (textBox9.Text == "")
                {
                    flag1 = 0;
                  //  MessageBox.Show("true" + flag1);
                    label19.Text = "-";
                }
                else
                {
                    adp = new OleDbDataAdapter("select aname from client where custid=" + textBox9.Text + " and coupleid=0", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    label19.Text = ds.Tables["list"].Rows[0][0].ToString();
                }
            }
            catch (Exception) 
            {
                flag1 = 1;
                label19.Text = "-";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select * from client where custid=" + textBox10.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                if (ds.Tables["list"].Rows.Count > 0)
                    label23.Visible = true;
                else
                    label23.Visible = false;
            }
            catch (Exception) 
            {
                label23.Visible = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dateTimePicker1.Value.Year.ToString());
            if(int.Parse(DateTime.Now.Month.ToString()) > int.Parse(dateTimePicker1.Value.Month.ToString()))
            {
                age--;
            }
            else if(int.Parse(DateTime.Now.Month.ToString()) == int.Parse(dateTimePicker1.Value.Month.ToString()))
            {
                if(int.Parse(DateTime.Now.Day.ToString()) >= int.Parse(dateTimePicker1.Value.Day.ToString()))
                {
                    age--;
                }
            }
            textBox8.Text = age.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from client where custid=" + listView1.SelectedItems[0].SubItems[0].Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                adp = new OleDbDataAdapter("update client set coupleid=0 where coupleid=" + listView1.SelectedItems[0].SubItems[0].Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                list();
            }
            else
                MessageBox.Show("Error.. Select Name from List.");
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                textBox12.Visible = true;
                label29.Visible = true;
            }
            else
            {
                textBox12.Visible = false;
                label29.Visible = false;
            }
        }
    }
}

