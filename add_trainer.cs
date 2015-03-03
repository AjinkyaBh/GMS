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
    public partial class add_trainer : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public add_trainer()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void list()
        {
            listView1.Items.Clear();
            adp = new OleDbDataAdapter("select * from client1 where ref='trtr' order by regid", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView1.Items.Add(ds.Tables["list"].Rows[i]["regid"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["aname"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["address"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["contact"].ToString());
            }
        }

        public void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            //int id1 = 0;
            //try
            //{
            //    adp = new OleDbDataAdapter("select max(custid) from client", con);
            //    ds = new DataSet();
            //    adp.Fill(ds, "list");
            //    textBox1.Text = (int.Parse(ds.Tables["list"].Rows[0][0].ToString()) + 1).ToString();
            //}
            //catch (Exception)
            //{
            //    textBox1.Text = "1";
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label9.Visible == false)
            {
                if (textBox2.Text.Trim() != "")
                {
                    if (textBox1.Text.Trim() != "")
                    {
                        if (textBox3.Text.Trim() == "")
                        {
                            textBox3.Text = "-";
                        }
                        if (textBox4.Text.Trim() == "")
                        {
                            textBox4.Text = "0";
                        }
                        if (textBox5.Text.Trim() == "")
                        {
                            textBox5.Text = "-";
                        }
                        if (textBox6.Text.Trim() == "")
                        {
                            textBox6.Text = "-";
                        }
                        if (textBox7.Text.Trim() == "")
                        {
                            textBox7.Text = "0";
                        }
                        if (textBox8.Text.Trim() == "")
                        {
                            textBox8.Text = "-";
                        }
                        if (button1.Text == "Submit")
                        {
                            int id = 0;
                            try
                            {
                                adp = new OleDbDataAdapter("select max(id) from client1 ", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                id = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                            }
                            catch (Exception)
                            {
                                id = 0;
                            }

                            int id1 = 0;
                            try
                            {
                                adp = new OleDbDataAdapter("select max(custid) from client1", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                                id1 = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                            }
                            catch (Exception)
                            {
                                id1 = 0;
                            }

                            adp = new OleDbDataAdapter("insert into client1 values(" + (id + 1) + ",'" + textBox2.Text + "','" + dateTimePicker1.Value.Date.ToShortDateString() + "',0,'" + radioButton1.Checked.ToString() + "',''," + textBox4.Text + ",'" + textBox5.Text + "'," + textBox7.Text + ",0,'','','','','',''," + (id1 + 1) + ",'" + textBox3.Text + "','trtr','" + textBox8.Text + "','" + DateTime.Now.Date.ToShortDateString() + "','yes','','" + textBox6.Text + "','" + textBox1.Text + "')", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            MessageBox.Show("Your Reg ID is:" + textBox1.Text);
                        }
                        else
                        {
                            adp = new OleDbDataAdapter("update client1 set aname='"+textBox2.Text+"' where regid='"+textBox1.Text+"'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set dob='" + dateTimePicker1.Value.Date.ToShortDateString() + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set gender='" + radioButton1.Checked.ToString() + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set address='" + textBox3.Text + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set contact='" + textBox4.Text + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set email='" + textBox5.Text + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set econtactper='" + textBox6.Text + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set econtact='" + textBox7.Text + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            adp = new OleDbDataAdapter("update client1 set remark='" + textBox8.Text + "' where regid='" + textBox1.Text + "'", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            MessageBox.Show("Record updated of Reg ID:" + textBox1.Text);
                        }
                        clear();
                        list();
                    }
                    else
                        MessageBox.Show("Error.. Insert ID");
                }
                else
                    MessageBox.Show("Error.. Insert name");
            }
            else
                MessageBox.Show("Error.. Reg Id not available");
        }

        private void add_trainer_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            int id1 = 0;
            //try
            //{
            //    adp = new OleDbDataAdapter("select max(custid),regid from client", con);
            //    ds = new DataSet();
            //    adp.Fill(ds, "list");
            //    textBox1.Text = (int.Parse(ds.Tables["list"].Rows[0][0].ToString()) + 1).ToString();
            //}
            //catch (Exception)
            //{
            //    textBox1.Text = "1";
            //}
            list();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from client1 where custid="+listView1.SelectedItems[0].SubItems[0].Text+"", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                list();
            }
            else
                MessageBox.Show("Error.. Select Name from list.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select * from client1 where regid='" + textBox1.Text + "'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                //if (ds.Tables["list"].Rows.Count > 0)
                //{
                //    label9.Visible = true;
                //}
                //else
                //    label9.Visible = false;
                if (ds.Tables["list"].Rows.Count > 0)
                {
                    button1.Text = "Update";
                    textBox2.Text = ds.Tables["list"].Rows[0]["aname"].ToString();
                    try
                    {
                        dateTimePicker1.Value = DateTime.Parse(ds.Tables["list"].Rows[0]["dob"].ToString());
                    }
                    catch (Exception) { }
                    if (ds.Tables["list"].Rows[0]["gender"].ToString() == "True")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                        radioButton2.Checked = false;
                    textBox3.Text = ds.Tables["list"].Rows[0]["address"].ToString();
                    textBox4.Text = ds.Tables["list"].Rows[0]["contact"].ToString();
                    textBox5.Text = ds.Tables["list"].Rows[0]["email"].ToString();
                    textBox6.Text = ds.Tables["list"].Rows[0]["econtactper"].ToString();
                    textBox7.Text = ds.Tables["list"].Rows[0]["econtact"].ToString();
                    textBox8.Text = ds.Tables["list"].Rows[0]["remark"].ToString();
                }
                else
                {
                    button1.Text = "Submit";
                    clear();
                }
            }
            catch (Exception) 
            {
                label9.Visible = false;
            }
            if (textBox1.Text == "")
            {
                label9.Visible = true;
            }
        }
    }
}
