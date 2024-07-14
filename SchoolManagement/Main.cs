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
    
    public partial class Main : Form
    {
        Service.scholl wbservice = new Service.scholl();
        public Main()
        {
            InitializeComponent();
           

        }
       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                string namaSiswa = textBox3.Text;
                DateTime tanggal = dateTimePicker1.Value;
                string jenisKelamin = comboBox1.Text;
                string nomorHp = textBox5.Text;
                string email = textBox6.Text;

                string result = wbservice.tabsiswa_insert(id, namaSiswa, tanggal, jenisKelamin, nomorHp, email);

                MessageBox.Show(result, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihat();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menganti?", "Konfirmasi Ubah", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cnn = new SqlCommand("update tabsiswa set namasiswa=@namasiswa,tanggal=@tanggal,jeniskelamin=@jeniskelamin,nomorhp=@nomorhp,email=@email where id=@id", con);
                cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@NamaSiswa", textBox3.Text);
                cnn.Parameters.AddWithValue("@Tanggal", dateTimePicker1.Value);
                cnn.Parameters.AddWithValue("@JenisKelamin", comboBox1.Text);
                cnn.Parameters.AddWithValue("@NomorHp", textBox5.Text);
                cnn.Parameters.AddWithValue("@Email", textBox6.Text);
                cnn.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Berhasil diperbarui", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lihat();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menghapus?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cnn = new SqlCommand("delete tabsiswa where id=@id", con);
                cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                cnn.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Berhasil dihapus", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lihat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";

            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            lihat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lihat();
        }
        void lihat()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from tabsiswa", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

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

        private void button11_Click(object sender, EventArgs e)
        {
            Attendance ae = new Attendance();
            ae.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Dasbor dd = new Dasbor();
            dd.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsiswa_Click(object sender, EventArgs e)
        {

        }
    }
}
