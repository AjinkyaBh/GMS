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
    public partial class Home_Page : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        int dd, mm, yy;
        public string login = "";
        public string user = "";
        public Home_Page(string l,string u)
        {
            InitializeComponent();
            login = l;
            user = u;
        }

        public void list3()
        {
            listView5.Items.Clear();
            int dr, ex;

            adp = new OleDbDataAdapter("select cid,dd,exin from cust_info where exin like '%/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "'", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            //MessageBox.Show("" + ds.Tables["list"].Rows.Count);
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                //dd = int.Parse(ds.Tables["list"].Rows[i][2].ToString());
                //mm = int.Parse(ds.Tables["list"].Rows[i][3].ToString());
                //yy = int.Parse(ds.Tables["list"].Rows[i][4].ToString());
                //dr = int.Parse(ds.Tables["list"].Rows[i][5].ToString());
                //ex = int.Parse(ds.Tables["list"].Rows[i][6].ToString());
                //listView5.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                //mm = mm + dr + ex;
                //for (int ii = 0; ii < 6; ii++)
                //{
                //    if (mm > 12)
                //    {
                //        mm = mm - 12;
                //        yy++;
                //    }
                //    else
                //        break;
                //}
                listView5.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView5.Items[i].SubItems.Add("-");
                listView5.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString());
                try
                {
                    adp1 = new OleDbDataAdapter("select aname from client where custid=" + ds.Tables["list"].Rows[i][0].ToString() + "", con);
                    ds1 = new DataSet();
                    adp1.Fill(ds1, "list1");
                    listView5.Items[i].SubItems[1].Text = ds1.Tables["list1"].Rows[0][0].ToString();
                }
                catch (Exception) { }
            }
        }

        public void attlist()
        {
            listView1.Items.Clear();
            listView4.Items.Clear();
            adp = new OleDbDataAdapter("select c.custid,c.aname from client c,attendance a where a.dd="+dd+" and a.mm="+mm+" and a.yy="+yy+" and a.cid=c.custid and c.ref<>'trtr'", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView1.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
            }

            adp = new OleDbDataAdapter("select c.regid,c.aname from client1 c,attendance a where a.dd=" + dd + " and a.mm=" + mm + " and a.yy=" + yy + " and a.regid=c.regid and c.ref='trtr'", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView4.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView4.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
            }
        }

        public void list()
        {
            listView3.Items.Clear();

            adp = new OleDbDataAdapter("select p.regno,c.aname,p.pouchno from pouch p,client c where c.custid=p.regno and p.pdate='" + mm + "/" + dd + "/" + yy + "' and p.status='y' order by p.regno", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView3.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView3.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                listView3.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString());
            }
        }
        public void list2()
        {
            listView2.Items.Clear();
            adp = new OleDbDataAdapter("select id,aname,edate,remark from client where custid=0", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView2.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
                listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][2].ToString());
                listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][3].ToString());
            }
        }

        private void newEnquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_enquiry n = new new_enquiry();
            n.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tranerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payment_trainer p = new payment_trainer();
            p.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payment p = new payment();
            p.Show();
        }

        private void customerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_info c = new Customer_info();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void admissionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admission  z = new Admission();
            z.Show();
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gap_form g = new gap_form();
            g.Show();
        }

        private void Home_Page_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(login + " " + user);
            dd = dateTimePicker1.Value.Day;
            mm = dateTimePicker1.Value.Month;
            yy = dateTimePicker1.Value.Year;
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            if (login == "User")
            {
                reportsToolStripMenuItem.Enabled = false;
                breakToolStripMenuItem.Enabled = false;
                tranerToolStripMenuItem.Enabled = false;
            }
            list2();
            list();
            attlist();
            list3();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void monthlyEmployeeAttemdanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emp_Attendence m = new Emp_Attendence();
            m.user = "emp";
            m.Show();
            
        }

        private void monthlyCustomerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cus_Attendence cu = new Cus_Attendence();
            //cu.Show();
            Emp_Attendence m = new Emp_Attendence();
            m.user = "client";
            m.Show();
        }

        private void monthlyEmployeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emp_Pay_Repo m = new Emp_Pay_Repo();
            m.user = "emp";
            m.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select aname from client where custid="+textBox2.Text+"", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                label10.Text = ds.Tables["list"].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                label10.Text = "-";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                adp = new OleDbDataAdapter("insert into pouch values(" + textBox2.Text + ",'" + DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year + "','" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "',"+textBox3.Text+",'y')", con);
                ds = new DataSet();
                adp.Fill(ds, "list");

                textBox2.Text = "";
                textBox3.Text = "";
                list();
            }
        }

        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("update pouch set status='d' where regno=" + listView3.SelectedItems[0].SubItems[0].Text + " and pdate='" + DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year + "'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                list();
            }
        }

        private void addTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_trainer a = new add_trainer();
            a.Show();
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            Admission a = new Admission();
            
            a.id = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            a.Show();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label12.Text != "-")
            {
                int max = 0;
                try
                {
                    adp = new OleDbDataAdapter("select max(id) from attendance", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    max = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                }
                catch (Exception) { }
                max++;

                adp = new OleDbDataAdapter("insert into attendance values(" + max + "," +dd + "," + mm + "," +yy + ",'" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "'," + textBox1.Text + ",'','','')", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                textBox1.Text = "";
            }
            attlist();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select aname from client where custid=" + textBox1.Text + " and ref<>'trtr'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                if (ds.Tables["list"].Rows.Count > 0)
                    label12.Text = ds.Tables["list"].Rows[0][0].ToString();
                else
                    label12.Text = "-";
            }
            catch (Exception)
            {
                label12.Text = "-";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select aname from client1 where regid='" + textBox4.Text + "' and ref='trtr'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                if (ds.Tables["list"].Rows.Count > 0)
                    label13.Text = ds.Tables["list"].Rows[0][0].ToString();
                else
                    label13.Text = "-";
            }
            catch (Exception)
            {
                label13.Text = "-";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label13.Text != "-")
            {
                int max = 0;
                try
                {
                    adp = new OleDbDataAdapter("select max(id) from attendance", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    max = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                }
                catch (Exception) { }
                max++;

                adp = new OleDbDataAdapter("insert into attendance values(" + max + "," + dd + "," + mm + "," + yy + ",'" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "',-1,'','','"+textBox4.Text+"')", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                textBox4.Text = "";
                attlist();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from attendance where dd=" + dd + " and mm=" + mm + " and yy=" + yy + " and cid=" + listView1.SelectedItems[0].SubItems[0].Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                attlist();
            }
            else
                MessageBox.Show("Error.. Select ID from list");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from attendance where dd=" + dd + " and mm=" + mm + " and yy=" + yy + " and regid='" + listView4.SelectedItems[0].SubItems[0].Text + "'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                attlist();
            }
            else
                MessageBox.Show("Error.. Select ID from list");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dd = dateTimePicker1.Value.Day;
            mm = dateTimePicker1.Value.Month;
            yy = dateTimePicker1.Value.Year;
            list();
            attlist();
        }

        private void monthlyCustomerPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emp_Pay_Repo m = new Emp_Pay_Repo();
            m.user = "client";
            m.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_pass c = new change_pass();
            c.user = user;
            c.priority = login;
            c.Show();
        }

        private void customerInfoReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cost_report c = new cost_report();
            c.Show();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData.ToString() == "Return")
            {
                if (label12.Text != "-")
                {
                    int max = 0;
                    try
                    {
                        adp = new OleDbDataAdapter("select max(id) from attendance", con);
                        ds = new DataSet();
                        adp.Fill(ds, "list");
                        max = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                    }
                    catch (Exception) { }
                    max++;

                    adp = new OleDbDataAdapter("insert into attendance values(" + max + "," + dd + "," + mm + "," + yy + ",'" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "'," + textBox1.Text + ",'','','')", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    textBox1.Text = "";
                }
                attlist();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                if (label13.Text != "-")
                {
                    int max = 0;
                    try
                    {
                        adp = new OleDbDataAdapter("select max(id) from attendance", con);
                        ds = new DataSet();
                        adp.Fill(ds, "list");
                        max = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                    }
                    catch (Exception) { }
                    max++;

                    adp = new OleDbDataAdapter("insert into attendance values(" + max + "," + dd + "," + mm + "," + yy + ",'" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "',0,'','','"+textBox4.Text+"')", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    textBox4.Text = "";
                    attlist();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    adp = new OleDbDataAdapter("insert into pouch values(" + textBox2.Text + ",'" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + "','" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "'," + textBox3.Text + ",'y')", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");

                    textBox2.Text = "";
                    textBox3.Text = "";
                    list();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                adp = new OleDbDataAdapter("delete table from client where id="+listView2.SelectedItems[0].SubItems[0].Text+"", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                list2();
            }
            else
                MessageBox.Show("Error.. Select ID from list");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list2();
            list();
            attlist();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            list3();
            list2();
            list();
            attlist();
        }

        private void extensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extension ee = new extension();
            ee.Show();
        }

        private void updateAdmissionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admission_info_update a = new admission_info_update();
            a.Show();
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emp_report r = new emp_report();
            r.Show();
        }

        private void messageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msg_box msg = new msg_box();
            msg.Show();

        }

        private void addRemoveMessageFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_remove_msg arm = new add_remove_msg();
            arm.Show();

        }
    }
}
