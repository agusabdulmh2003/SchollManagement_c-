using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Dasbor : Form
    {
        Service.scholl wbservice = new Service.scholl();
        public Dasbor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void Dasbor_Load(object sender, EventArgs e)
        {
            display();
            display1();
            display2();
            display3();
        }

        private void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tabsiswa", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lbCount.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lbCount.Text = "0";
            }
            con.Close();
             
        }

        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tabsubjek", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lbCount1.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lbCount1.Text = "0";
            }
            con.Close();

        }

        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tabguru", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lbCount2.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lbCount2.Text = "0";
            }
            con.Close();

        }

        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tabdaftar", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lbCount3.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lbCount3.Text = "0";
            }
            con.Close();

        }

        private void btnsiswa_Click(object sender, EventArgs e)
        {
            Main si = new Main();
            si.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Attendance ae = new Attendance();
            ae.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Subject sj = new Subject();
            sj.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Teacher tr = new Teacher();
            tr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Section sn = new Section();
            sn.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Enrollment et = new Enrollment();
            et.Show();
        }
    }
}
