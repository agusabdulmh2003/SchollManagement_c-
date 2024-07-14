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
    public partial class Section : Form
    {
        Service.scholl wbservice = new Service.scholl();
        public Section()
        {
            InitializeComponent();
        }

        private void Section_Load(object sender, EventArgs e)
        {
            lihatdata();
        }
        void lihatdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Sectiontab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int sectionId;
            if (int.TryParse(textBox1.Text, out sectionId))
            {
                string studentName = textBox2.Text;
                string section = textBox3.Text;
                string result = wbservice.Sectiontab_insert(sectionId, studentName, section);
                MessageBox.Show(result, "Insert Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Invalid Section ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihatdata();
        }


        private void button3_Click(object sender, EventArgs e)
        {

            int sectionId;
            if(int.TryParse(textBox1.Text, out sectionId))
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menganti?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string studentName = textBox2.Text;
                    string section = textBox3.Text;
                    string result = wbservice.Sectiontab_update(sectionId, studentName, section);
                    MessageBox.Show(result, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid Section ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihatdata();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sectionId;
            if (int.TryParse(textBox1.Text, out sectionId))
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menghapus?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = wbservice.Sectiontab_delete(sectionId);
                    MessageBox.Show(result, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid Section ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihatdata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Sectiontab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
