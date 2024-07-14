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
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into tabsubjek values(@id,@namasubjek)", con);
            cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@NamaSubjek", textBox2.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Berhasil disimpan", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lihatdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menganti?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cnn = new SqlCommand("update tabsubjek set namasubjek=@namasubjek where id=@id", con);
                cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@NamaSubjek", textBox2.Text);

                cnn.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Berhasil dipebarui", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lihatdata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menghapus?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cnn = new SqlCommand("delete tabsubjek where id=@id", con);
                cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                cnn.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("berhasil dihapus", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lihatdata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            lihatdata();
        }
        void lihatdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from tabsubjek", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
