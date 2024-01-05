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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // form boyutu değiştirilmemesi için
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form11_FormClosing;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }
        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form9 form9 = new Form9();
                form9.Show(); // Form9'i göster
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
            if (
                string.IsNullOrEmpty(textEdit1.Text) ||
                string.IsNullOrEmpty(textEdit2.Text) ||
                string.IsNullOrEmpty(textEdit3.Text) ||
                string.IsNullOrEmpty(textEdit4.Text) ||
                string.IsNullOrEmpty(textEdit5.Text)
                )


            {
                // Eğer bir veya daha fazla alan boşsa, kullanıcıya bir hata mesajı gösteriyoruz ve güncelleme işlemini yapmıyoruz.
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Güncelleme işlemi için geri dönüyoruz ve kodun devamını çalıştırmıyoruz.
            }
            string Marka = textEdit1.Text;
            string Model = textEdit2.Text;
            string Tasarim = textEdit3.Text;
            int StokAdeti = Convert.ToInt32(textEdit4.Text);
            decimal Fiyat = Convert.ToDecimal(textEdit5.Text);



            // Create the INSERT statement
            string insertQuery = "INSERT INTO TelefonKilif (Marka, Model,Tasarim,StokAdeti,Fiyat) VALUES (@Marka, @Model,@Tasarim,@StokAdeti,@Fiyat)";

            // Create a SqlConnection and SqlCommand
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Set the parameter values
                command.Parameters.AddWithValue("@Marka", Marka);

                command.Parameters.AddWithValue("@Model", Model);
                command.Parameters.AddWithValue("@Tasarim", Tasarim);

                command.Parameters.AddWithValue("@StokAdeti", StokAdeti);
                command.Parameters.AddWithValue("@Fiyat", Fiyat);


                // Open the database connection
                connection.Open();

                // Execute the INSERT statement
                command.ExecuteNonQuery();

                // Close the database connection

            }
            DialogResult sonuc;
            sonuc = MessageBox.Show("Yeni ürün eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);




            connection.Close();

            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }
    }
}
