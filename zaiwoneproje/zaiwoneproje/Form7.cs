using DevExpress.Utils.About;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace zaiwoneproje
{
    public partial class Form7 : Form
    {
        private string selectedRenk;
        private string selectedTasarim;
        private string selectedStokAdeti;
        private string selectedFiyat;




        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Form7(string Renk, string Tasarim, string StokAdeti, string Fiyat,string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form7_FormClosing;

            selectedRenk = Renk;
            selectedTasarim = Tasarim;
            selectedStokAdeti = StokAdeti;
            selectedFiyat = Fiyat;


            this.connectionString = connectionString;

            // Veritabanından ürün bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadProductsData();



        }

        private void Form7_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);
        }
        private void LoadProductsData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT  Renk, Tasarim, StokAdeti, Fiyat FROM KupaBardak";
                    SqlCommand command = new SqlCommand(query, connection);
        
                    command.Parameters.AddWithValue("@Renk", selectedRenk);
                    command.Parameters.AddWithValue("@Tasarim", selectedTasarim);
                    command.Parameters.AddWithValue("@StokAdeti", selectedStokAdeti);
                    command.Parameters.AddWithValue("@Fiyat", selectedFiyat);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();
                    textEdit1.Text = selectedRenk;

                    textEdit2.Text = selectedTasarim;

                    textEdit3.Text = selectedStokAdeti;

                    textEdit4.Text = selectedFiyat;



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
            string yenirenk = textEdit1.Text;
            string yenitasarim = textEdit2.Text;
            int yenistokadeti = Convert.ToInt32(textEdit3.Text);
            decimal yenifiyat = Convert.ToDecimal(textEdit4.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE KupaBardak SET Renk = @yenirenk,Tasarim = @yenitasarim, StokAdeti = @yenistokadeti, Fiyat = @yenifiyat where Tasarim = @yenitasarim ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
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
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form6 form6 = new Form6();
                form6.Show(); // Form6'i göster
            }
        }

    }
}
