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
    public partial class add_remove_msg : Form
    {
        OleDbConnection con;
        OleDbDataAdapter adt;
        DataSet ds;
        int d = 0;

        public string pathh = Application.StartupPath.ToString();

        public add_remove_msg()
        {
            InitializeComponent();
        }


        public void fun1()
        {
            listView1.Items.Clear();

            adt=new OleDbDataAdapter("select title_no,title from add_remove_msg",con);
            ds=new DataSet();
            adt.Fill(ds,"list");
            for (int i = 0; i < ds.Tables["list"].Rows.Count; i++)
            {
                listView1.Items.Add(ds.Tables["list"].Rows[i]["title_no"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables["list"].Rows[i]["title"].ToString());
            }



        }


        public void num()
        {

            adt = new OleDbDataAdapter("select max(title_no) from add_remove_msg", con);
            ds = new DataSet();
            adt.Fill(ds, "list");
            try
            {

                d = int.Parse(ds.Tables["list"].Rows[0][0].ToString());
            }
            catch (Exception) { }
            d++;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            num();
            adt = new OleDbDataAdapter("insert into add_remove_msg values("+d+",'"+textBox2.Text+"','')",con);
            ds = new DataSet();
            adt.Fill(ds, "list");
            MessageBox.Show("Message Title Added...");
            fun1();
            textBox2.Text = "";

        }

        private void add_remove_msg_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathh + @"\dbb\db.mdb");
            fun1();



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (listView1.SelectedItems.Count > 0)
            {
                adt = new OleDbDataAdapter("select title_no,title,msg_text from add_remove_msg where title_no=" + listView1.SelectedItems[0].SubItems[0].Text + "", con);
                ds = new DataSet();
                adt.Fill(ds, "list");

                label6.Text = ds.Tables["list"].Rows[0][0].ToString();
                label7.Text = ds.Tables["list"].Rows[0][1].ToString();
                textBox1.Text = ds.Tables["list"].Rows[0]["msg_text"].ToString();

                

            }
          //  fun1();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                adt = new OleDbDataAdapter("delete table from add_remove_msg where title_no=" + listView1.SelectedItems[0].SubItems[0].Text + "", con);
                ds = new DataSet();
                adt.Fill(ds, "list");
                MessageBox.Show("Remove successfully...");
                fun1();
                label6.Text = "";
                label7.Text = "";
                textBox1.Text = "";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            adt = new OleDbDataAdapter("update add_remove_msg set msg_text='"+textBox1.Text+"' where title_no="+label6.Text+" ",con);

            ds = new DataSet();
            adt.Fill(ds, "list");
            MessageBox.Show("Message Inserted Successfully..");
            label6.Text = "";
            label7.Text = "";
            textBox1.Text = "";


        }
    }
}
