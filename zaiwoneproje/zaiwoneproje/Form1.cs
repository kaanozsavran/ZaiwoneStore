using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace zaiwoneproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // kullanıcı form boyutuna dokunamasın diye
            this.MaximizeBox = false; // tam ekran seçeneğini yok etme
            this.MinimizeBox = true; // formu alta alabilme özelligi
            this.FormClosing += Form1_FormClosing;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textEdit2.Properties.PasswordChar = '*';
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "Select Yetki from Kullanicilar Where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            command.Parameters.AddWithValue("@KullaniciAdi", textEdit1.Text.Trim());
            command.Parameters.AddWithValue("@Sifre", textEdit2.Text.Trim());

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                string yetki = reader.GetString(0);
                if (yetki == "User")
                {

                    Form2 form2 = new Form2();
                    form2.kullanıcıTanımlarıToolStripMenuItem.Visible = false;
                    form2.ürünlerToolStripMenuItem.Visible = false;
                    form2.tedarikçilerToolStripMenuItem.Visible = false;
                    form2.müşterilerToolStripMenuItem.Visible = false;
                    form2.satışlarToolStripMenuItem.Visible = false;

                    form2.Show();
                }
                else
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                    connection.Close();
                    //this.Close();
                }




            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre girdiniz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit(); // Programı kapat

            }
        }
    }
}