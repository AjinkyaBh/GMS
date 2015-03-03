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
    public partial class admission_info_update : Form
    {
        public int id = 0;
        int flag = 0;
        int flag1 = 0;
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public admission_info_update()
        {
            InitializeComponent();
        }

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
            textBox11.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;

            label19.Text = "-";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
                //adp = new OleDbDataAdapter("select id,aname,dob,address,gender,profession,contact,email,econtact,coupleid,q1,q2,q3,q4,q5,q6,econtactper from client where custid=" + textBox10.Text + "", con);
            if (textBox10.Text == "")
            {
                MessageBox.Show("plz write Adminssion ID");
            }
            else
            {
                adp = new OleDbDataAdapter("select * from client where custid=" + textBox10.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
            }
                if (ds.Tables["list"].Rows.Count > 0)
                {
                    label2.Visible = false;
                    textBox3.Text = ds.Tables["list"].Rows[0]["id"].ToString();
                    textBox1.Text = ds.Tables["list"].Rows[0]["aname"].ToString();
                    try
                    {
                        dateTimePicker1.Value = DateTime.Parse(ds.Tables["list"].Rows[0][2].ToString());
                    }
                    catch (Exception)
                    { }
                    textBox2.Text = ds.Tables["list"].Rows[0]["address"].ToString();
                    if (ds.Tables["list"].Rows[0]["gender"].ToString() == "True")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                    //textBox8.Text = ds.Tables["list"].Rows[0][""].ToString();
                    textBox4.Text = ds.Tables["list"].Rows[0]["profession"].ToString();
                    textBox5.Text = ds.Tables["list"].Rows[0]["contact"].ToString();
                    textBox6.Text = ds.Tables["list"].Rows[0]["email"].ToString();
                    textBox7.Text = ds.Tables["list"].Rows[0]["econtact"].ToString();
                    textBox9.Text = ds.Tables["list"].Rows[0]["coupleid"].ToString();
                    adp = new OleDbDataAdapter("select econtactper from client where custid=" + textBox10.Text + "", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    textBox11.Text = ds.Tables["list"].Rows[0][0].ToString();
                    adp = new OleDbDataAdapter("select q1,q2,q3,q4,q5,q6,q7,q8 from client where custid=" + textBox10.Text + "", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");

                  
                    
                    checkBox1.Checked = bool.Parse(ds.Tables["list"].Rows[0]["q1"].ToString());
                    checkBox2.Checked = bool.Parse(ds.Tables["list"].Rows[0]["q2"].ToString());
                    checkBox3.Checked = bool.Parse(ds.Tables["list"].Rows[0]["q3"].ToString());
                    checkBox4.Checked = bool.Parse(ds.Tables["list"].Rows[0]["q4"].ToString());
                    checkBox5.Checked = bool.Parse(ds.Tables["list"].Rows[0]["q5"].ToString());
                    checkBox6.Checked = bool.Parse(ds.Tables["list"].Rows[0]["q6"].ToString());
                    checkBox7.Checked = bool.Parse(ds.Tables["list"].Rows[0]["q7"].ToString());
                    if (ds.Tables["list"].Rows[0]["q8"].ToString().Trim() != "")
                    {
                        checkBox8.Checked = true;
                        textBox12.Text = ds.Tables["list"].Rows[0]["q8"].ToString();
                    }
                    else
                    {
                        checkBox8.Checked = false;
                        textBox12.Text = "";
                    }
                }
                else
                {
                    label2.Visible = true;
                    clear();
                }
            //}
            //catch (Exception)
            //{
            //    label2.Visible = true;
            //    clear();
            //}
        }

        private void admission_info_update_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                flag1 = 1;
                adp = new OleDbDataAdapter("select aname from client where custid=" + textBox9.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                label19.Text = ds.Tables["list"].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                flag1 = 1;
                label19.Text = "-";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != "")
            {
                if (label2.Visible == false)
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
                        int id = 0;
                        string ddd;
                        if (dateTimePicker1.Value.Month == DateTime.Now.Month && dateTimePicker1.Value.Day == DateTime.Now.Day && dateTimePicker1.Value.Year == DateTime.Now.Year)
                        {
                            ddd = "0/0/0";
                        }
                        else
                            ddd = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
                        
                        //try
                        //{

                        //    id = int.Parse(textBox10.Text);
                        //}
                        //catch (Exception)
                        //{
                        //    MessageBox.Show("Error.. Incorrect Admission ID.");
                            
                        //    id = 0;
                        //}
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
                        adp = new OleDbDataAdapter("update client set q7='" + checkBox6.Checked.ToString() + "' where id=" + textBox3.Text + "", con);
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
                        //adp = new OleDbDataAdapter("update client set age=" + textBox8.Text + " where id=" + textBox3.Text + "", con);
                        //ds = new DataSet();
                        //adp.Fill(ds, "list");
                        adp = new OleDbDataAdapter("update client set contact=" + textBox5.Text + " where id=" + textBox3.Text + "", con);
                        ds = new DataSet();
                        adp.Fill(ds, "list");
                        adp = new OleDbDataAdapter("update client set email='" + textBox6.Text + "' where id=" + textBox3.Text + "", con);
                        ds = new DataSet();
                        adp.Fill(ds, "list");
                        adp = new OleDbDataAdapter("update client set econtactper='" + textBox11.Text + "' where id=" + textBox3.Text + "", con);
                        ds = new DataSet();
                        adp.Fill(ds, "list");

                        //adp = new OleDbDataAdapter("update client set custid=" + id + " where id=" + textBox3.Text + "", con);
                        //ds = new DataSet();
                        //adp.Fill(ds, "list");
                        if (label19.Text != "-")
                        {
                            adp = new OleDbDataAdapter("update client set coupleid=" + textBox10.Text + " where custid=" + textBox9.Text + "", con);
                            ds = new DataSet();
                            adp.Fill(ds, "list");
                        }
                        MessageBox.Show("Record Inserted.. Your Gym ID is" + textBox10.Text);
                        clear();
                    }
                    else
                        MessageBox.Show("Error.. Insert All Details.");
                }
                else
                    MessageBox.Show("Error.. Insert Available Admission ID.");
            }
            else
                MessageBox.Show("Error.. Insert Enquiry ID first.");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dateTimePicker1.Value.Year.ToString());
            if (int.Parse(DateTime.Now.Month.ToString()) > int.Parse(dateTimePicker1.Value.Month.ToString()))
            {
                age--;
            }
            else if (int.Parse(DateTime.Now.Month.ToString()) == int.Parse(dateTimePicker1.Value.Month.ToString()))
            {
                if (int.Parse(DateTime.Now.Day.ToString()) >= int.Parse(dateTimePicker1.Value.Day.ToString()))
                {
                    age--;
                }
            }
            textBox8.Text = age.ToString();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                label29.Visible = true;
                textBox12.Visible = true;
            }
            else
            {
                label29.Visible = false;
                textBox12.Visible = false;
                textBox12.Text = "";
            }
        }
    }
}
