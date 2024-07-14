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
    public partial class Enrollment : Form
    {
        Service.scholl wbservice = new Service.scholl();
        public Enrollment()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
            int nis;
            double rataRataNilai;
            if (int.TryParse(textBox1.Text, out nis) && double.TryParse(textBox3.Text, out rataRataNilai))
            {
                string namaSiswa = textBox2.Text;
                DateTime tanggalPendaftaran = dateTimePicker1.Value;
                string result = wbservice.tabdaftar_insert(nis, namaSiswa, rataRataNilai, tanggalPendaftaran);
                MessageBox.Show(result, "Insert Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihatdata();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            int nis;
            double rataRataNilai;
            if (int.TryParse(textBox1.Text, out nis) && double.TryParse(textBox3.Text, out rataRataNilai))
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menganti?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string namaSiswa = textBox2.Text;
                    DateTime tanggalPendaftaran = dateTimePicker1.Value;
                    string result = wbservice.tabdaftar_update(nis, namaSiswa, rataRataNilai, tanggalPendaftaran);
                    MessageBox.Show(result, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihatdata();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int nis;
            if (int.TryParse(textBox1.Text, out nis))
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menghapus?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = wbservice.tabdaftar_delete(nis);
                    MessageBox.Show(result, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid NIS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Enrollment_Load(object sender, EventArgs e)
        {
            lihatdata();
        }
        void lihatdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from tabdaftar", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
