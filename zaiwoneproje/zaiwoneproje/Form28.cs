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
    public partial class Form28 : Form
    {
        private string selectedMüsteriAdi;
        private string selectedAdres;
        private string selectedTelefon;

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form28(string MüsteriAdi, string Adres, string Telefon, string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form28_FormClosing;


            selectedMüsteriAdi = MüsteriAdi;
            selectedAdres = Adres;
            selectedTelefon = Telefon;



            this.connectionString = connectionString;

            // Veritabanından musteri bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadMusteriData();
        }

        private void Form28_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }
        private void LoadMusteriData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT   MüsteriAdi, Adres, Telefon FROM Musteriler";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@MüsteriAdi", selectedMüsteriAdi);
                    command.Parameters.AddWithValue("@Adres", selectedAdres);
                    command.Parameters.AddWithValue("@Telefon", selectedTelefon);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();

                    textEdit1.Text = selectedMüsteriAdi;

                    textEdit2.Text = selectedAdres;
                    textEdit3.Text = selectedTelefon;


                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgileri yüklenirken hata oluştu: " + ex.Message);
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
            string yenimusteriadi = textEdit1.Text;
            string yeniadres = textEdit2.Text;
            string yenitelefon = textEdit3.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE Musteriler SET MüsteriAdi = @yenimusteriadi, Adres= @yeniadres, Telefon = @yenitelefon where MüsteriAdi = @yenimusteriadi ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@yenimusteriadi", yenimusteriadi);
                    
                    command.Parameters.AddWithValue("@yeniadres", yeniadres);
                    command.Parameters.AddWithValue("@yenitelefon", yenitelefon);




                    // Execute the UPDATE statement
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Müşteri bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();

                }
            }
            this.Hide();
            Form27 f27 = new Form27();
            f27.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form27 f27 = new Form27();
            f27.Show();
        }
        private void Form28_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form27 f27 = new Form27();
                f27.Show();
            }
        }
    }
}
