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
    public partial class Form24 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Form24()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form24_FormClosing;
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            LoadSatislar();

            // TODO: This line of code loads data into the 'zaiwoneDataSet.Satislar' table. You can move, or remove it, as needed.
            this.satislarTableAdapter.Fill(this.zaiwoneDataSet.Satislar);
            satislarBindingSource.DataSource = this.zaiwoneDataSet.Satislar;
            ApplyColorMode(ColorModeHelper.CurrentColorMode);



            ApplyColorMode(ColorModeHelper.CurrentColorMode);
            this.WindowState = FormWindowState.Maximized;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form26 f26 = new Form26();
            f26.Show();
        }
        private void LoadSatislar()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT MusteriID,KupaBardakID,TShirtID,TelefonKilifID,MousePadID,SweatShirtID,Miktar,ToplamFiyat,Tarih FROM Satislar";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    gridControl1.DataSource = reader;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanından bilgiler yüklenirken hata oluştu: " + ex.Message);
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
        private void Form24_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // Formun kapatılmasını iptal et
                Form2 form2 = new Form2();
                form2.Show(); // Form2'i göster
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            string selectedMusteriID = Convert.ToString(gridView1.GetFocusedRowCellValue("MusteriID"));
            string selectedMiktar = Convert.ToString(gridView1.GetFocusedRowCellValue("Miktar"));
            string selectedToplamFiyat = Convert.ToString(gridView1.GetFocusedRowCellValue("ToplamFiyat"));
            string selectedTarih = Convert.ToString(gridView1.GetFocusedRowCellValue("Tarih"));
            string KupaBardakID = Convert.ToString(gridView1.GetFocusedRowCellValue("Tarih"));
            string TShirtID = Convert.ToString(gridView1.GetFocusedRowCellValue("Tarih"));
            string TelefonKilifID = Convert.ToString(gridView1.GetFocusedRowCellValue("Tarih"));
            string MousePadID = Convert.ToString(gridView1.GetFocusedRowCellValue("Tarih"));
            string SweatShirtID = Convert.ToString(gridView1.GetFocusedRowCellValue("Tarih"));











            this.Hide();

            // Form25'yi açmak ve kullanıcı bilgilerini taşımak için
            using (var form25 = new Form25(selectedMusteriID, selectedMiktar, selectedToplamFiyat, selectedTarih, connectionString))
            {

                form25.ShowDialog();


                // Form25 kapandığında yapılacak işlemler (isteğe bağlı)
            }
        }
    }
}
