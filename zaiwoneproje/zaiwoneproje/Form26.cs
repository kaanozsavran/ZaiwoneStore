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
    public partial class Form26 : Form
    {
        public Form26()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // veya FormBorderStyle.Fixed3D
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form26_FormClosing;
        }

        private void Form26_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 f24 = new Form24();
            f24.Show();
        }
        private void Form26_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form24 f24 = new Form24();
                f24.Show();
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
            int MusteriID = Convert.ToInt32(textEdit1.Text);
            int KupaBardakID = Convert.ToInt32(textEdit2.Text);
            int TShirtID = Convert.ToInt32(textEdit3.Text);
            int TelefonKilifID = Convert.ToInt32(textEdit4.Text);
            int MousePadID = Convert.ToInt32( textEdit5.Text);
            int SweatShirtID = Convert.ToInt32(textEdit6.Text);
            int Miktar = Convert.ToInt32(textEdit7.Text);
            decimal ToplamFiyat = Convert.ToDecimal( textEdit8.Text);

            DateTime yenitarih = Convert.ToDateTime(textEdit9.Text);





            // Create the INSERT statement
            string insertQuery = "INSERT INTO Satislar (MusteriID,KupaBardakID,TShirtID,TelefonKilifID,MousePadID,SweatShirtID,Miktar,ToplamFiyat,Tarih) VALUES (@MusteriID,@KupaBardakID,@TShirtID,@TelefonKilifID,@MousePadID,@SweatShirtID,@Miktar,@ToplamFiyat,@yenitarih)";

            // Create a SqlConnection and SqlCommand
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Set the parameter values
                command.Parameters.AddWithValue("@MusteriID", MusteriID);
                command.Parameters.AddWithValue("@KupaBardakID", KupaBardakID);
                command.Parameters.AddWithValue("@TShirtID", TShirtID);

                command.Parameters.AddWithValue("@TelefonKilifID", TelefonKilifID);

                command.Parameters.AddWithValue("@MousePadID", MousePadID);
                command.Parameters.AddWithValue("@SweatShirtID", SweatShirtID);
                command.Parameters.AddWithValue("@Miktar", Miktar);
                command.Parameters.AddWithValue("@ToplamFiyat", ToplamFiyat);
                command.Parameters.AddWithValue("@yenitarih", yenitarih);




                // Open the database connection
                connection.Open();

                // Execute the INSERT statement
                command.ExecuteNonQuery();

                // Close the database connection

            }
            DialogResult sonuc;
            sonuc = MessageBox.Show("Yeni satış eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);




            connection.Close();

            this.Hide();
            Form24 f24 = new Form24();
            f24.Show();
        }
    }
}
