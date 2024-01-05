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
    public partial class Form10 : Form
    {
        private string selectedMarka;
        private string selectedModel;
        private string selectedTasarim;
        private string selectedStokAdeti;
        private string selectedFiyat;

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        public Form10(string Marka, string Model, string Tasarim, string StokAdeti, string Fiyat, string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form10_FormClosing;

            selectedMarka = Marka;
            selectedModel = Model;
            selectedTasarim = Tasarim;
            selectedStokAdeti = StokAdeti;
            selectedFiyat = Fiyat;

            this.connectionString = connectionString;

            // Veritabanından ürün bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadProductData();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }
        private void LoadProductData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT  Marka, Model, Tasarim, StokAdeti,Fiyat FROM TelefonKilif";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Marka", selectedMarka);
                    command.Parameters.AddWithValue("@Model", selectedModel);
                    command.Parameters.AddWithValue("@Tasarim", selectedTasarim);
                    command.Parameters.AddWithValue("@StokAdeti", selectedStokAdeti);
                    command.Parameters.AddWithValue("@Fiyat", selectedFiyat);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();
                    textEdit1.Text = selectedMarka;

                    textEdit2.Text = selectedModel;

                    textEdit3.Text = selectedTasarim;

                    textEdit4.Text = selectedStokAdeti;
                    textEdit5.Text = selectedFiyat;



                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün bilgileri yüklenirken hata oluştu: " + ex.Message);
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
            string yenimarka = textEdit1.Text;
            string yenimodel = textEdit2.Text;
            string yenitasarim = textEdit3.Text;
            int yenistokadeti = Convert.ToInt32(textEdit4.Text);
            decimal yenifiyat = Convert.ToDecimal(textEdit5.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE TelefonKilif SET Marka = @yenimarka,Model = @yenimodel, Tasarim = @yenitasarim, StokAdeti = @yenistokadeti , Fiyat = @yenifiyat where Tasarim = @yenitasarim ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@yenimarka", yenimarka);
                    command.Parameters.AddWithValue("@yenimodel", yenimodel);
                    command.Parameters.AddWithValue("@yenitasarim", yenitasarim);
                    command.Parameters.AddWithValue("@yenistokadeti", yenistokadeti);
                    command.Parameters.AddWithValue("@yenifiyat", yenifiyat);




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
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }
        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form9 form9 = new Form9();
                form9.Show(); // Form9'i göster
            }
        }
    }
}
