using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace zaiwoneproje
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // veya FormBorderStyle.Fixed3D
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form5_FormClosing;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

            // TODO: This line of code loads data into the 'projectPanasonicDataSet.TblJob' table. You can move, or remove it, as needed.
            
            LoadUserOptions();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form3 form3 = new Form3();
                form3.Show(); // Form1'i göster
            }
        }
        public void ApplyColorMode(ColorModeHelper.ColorMode colorMode)
        {
            switch (colorMode)
            {
                case ColorModeHelper.ColorMode.Default:
                    // Varsayılan renkleri uygulayabilirsiniz.
                    this.BackColor = SystemColors.Control;
                    break;
                case ColorModeHelper.ColorMode.DarkMode:
                    // Karanlık mod renkleri uygulayabilirsiniz.
                    this.BackColor = Color.FromArgb(50, 50, 50);
                    break;
                case ColorModeHelper.ColorMode.BlueMode:
                    // Mavi mod renkleri uygulayabilirsiniz.
                    this.BackColor = Color.FromArgb(50, 50, 100);
                    break;
            }
        }
        private void LoadUserOptions()
        {
            //Kullanıcılar tablosundaki Yetki sütununu comboboxedit'e getiriyor..
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string authorityQuery = "SELECT DISTINCT Yetki FROM Kullanicilar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(authorityQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string authority = reader.GetString(0);
                            comboBoxEdit1.Properties.Items.Add(authority);
                        }
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.EditValue == null &&
                string.IsNullOrEmpty(textEdit1.Text) ||
                string.IsNullOrEmpty(textEdit2.Text) ||
                string.IsNullOrEmpty(textEdit3.Text) ||
                string.IsNullOrEmpty(textEdit4.Text) 
                )


            {
                // Eğer bir veya daha fazla alan boşsa, kullanıcıya bir hata mesajı gösteriyoruz ve güncelleme işlemini yapmıyoruz.
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Güncelleme işlemi için geri dönüyoruz ve kodun devamını çalıştırmıyoruz.
            }
            string Ad = textEdit1.Text;


            string Soyad = textEdit2.Text;


            string KullaniciAdi = textEdit3.Text;


            string Sifre = textEdit4.Text;


            string Telefon = textEdit5.Text;
            

            string Yetki = comboBoxEdit1.Text;
            
            // Create the INSERT statement
            string insertQuery = "INSERT INTO Kullanicilar (Ad, Soyad,KullaniciAdi,Sifre,Telefon,Yetki) VALUES (@Ad, @Soyad,@KullaniciAdi,@Sifre, @Telefon, @Yetki )";

            // Create a SqlConnection and SqlCommand
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Set the parameter values
                command.Parameters.AddWithValue("@Ad", Ad);

                command.Parameters.AddWithValue("@Soyad", Soyad);
                command.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);

                command.Parameters.AddWithValue("@Sifre", Sifre);
                command.Parameters.AddWithValue("@Telefon", Telefon);
                command.Parameters.AddWithValue("@Yetki", Yetki);

                // Open the database connection
                connection.Open();

                // Execute the INSERT statement
                command.ExecuteNonQuery();

                // Close the database connection

            }
            DialogResult sonuc;
            sonuc = MessageBox.Show("Yeni kullanıcı eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);




            connection.Close();

            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
