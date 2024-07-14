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
    public partial class Teacher : Form
    {
        Service.scholl wbservice = new Service.scholl();
        public Teacher()
        {
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            lihat();
        }
        void lihat()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MN\SQLEXPRESS;Initial Catalog=Schooldb1;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from tabguru", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idGuru;
            if (int.TryParse(textBox1.Text, out idGuru))
            {
                string namaGuru = textBox2.Text;
                string jenisKelamin = comboBox1.Text;
                string nomorHp = textBox4.Text;
                string result = wbservice.tabguru_insert(idGuru, namaGuru, jenisKelamin, nomorHp);
                MessageBox.Show(result, "Insert Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Invalid IDGuru", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihat();


        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            int idGuru;
            if (int.TryParse(textBox1.Text, out idGuru))
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menghapus?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string namaGuru = textBox2.Text;
                    string jenisKelamin = comboBox1.Text;
                    string nomorHp = textBox4.Text;
                    string result = wbservice.tabguru_update(idGuru, namaGuru, jenisKelamin, nomorHp);
                    MessageBox.Show(result, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid IDGuru", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idGuru;
            if (int.TryParse(textBox1.Text, out idGuru))
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin akan menghapus?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = wbservice.tabguru_delete(idGuru);
                    MessageBox.Show(result, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid IDGuru", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lihat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            lihat();
        }

        
    }
}
