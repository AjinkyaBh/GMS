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
    public partial class extension : Form
    {
        public string pathh = Application.StartupPath.ToString();
        OleDbConnection con, con1, con2;
        DataSet ds, ds1;
        OleDbDataAdapter adp, adp1;
        string edate = "";
        int mm1=0, yy1=0,ex,mm2=0,yy2=0;
        public extension()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label19.Visible = false;
            try
            {
                adp = new OleDbDataAdapter("select aname,contact,address from client where custid=" + textBox1.Text + " and ref<>'trtr'", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                label10.Text = ds.Tables["list"].Rows[0][0].ToString();
                label11.Text = ds.Tables["list"].Rows[0][1].ToString();
                label12.Text = ds.Tables["list"].Rows[0][2].ToString();
            }
            catch (Exception) 
            {
                label10.Text = "-";
                label11.Text = "-";
                label12.Text = "-";
            }

            try
            {
                adp = new OleDbDataAdapter("select max(yy) from cust_info where cid=" + textBox1.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                int yy = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
                //MessageBox.Show(""+yy);
                adp = new OleDbDataAdapter("select max(mm) from cust_info where cid=" + textBox1.Text + " and yy="+yy+"", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                int mm = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
              //  MessageBox.Show("" + mm);
                adp = new OleDbDataAdapter("select cplan,personal_training,weight_loss,dd,mm,yy,cduration,ex from cust_info where cid=" + textBox1.Text + " and yy="+yy+" and mm="+mm+"", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                int max = ds.Tables["list"].Rows.Count;
                DateTime d;
                max--;
              //  MessageBox.Show("" + max);

                label13.Text = ds.Tables["list"].Rows[max][0].ToString();
                label14.Text = ds.Tables["list"].Rows[max][1].ToString();
                label15.Text = ds.Tables["list"].Rows[max][2].ToString();
                int ddd, mmm, yyy,newmm;
                ddd = int.Parse(ds.Tables["list"].Rows[max][3].ToString());
                mmm = int.Parse(ds.Tables["list"].Rows[max][4].ToString());
                yyy = int.Parse(ds.Tables["list"].Rows[max][5].ToString());

                label16.Text = ddd + "/" + mmm + "/" + yyy;
                newmm=mmm+int.Parse(ds.Tables["list"].Rows[max][6].ToString());
                if (newmm > 12)
                {
                    newmm = newmm - 12;
                    yyy++;
                }
                if (newmm > 12)
                {
                    newmm = newmm - 12;
                    yyy++;
                }
                mm1 = newmm;
                yy1 = yyy;
                mm2 = newmm;
                yy2 = yyy;
                label17.Text = ddd + "/" + newmm + "/" + yyy;
                ex = int.Parse(ds.Tables["list"].Rows[max][7].ToString());
                if (ex > 0)
                {
                    newmm = newmm + ex;
                    if (newmm > 12)
                    {
                        newmm = newmm - 12;
                        yyy++;
                    }
                    if (newmm > 12)
                    {
                        newmm = newmm - 12;
                        yyy++;
                    }
                    label17.Text = ddd + "/" + newmm + "/" + yyy+" Extended by ("+ex+") Month";
                    edate = ddd + "/" + newmm + "/" + yyy;
                }
                try
                {
                    adp = new OleDbDataAdapter("select ex from cust_info where cid=" + textBox1.Text + " and yy=" + yy + " and mm=" + mm + "", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                    if (ds.Tables["list"].Rows[0][0].ToString() != "0")
                    {
                        label19.Visible = true;
                    }
                    else
                        label19.Visible = false;
                }
                catch (Exception)
                {
                    label19.Visible = false;
                }
                //d.Day = int.Parse(ds.Tables["list"].Rows[max][3].ToString());
                //d.Month= int.Parse(ds.Tables["list"].Rows[max][4].ToString());
                //d.Year= int.Parse(ds.Tables["list"].Rows[max][5].ToString());
            }
            catch (Exception) 
            {
                label13.Text = "-";
                label14.Text = "-";
                label15.Text = "-";
                label16.Text = "-";
                label17.Text = "-";
            }
        }

        private void extension_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && label10.Text != "-")
            {
                if (textBox2.Text.Trim() == "")
                {
                    textBox2.Text = "-";
                }
                int mm, yy;
                adp = new OleDbDataAdapter("select max(yy) from cust_info where cid=" + textBox1.Text + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                yy = int.Parse(ds.Tables["list"].Rows[0][0].ToString());

                adp = new OleDbDataAdapter("select max(mm) from cust_info where cid=" + textBox1.Text + " and yy=" + yy + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                mm = int.Parse(ds.Tables["list"].Rows[0][0].ToString());

                adp = new OleDbDataAdapter("update cust_info set ex=" + comboBox1.Text + " where cid=" + textBox1.Text + " and mm=" + mm + " and yy=" + yy + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");

                adp = new OleDbDataAdapter("update cust_info set exin='" + edate + "' where cid=" + textBox1.Text + " and mm=" + mm + " and yy=" + yy + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");

                adp = new OleDbDataAdapter("update cust_info set exr='" + textBox2.Text + "' where cid=" + textBox1.Text + " and mm=" + mm + " and yy=" + yy + "", con);
                ds = new DataSet();
                adp.Fill(ds, "list");
                
                for (int i = 0; i < ex; i++)
                {
                    mm1++;
                    if (mm1 == 13)
                    {
                        yy1++;
                        mm1 = 1;
                    }
                    adp = new OleDbDataAdapter("delete table from cust_info_m where cid=" + textBox1.Text + " and mm=" + mm1 + " and yy=" + yy1 + "", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                }
                for (int i = 0; i < int.Parse(comboBox1.Text); i++)
                {
                    mm2++;
                    if (mm2 == 13)
                    {
                        yy2++;
                        mm2 = 1;
                    }
                    adp = new OleDbDataAdapter("insert into cust_info_m values(" + mm2 + "," + yy2 + "," + textBox1.Text + ",'" + label14.Text + "','',0)", con);
                    ds = new DataSet();
                    adp.Fill(ds, "list");
                }

                MessageBox.Show("Plant Extended successfully.");

                textBox1.Text = "";
                textBox2.Text = "";
                label10.Text = "-";
                label11.Text = "-";
                label12.Text = "-";
                label13.Text = "-";
                label14.Text = "-";
                label15.Text = "-";
                label16.Text = "-";
                label17.Text = "-";
            }
            else
                MessageBox.Show("Error.. Insert all details.");
        }
    }
}
