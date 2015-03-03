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
    public partial class Customer_info : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public Customer_info()
        {
            InitializeComponent();
        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            comboBox4.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            checkBox1.Checked = false;
            checkBox13.Checked = false;
            comboBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Customer_info_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            comboBox1.Text = DateTime.Now.Month.ToString();
            comboBox2.Text = DateTime.Now.Year.ToString();

            textBox1.Text = "Text";
            textBox1.Text = "";
            adp = new OleDbDataAdapter("select aname from client1 where ref='trtr' order by aname", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                comboBox3.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                label18.Visible = true;
                label15.Visible = true;
                textBox14.Visible = true;
            }
            else
            {
                label18.Visible = false;
                label15.Visible = false;
                textBox14.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //try
            //{
            if (textBox15.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && textBox12.Text != "")
                {
                    string t1, t2;
                    if (checkBox1.Checked == true)
                    {
                        t1 = comboBox3.Text;
                    }
                    else
                        t1 = "";
                    if (checkBox13.Checked == true)
                    {
                        t2 = textBox14.Text;
                    }
                    else
                        t2 = "";
                    int dd = int.Parse(dateTimePicker1.Value.Day.ToString());
                    int mm = int.Parse(dateTimePicker1.Value.Month.ToString());
                    int yy = int.Parse(dateTimePicker1.Value.Year.ToString());
                    int tm = 0;
                    if (comboBox4.Text == "Monthly")
                    {
                        tm = 1;
                    }
                    else if (comboBox4.Text == "Quarterly")
                    {
                        tm = 3;
                    }
                    else if (comboBox4.Text == "Half Year")
                    {
                        tm = 6;
                    }
                    else if (comboBox4.Text == "Yearly")
                    {
                        tm = 12;
                    }

                    int mmm = mm;
                    int yyy = yy;
                    mmm = mmm + tm;
                    if (mmm > 12)
                    {
                        mmm = mmm - 12;
                        yyy++;
                    }
                    int mm1 = 0, yy1 = 0;
                    mm1 = mm;
                    yy1 = yy;

                    adp = new OleDbDataAdapter("select * from cust_info where cid=" + textBox15.Text + " and mm=" + mm + " and yy=" + yy + " and dd="+dd+"", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    if (ds.Tables["list"].Rows.Count > 0)
                    {
                        if (MessageBox.Show("Do you want to update old Record..", "Update Plan or Records", MessageBoxButtons.YesNo).ToString() == "Yes")
                        {
                            adp = new OleDbDataAdapter("delete table from cust_info where cid=" + textBox15.Text + " and mm=" + mm + " and yy=" + yy + "", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");

                            adp = new OleDbDataAdapter("insert into cust_info values(" + mm + "," + yy + "," + textBox15.Text + ",'" + textBox2.Text + "','" + textBox21.Text + "','" + textBox3.Text + "','" + textBox20.Text + "','" + textBox4.Text + "','" + textBox19.Text + "','" + textBox5.Text + "','" + textBox18.Text + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox7.Text + "','" + textBox16.Text + "','" + textBox11.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + t1 + "','" + t2 + "','" + textBox12.Text + "','" + DateTime.Now.Date.ToShortDateString() + "','" + comboBox5.Text + "'," + tm + "," + dd + ",'',0,'" + dd + "/" + mmm + "/" + yyy + "','')", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                            for (int i = 0; i < tm; i++)
                            {
                                mm++;
                                if (mm == 13)
                                {
                                    yy++;
                                    mm = 1;
                                }
                                adp = new OleDbDataAdapter("delete table from cust_info_m where cid=" + textBox15.Text + " and mm=" + mm + " and yy=" + yy + "", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                            }

                            for (int i = 0; i < tm; i++)
                            {
                                mm1++;
                                if (mm1 == 13)
                                {
                                    yy1++;
                                    mm1 = 1;
                                }
                                adp = new OleDbDataAdapter("insert into cust_info_m values(" + mm1 + "," + yy1 + "," + textBox15.Text + ",'" + comboBox3.Text + "','',0)", con);
                                ds = new DataSet();
                                adp.Fill(ds, "list");
                            }
                            clear();
                            MessageBox.Show("Data Inserted..");
                        }

                    }
                    else
                    {
                        adp = new OleDbDataAdapter("insert into cust_info values(" + mm + "," + yy + "," + textBox15.Text + ",'" + textBox2.Text + "','" + textBox21.Text + "','" + textBox3.Text + "','" + textBox20.Text + "','" + textBox4.Text + "','" + textBox19.Text + "','" + textBox5.Text + "','" + textBox18.Text + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox7.Text + "','" + textBox16.Text + "','" + textBox11.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + t1 + "','" + t2 + "','" + textBox12.Text + "','" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "','" + comboBox5.Text + "'," + tm + "," + dd + ",'',0,'" + dd + "/" + mmm + "/" + yyy + "','')", con);
                        ds = new DataSet();
                        adp.Fill(ds, "list");

                        for (int i = 0; i < tm; i++)
                        {
                            mm++;
                            if (mm == 13)
                            {
                                yy++;
                                mm = 1;
                            }
                            adp = new OleDbDataAdapter("insert into cust_info_m values(" + mm + "," + yy + "," + textBox15.Text + ",'" + comboBox3.Text + "','',0)", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                        }
                        clear();
                        MessageBox.Show("Data Inserted..");
                    }   
                }
                else
                    MessageBox.Show("Error.. Insert All Details");
            //}
            //catch (Exception) 
            //{
            //    MessageBox.Show("Error..");
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            adp = new OleDbDataAdapter("select aname from client where aname like'" + textBox1.Text + "%' and ref<>'trtr' and custid<>0 order by aname", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables["list"].Rows[i]["aname"].ToString());
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label28.Visible = true;
                comboBox3.Visible = true;
            }
            else
            {
                label28.Visible = false;
                comboBox3.Visible = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count>0)
            {                
                adp = new OleDbDataAdapter("select custid,aname from client where aname='" + listBox1.SelectedItem.ToString() + "'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                textBox15.Text = ds.Tables["list"].Rows[0][0].ToString();
                try
                {
                    label32.Text = ds.Tables["list"].Rows[0][1].ToString();
                }
                catch (Exception) 
                {
                    label32.Text = listBox1.SelectedItem.ToString();
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select custid,aname from client where custid=" +textBox15.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                textBox15.Text = ds.Tables["list"].Rows[0][0].ToString();
                label32.Text = ds.Tables["list"].Rows[0][1].ToString();
                
                listView1.Items.Clear();
                adp = new OleDbDataAdapter("select i.mm,i.yy,i.personal_training,i.weight_loss,i.fees,i.cplan,i.cduration,i.dd,i.dd,i.mm,i.yy from client c,cust_info i where c.custid=i.cid and i.cid=" + textBox15.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i][7].ToString() + "/" + ds.Tables["list"].Rows[i][0].ToString() + "/" + ds.Tables["list"].Rows[i][1].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][3].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][4].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][5].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][6].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][8].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][9].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][10].ToString());
                }


                try
                {
                    adp = new OleDbDataAdapter("select * from cust_info where dd=" + dateTimePicker1.Value.Day + " and mm=" + dateTimePicker1.Value.Month + " and yy=" + dateTimePicker1.Value.Year + " and cid=" + textBox15.Text + "", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    
                    textBox2.Text = ds.Tables["list"].Rows[0]["weight"].ToString();
                    textBox3.Text = ds.Tables["list"].Rows[0]["height"].ToString();
                    textBox4.Text = ds.Tables["list"].Rows[0]["neck"].ToString();
                    textBox5.Text = ds.Tables["list"].Rows[0]["shoulder"].ToString();
                    textBox6.Text = ds.Tables["list"].Rows[0]["wrist"].ToString();
                    textBox7.Text = ds.Tables["list"].Rows[0]["upper_arm"].ToString();
                    textBox11.Text = ds.Tables["list"].Rows[0]["waist"].ToString();
                    textBox10.Text = ds.Tables["list"].Rows[0]["hips"].ToString();
                    textBox9.Text = ds.Tables["list"].Rows[0]["ankle"].ToString();
                    textBox8.Text = ds.Tables["list"].Rows[0]["calf"].ToString();
                    textBox16.Text = ds.Tables["list"].Rows[0]["expanded_chest"].ToString();
                    textBox17.Text = ds.Tables["list"].Rows[0]["normal_chest"].ToString();
                    textBox18.Text = ds.Tables["list"].Rows[0]["lower_abdomen"].ToString();
                    textBox19.Text = ds.Tables["list"].Rows[0]["thigh"].ToString();
                    textBox20.Text = ds.Tables["list"].Rows[0]["bmi"].ToString();
                    textBox21.Text = ds.Tables["list"].Rows[0]["whr"].ToString();
                    textBox12.Text = ds.Tables["list"].Rows[0]["fees"].ToString();
                    comboBox5.Text = ds.Tables["list"].Rows[0]["cplan"].ToString();
                    if ("1" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                    {
                        comboBox4.Text = "Monthly";
                    }
                    else if ("3" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                    {
                        comboBox4.Text = "Quarterly";
                    }
                    else if ("6" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                    {
                        comboBox4.Text = "Half Year";
                    }
                    else if ("12" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                    {
                        comboBox4.Text = "Yearly";
                    }
                    string s = ds.Tables["list"].Rows[0]["personal_training"].ToString();
                    if (s != "")
                    {
                        checkBox1.Checked = true;
                        comboBox3.Text = s;
                    }
                    s = ds.Tables["list"].Rows[0]["weight_loss"].ToString();
                    if (s != "")
                    {
                        checkBox13.Checked = true;
                        textBox14.Text = s;
                    }
                }
                catch (Exception)
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox11.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    textBox16.Text = "";
                    textBox17.Text = "";
                    textBox18.Text = "";
                    textBox19.Text = "";
                    textBox20.Text = "";
                    textBox21.Text = "";
                    textBox12.Text = "";
                    textBox14.Text = "";
                    comboBox5.Text = "";
                    comboBox4.Text = "";
                    checkBox1.Checked = false;
                    checkBox13.Checked = false;
                }
            }
            catch (Exception) 
            {
                label32.Text = "-";
                listView1.Items.Clear(); 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                adp = new OleDbDataAdapter("delete table from cust_info where cid=" + textBox15.Text + " and dd=" + listView1.SelectedItems[0].SubItems[6].Text + " and mm=" + listView1.SelectedItems[0].SubItems[7].Text + " and yy=" + listView1.SelectedItems[0].SubItems[8].Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                listView1.Items.Clear();
                adp = new OleDbDataAdapter("select i.mm,i.yy,i.personal_training,i.weight_loss,i.fees,i.cplan,i.cduration,i.dd,i.dd,i.mm,i.yy from client c,cust_info i where c.custid=i.cid and i.cid=" + textBox15.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
                {
                    listView1.Items.Add(ds.Tables["list"].Rows[i][7].ToString() + "/" + ds.Tables["list"].Rows[i][0].ToString() + "/" + ds.Tables["list"].Rows[i][1].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][3].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][4].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][5].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][6].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][8].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][9].ToString());
                    listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][10].ToString());
                }
            }
            else
                MessageBox.Show("Error.. Select record from list.");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                checkBox1.Checked = false;
                checkBox13.Checked = false;
                adp = new OleDbDataAdapter("select * from cust_info where dd=" + dateTimePicker1.Value.Day + " and mm=" + dateTimePicker1.Value.Month + " and yy=" + dateTimePicker1.Value.Year + " and cid=" + textBox15.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                textBox2.Text = ds.Tables["list"].Rows[0]["weight"].ToString();
                textBox3.Text = ds.Tables["list"].Rows[0]["height"].ToString();
                textBox4.Text = ds.Tables["list"].Rows[0]["neck"].ToString();
                textBox5.Text = ds.Tables["list"].Rows[0]["shoulder"].ToString();
                textBox6.Text = ds.Tables["list"].Rows[0]["wrist"].ToString();
                textBox7.Text = ds.Tables["list"].Rows[0]["upper_arm"].ToString();
                textBox11.Text = ds.Tables["list"].Rows[0]["waist"].ToString();
                textBox10.Text = ds.Tables["list"].Rows[0]["hips"].ToString();
                textBox9.Text = ds.Tables["list"].Rows[0]["ankle"].ToString();
                textBox8.Text = ds.Tables["list"].Rows[0]["calf"].ToString();
                textBox16.Text = ds.Tables["list"].Rows[0]["expanded_chest"].ToString();
                textBox17.Text = ds.Tables["list"].Rows[0]["normal_chest"].ToString();
                textBox18.Text = ds.Tables["list"].Rows[0]["lower_abdomen"].ToString();
                textBox19.Text = ds.Tables["list"].Rows[0]["thigh"].ToString();
                textBox20.Text = ds.Tables["list"].Rows[0]["bmi"].ToString();
                textBox21.Text = ds.Tables["list"].Rows[0]["whr"].ToString();
                textBox12.Text = ds.Tables["list"].Rows[0]["fees"].ToString();
                comboBox5.Text = ds.Tables["list"].Rows[0]["cplan"].ToString();
                if ("1" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                {
                    comboBox4.Text="Monthly";
                }
                else if ("3" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                {
                    comboBox4.Text="Quarterly";
                }
                else if ("6" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                {
                    comboBox4.Text="Half Year";
                }
                else if ("12" == ds.Tables["list"].Rows[0]["cduration"].ToString())
                {
                    comboBox4.Text = "Yearly";
                }
                string s=ds.Tables["list"].Rows[0]["personal_training"].ToString();
                if ( s!= "")
                {
                    checkBox1.Checked = true;
                    comboBox3.Text = s;
                }
                s=ds.Tables["list"].Rows[0]["weight_loss"].ToString();
                if (s != "")
                {
                    checkBox13.Checked = true;
                    textBox14.Text = s;
                }
            }
            catch (Exception) 
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox12.Text = "";
                textBox14.Text = "";
                comboBox5.Text = "";
                comboBox4.Text = "";
                checkBox1.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                dateTimePicker1.Value = DateTime.Parse( listView1.SelectedItems[0].SubItems[0].Text);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
