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

namespace zaiwoneproje
{
    public partial class Form4 : Form
    {
        private string selectedAd;
        private string selectedSoyad;
        private string selectedKullaniciAdi;
        private string selectedSifre;
        private string selectedTelefon;
        private string selectedYetki;
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form4(string Ad, string Soyad, string KullaniciAdi, string Sifre, string Telefon, string Yetki, string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form4_FormClosing;

            selectedAd = Ad;
            selectedSoyad = Soyad;
            selectedKullaniciAdi = KullaniciAdi;
            selectedSifre = Sifre;
            selectedTelefon = Telefon;
            selectedYetki = Yetki;

            this.connectionString = connectionString;

            // Veritabanından kullanıcı bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadUserData();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);
        }
        private void LoadUserData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Ad, Soyad, KullaniciAdi, Sifre,Telefon,Yetki FROM Kullanicilar";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", selectedAd);
                    command.Parameters.AddWithValue("@UserName", selectedSoyad);
                    command.Parameters.AddWithValue("@UserPswrd", selectedKullaniciAdi);
                    command.Parameters.AddWithValue("@UserEmail", selectedSifre);
                    command.Parameters.AddWithValue("@Job", selectedTelefon);
                    command.Parameters.AddWithValue("@Authority", selectedYetki);


                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();
                    textEdit1.Text = selectedAd;

                    textEdit2.Text = selectedSoyad;

                    textEdit3.Text = selectedKullaniciAdi;

                    textEdit4.Text = selectedSifre;
                    textEdit5.Text = selectedTelefon;

                    comboBoxEdit1.Text = selectedYetki;


                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı bilgileri yüklenirken hata oluştu: " + ex.Message);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string yeniad = textEdit1.Text;
            string yenisoyad = textEdit2.Text;
            string yenikullaniciadi = textEdit3.Text;
            string yenisifre = textEdit4.Text;
            string yenitelefon = textEdit5.Text;
            string yeniyetki = comboBoxEdit1.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE Kullanicilar SET Ad = @yeniad,Soyad = @yenisoyad, KullaniciAdi = @yenikullaniciadi, Sifre = @yenisifre, Telefon = @yenitelefon, Yetki = @yeniyetki where Ad = @yeniad ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@yeniad", yeniad);
                    command.Parameters.AddWithValue("@yenisoyad", yenisoyad);
                    command.Parameters.AddWithValue("@yenikullaniciadi", yenikullaniciadi);
                    command.Parameters.AddWithValue("@yenisifre", yenisifre);
                    command.Parameters.AddWithValue("@yenitelefon", yenitelefon);
                    command.Parameters.AddWithValue("@yeniyetki", yeniyetki);


                    // Execute the UPDATE statement
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kullanıcının bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form3 form3 = new Form3();
                form3.Show(); // Form3'i göster
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
