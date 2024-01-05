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
    public partial class Form25 : Form
    {
        private string selectedMusteriID;
        private string selectedMiktar;
        private string selectedToplamFiyat;
        private string selectedTarih;

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form25(string MusteriID, string Miktar, string ToplamFiyat, string Tarih,  string connectionString)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form25_FormClosing;


            selectedMusteriID = MusteriID;
            selectedMiktar = Miktar;
            selectedToplamFiyat = ToplamFiyat;
            selectedTarih = Tarih;



            this.connectionString = connectionString;

            // Veritabanından satis bilgilerini yükleyin ve TextEdit alanlarına doldurun
            LoadSatisData();
        }

        private void Form25_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);

        }
        private void LoadSatisData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT    MusteriID,Miktar,ToplamFiyat,Tarih FROM Satislar";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@MusteriID", selectedMusteriID);
                    command.Parameters.AddWithValue("@Miktar", selectedMiktar);
                    command.Parameters.AddWithValue("@ToplamFiyat", selectedToplamFiyat);
                    command.Parameters.AddWithValue("@Tarih", selectedTarih);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    reader.Read();

                    textEdit1.Text = selectedMusteriID;

                    textEdit2.Text = selectedMiktar;

                    textEdit3.Text = selectedToplamFiyat;

                    textEdit4.Text = selectedTarih;


                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış bilgileri yüklenirken hata oluştu: " + ex.Message);
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
            int yenimusteriid = Convert.ToInt32(textEdit1.Text);
            int yenimiktar = Convert.ToInt32(textEdit2.Text);
            decimal yenitoplamfiyat = Convert.ToDecimal(textEdit3.Text);
            DateTime yenitarih = Convert.ToDateTime(textEdit4.Text);
            


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string UpdateQuery = "UPDATE Satislar SET MusteriID = @yenimusteriid, Miktar = @yenimiktar,ToplamFiyat =@yenitoplamfiyat, Tarih= @yenitarih where MusteriID = @yenimusteriid ";


                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@yenimusteriid", yenimusteriid);
                    command.Parameters.AddWithValue("@yenimiktar", yenimiktar);
                    command.Parameters.AddWithValue("@yenitoplamfiyat", yenitoplamfiyat);
                    command.Parameters.AddWithValue("@yenitarih", yenitarih);




                    // Execute the UPDATE statement
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Satış bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();

                }
            }
            this.Hide();
            Form24 f24 = new Form24();
            f24.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 f24 = new Form24();
            f24.Show();
        }
        private void Form25_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form24 f24 = new Form24();
                f24.Show();
            }
        }
    }
}
