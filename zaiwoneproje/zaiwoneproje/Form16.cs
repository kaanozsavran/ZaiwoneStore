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
    public partial class Form16 : Form
    {
        private string selectedBeden;
        private string selectedRenk;
        private string selectedTasarim;
        private string selectedStokAdeti;
        private string selectedFiyat;

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        public Form16(string Beden, string Renk,string Tasarim,string StokAdeti, string Fiyat, string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form16_FormClosing;


            selectedBeden = Beden;
            selectedRenk = Renk;
            selectedTasarim = Tasarim;
            selectedStokAdeti = StokAdeti;
            selectedFiyat = Fiyat;



            this.connectionString = connectionString;

            // Veritabanından ürün bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadProductsData();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }
        private void LoadProductsData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT   Beden,Renk,Tasarim, StokAdeti, Fiyat FROM TShirt";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Beden", selectedBeden);
                    command.Parameters.AddWithValue("@Renk", selectedRenk);
                    command.Parameters.AddWithValue("@Tasarim", selectedTasarim);
                    command.Parameters.AddWithValue("@StokAdeti", selectedStokAdeti);
                    command.Parameters.AddWithValue("@Fiyat", selectedFiyat);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();

                    textEdit1.Text = selectedBeden;

                    textEdit2.Text = selectedRenk;

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
            string yenibeden = textEdit1.Text;
            string yenirenk = textEdit2.Text;

            string yenitasarim = textEdit3.Text;

            int yenistokadeti = Convert.ToInt32(textEdit4.Text);
            decimal yenifiyat = Convert.ToDecimal(textEdit5.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE TShirt SET Beden = @yenibeden, Renk = @yenirenk,Tasarim =@yenitasarim, StokAdeti= @yenistokadeti, Fiyat = @yenifiyat where Tasarim = @yenitasarim ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@yenibeden", yenibeden);
                    command.Parameters.AddWithValue("@yenirenk", yenirenk);
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
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f15 = new Form15();
            f15.Show();
        }
        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form15 form15 = new Form15();
                form15.Show(); // Form15'i göster
            }
        }
    }
}
