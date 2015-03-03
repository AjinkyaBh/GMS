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
    public partial class cost_report : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        public cost_report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new OleDbDataAdapter("select aname from client where custid=" + textBox1.Text + " and ref<>'trtr'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                label6.Text = ds.Tables["list"].Rows[0][0].ToString();


                adp = new OleDbDataAdapter("select * from client where custid=" + textBox1.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                label3.Text = ds.Tables["list"].Rows[0]["dob"].ToString();
                if (ds.Tables["list"].Rows[0]["gender"].ToString() == "True")
                    label7.Text = "Male";
                else
                    label7.Text = "Female";
                label14.Text = ds.Tables["list"].Rows[0]["econtactper"].ToString()+" ("+ds.Tables["list"].Rows[0]["econtact"].ToString()+")";
                label9.Text = ds.Tables["list"].Rows[0]["contact"].ToString();
                label11.Text = ds.Tables["list"].Rows[0]["email"].ToString();
                label17.Text = ds.Tables["list"].Rows[0]["address"].ToString();

                if (ds.Tables["list"].Rows[0]["q1"].ToString() == "True")
                    label24.ForeColor = Color.Red;
                else
                    label24.ForeColor = Color.Black;
                if (ds.Tables["list"].Rows[0]["q2"].ToString() == "True")
                    label23.ForeColor = Color.Red;
                else
                    label23.ForeColor = Color.Black;
                if (ds.Tables["list"].Rows[0]["q3"].ToString() == "True")
                    label22.ForeColor = Color.Red;
                else
                    label22.ForeColor = Color.Black;
                if (ds.Tables["list"].Rows[0]["q4"].ToString() == "True")
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.Black;
                if (ds.Tables["list"].Rows[0]["q5"].ToString() == "True")
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;
                if (ds.Tables["list"].Rows[0]["q6"].ToString() == "True")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;
                if (ds.Tables["list"].Rows[0]["q7"].ToString() == "True")
                    label68.ForeColor = Color.Red;
                else
                    label68.ForeColor = Color.Black;
                if (ds.Tables["list"].Rows[0]["q8"].ToString() != "")
                {
                    label69.ForeColor = Color.Red;
                    label70.ForeColor = Color.Red;
                    label65.ForeColor = Color.Red;
                    label65.Text = ds.Tables["list"].Rows[0]["q8"].ToString();
                }
                else
                {
                    label69.ForeColor = Color.Black;
                    label70.ForeColor = Color.Black;
                    label65.ForeColor = Color.Black;
                    label65.Text = "-";
                }

                string d = ds.Tables["list"].Rows[0]["coupleid"].ToString();
                if (int.Parse(d) > 0)
                {
                    //try
                    //{
                        adp1 = new OleDbDataAdapter("select aname from client where custid=" + d + "", con);
                        ds1 = new DataSet();
                        adp1.Fill(ds1, "list1");
                        label15.Text = ds1.Tables["list1"].Rows[0][0].ToString();
                    //}
                    //catch (Exception) 
                    //{
                    //    MessageBox.Show("Error");
                    //}
                }
                else
                    label15.Text = "No";


                adp = new OleDbDataAdapter("select * from cust_info where cid=" + textBox1.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                int m = (ds.Tables["list"].Rows.Count - 1);
                if (m >= 0)
                {
                    int dd, mm, yy, ddd;
                    dd = int.Parse(ds.Tables["list"].Rows[m][25].ToString());
                    mm = int.Parse(ds.Tables["list"].Rows[m][0].ToString());
                    yy = int.Parse(ds.Tables["list"].Rows[m][1].ToString());
                    ddd = int.Parse(ds.Tables["list"].Rows[m][24].ToString());

                    label63.Text = dd + "/" + mm + "/" + yy;
                    mm = mm + ddd;
                    if (mm > 12)
                    {
                        mm = mm - 12;
                        yy++;
                    }
                    if (mm > 12)
                    {
                        mm = mm - 12;
                        yy++;
                    }
                    label66.Text = dd + "/" + mm + "/" + yy;
                    //MessageBox.Show(dd.ToString());
                    int ex = int.Parse(ds.Tables["list"].Rows[m][27].ToString());
                    //MessageBox.Show(ex.ToString());
                    if (ex > 0)
                    {
                        mm = mm + ex;
                        if (mm > 12)
                        {
                            mm = mm - 12;
                            yy++;
                        }
                        if (mm > 12)
                        {
                            mm = mm - 12;
                            yy++;
                        }
                        label66.Text = dd + "/" + mm + "/" + yy + " Extended by (" + ex + ") Month  (Reason:" + ds.Tables["list"].Rows[m][29].ToString()+")";
                    }
                    
                    label64.Text = ds.Tables["list"].Rows[0][25].ToString() + "/" + ds.Tables["list"].Rows[0][0].ToString() + "/" + ds.Tables["list"].Rows[0][1].ToString();

                    label41.Text = ds.Tables["list"].Rows[m][3].ToString();
                    label42.Text = ds.Tables["list"].Rows[m][5].ToString();
                    label43.Text = ds.Tables["list"].Rows[m][7].ToString();
                    label44.Text = ds.Tables["list"].Rows[m][9].ToString();
                    label45.Text = ds.Tables["list"].Rows[m][11].ToString();
                    label46.Text = ds.Tables["list"].Rows[m][13].ToString();
                    label47.Text = ds.Tables["list"].Rows[m][15].ToString();
                    label48.Text = ds.Tables["list"].Rows[m][17].ToString();
                    label49.Text = ds.Tables["list"].Rows[m][4].ToString();
                    label50.Text = ds.Tables["list"].Rows[m][6].ToString();
                    label51.Text = ds.Tables["list"].Rows[m][8].ToString();
                    label52.Text = ds.Tables["list"].Rows[m][10].ToString();
                    label53.Text = ds.Tables["list"].Rows[m][12].ToString();
                    label54.Text = ds.Tables["list"].Rows[m][14].ToString();
                    label55.Text = ds.Tables["list"].Rows[m][16].ToString();
                    label56.Text = ds.Tables["list"].Rows[m][18].ToString();
                    label59.Text = ds.Tables["list"].Rows[m][23].ToString();
                    label60.Text = ds.Tables["list"].Rows[m][24].ToString()+" Month";
                }
                else
                {
                    label41.Text = "-";
                    label42.Text = "-";
                    label43.Text = "-";
                    label44.Text = "-";
                    label45.Text = "-";
                    label46.Text = "-";
                    label47.Text = "-";
                    label48.Text = "-";
                    label49.Text = "-";
                    label50.Text = "-";
                    label51.Text = "-";
                    label52.Text = "-";
                    label53.Text = "-";
                    label54.Text = "-";
                    label55.Text = "-";
                    label56.Text = "-";
                    label59.Text = "-";
                    label60.Text = "-";
                    label64.Text = "-";
                    label63.Text = "-";
                    label66.Text = "-";
                }
            }
            catch (Exception)
            {
                label6.Text = "-";
                label3.Text = "-";
                label9.Text = "-";
                label17.Text = "-";
                label14.Text = "-";
                label15.Text = "-";
                label7.Text = "-";
                label11.Text = "-";
                label41.Text = "-";
                label42.Text = "-";
                label43.Text = "-";
                label44.Text = "-";
                label45.Text = "-";
                label46.Text = "-";
                label47.Text = "-";
                label48.Text = "-";
                label49.Text = "-";
                label50.Text = "-";
                label51.Text = "-";
                label52.Text = "-";
                label53.Text = "-";
                label54.Text = "-";
                label55.Text = "-";
                label56.Text = "-";
                label59.Text = "-";
                label60.Text = "-";
                label64.Text = "-";
                label63.Text = "-";
                label66.Text = "-";

                label19.ForeColor = Color.Black;
                label20.ForeColor = Color.Black;
                label21.ForeColor = Color.Black;
                label22.ForeColor = Color.Black;
                label23.ForeColor = Color.Black;
                label24.ForeColor = Color.Black;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                try
                {
                    label6.Text = listView2.SelectedItems[0].SubItems[1].Text;
                    textBox1.Text = listView2.SelectedItems[0].SubItems[0].Text;
                    //listView2.Items.Clear();
                   // listView1.Items.Clear();
                    
                }
                catch (Exception) { label6.Text = "-"; }
            }
        }

        private void cost_report_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            adp = new OleDbDataAdapter("select custid,aname from client where ref<>'trtr' and custid<>0 order by custid", con);
            ds = new DataSet();
            adp.Fill(ds, "list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView2.Items.Add(ds.Tables["list"].Rows[i][0].ToString());
                listView2.Items[i].SubItems.Add(ds.Tables["list"].Rows[i][1].ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
