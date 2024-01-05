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
    public partial class Form22 : Form
    {
        private string selectedTedarikciAdi;
        private string selectedÜrün;
        private string selectedAlisFiyati;
        private string selectedAdres;
        private string selectedTelefon;

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form22(string TedarikciAdi, string Ürün, string AlisFiyati, string Adres, string Telefon, string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form22_FormClosing;


            selectedTedarikciAdi = TedarikciAdi;
            selectedÜrün = Ürün;
            selectedAlisFiyati = AlisFiyati;
            selectedAdres = Adres;
            selectedTelefon = Telefon;



            this.connectionString = connectionString;

            // Veritabanından tedarikci bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadTedarikciData();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }
        private void LoadTedarikciData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT   TedarikciAdi,Ürün,AlisFiyati, Adres, Telefon FROM Tedarikciler";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@TedarikciAdi", selectedTedarikciAdi);
                    command.Parameters.AddWithValue("@Ürün", selectedÜrün);
                    command.Parameters.AddWithValue("@AlisFiyati", selectedAlisFiyati);
                    command.Parameters.AddWithValue("@Adres", selectedAdres);
                    command.Parameters.AddWithValue("@Telefon", selectedTelefon);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();

                    textEdit1.Text = selectedTedarikciAdi;

                    textEdit2.Text = selectedÜrün;

                    textEdit3.Text = selectedAlisFiyati;

                    textEdit4.Text = selectedAdres;
                    textEdit5.Text = selectedTelefon;


                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tedarikçi bilgileri yüklenirken hata oluştu: " + ex.Message);
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
            string yenitedarikciadi = textEdit1.Text;
            string yeniürün = textEdit2.Text;
            decimal yenialisfiyati = Convert.ToDecimal(textEdit3.Text);

            string yeniadres = textEdit4.Text;
            string yenitelefon = textEdit5.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE Tedarikciler SET TedarikciAdi = @yenitedarikciadi, Ürün = @yeniürün,AlisFiyati =@yenialisfiyati, Adres= @yeniadres, Telefon = @yenitelefon where Ürün = @yeniürün ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@yenitedarikciadi", yenitedarikciadi);
                    command.Parameters.AddWithValue("@yeniürün", yeniürün);
                    command.Parameters.AddWithValue("@yenialisfiyati", yenialisfiyati);
                    command.Parameters.AddWithValue("@yeniadres", yeniadres);
                    command.Parameters.AddWithValue("@yenitelefon", yenitelefon);




                    // Execute the UPDATE statement
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Ürün bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();

                }
            }
            this.Hide();
            Form21 f21 = new Form21();
            f21.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 f21 = new Form21();
            f21.Show();
        }
        private void Form22_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form21 f21 = new Form21();
                f21.Show();
            }
        }
    }
}
