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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // veya FormBorderStyle.Fixed3D
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form20_FormClosing;
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.Show();
        }
        private void Form20_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form18 form18 = new Form18();
                form18.Show(); // Form18'i göster
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
            string Beden = textEdit1.Text;
            string Renk = textEdit2.Text;
            string Tasarim = textEdit3.Text;


            int StokAdeti = Convert.ToInt32(textEdit4.Text);


            decimal Fiyat = Convert.ToDecimal(textEdit5.Text);





            // Create the INSERT statement
            string insertQuery = "INSERT INTO Sweatshirt (Beden,Renk,Tasarim,StokAdeti,Fiyat) VALUES (@Beden,@Renk,@Tasarim,@StokAdeti,@Fiyat)";

            // Create a SqlConnection and SqlCommand
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Set the parameter values
                command.Parameters.AddWithValue("@Beden", Beden);
                command.Parameters.AddWithValue("@Renk", Renk);
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
            Form18 f18 = new Form18();
            f18.Show();
        }
    }
}
