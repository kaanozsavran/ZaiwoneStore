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
    public partial class Form13 : Form
    {
        private string selectedDesen;
        private string selectedStokAdeti;
        private string selectedFiyat;




        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form13(string Desen, string StokAdeti, string Fiyat, string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form13_FormClosing;

          
            selectedDesen = Desen;
            selectedStokAdeti = StokAdeti;
            selectedFiyat = Fiyat;


            this.connectionString = connectionString;

            // Veritabanından ürün bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadProductsData();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }
        private void LoadProductsData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT   Desen, StokAdeti, Fiyat FROM MousePad";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Desen", selectedDesen);
                    command.Parameters.AddWithValue("@StokAdeti", selectedStokAdeti);
                    command.Parameters.AddWithValue("@Fiyat", selectedFiyat);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();

                    textEdit1.Text = selectedDesen;

                    textEdit2.Text = selectedStokAdeti;

                    textEdit3.Text = selectedFiyat;



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
            string yenidesen = textEdit1.Text;
            int yenistokadeti = Convert.ToInt32(textEdit2.Text);
            decimal yenifiyat = Convert.ToDecimal(textEdit3.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE MousePad SET Desen = @yenidesen, StokAdeti = @yenistokadeti, Fiyat = @yenifiyat where Desen = @yenidesen ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@yenidesen", yenidesen);
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
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }
        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form12 form12 = new Form12();
                form12.Show(); // Form12'i göster
            }
        }
    }
}
