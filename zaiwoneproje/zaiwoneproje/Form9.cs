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
    public partial class Form9 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Form9()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form9_FormClosing;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            LoadProducts();
            telefonKilifBindingSource.DataSource = this.zaiwoneDataSet.TelefonKilif;


            // TODO: This line of code loads data into the 'zaiwoneDataSet.TelefonKilif' table. You can move, or remove it, as needed.
            this.telefonKilifTableAdapter.Fill(this.zaiwoneDataSet.TelefonKilif);
            ApplyColorMode(ColorModeHelper.CurrentColorMode);



            ApplyColorMode(ColorModeHelper.CurrentColorMode);
            this.WindowState = FormWindowState.Maximized;

        }
        private void LoadProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Marka, Model, Tasarim, StokAdeti, Fiyat FROM TelefonKilif";
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
        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
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
            string selectedMarka = Convert.ToString(gridView1.GetFocusedRowCellValue("Marka"));
            string selectedModel = Convert.ToString(gridView1.GetFocusedRowCellValue("Model"));
            string selectedTasarim = Convert.ToString(gridView1.GetFocusedRowCellValue("Tasarim"));
            string selectedStokAdeti = Convert.ToString(gridView1.GetFocusedRowCellValue("StokAdeti"));
            string selectedFiyat = Convert.ToString(gridView1.GetFocusedRowCellValue("Fiyat"));











            this.Hide();

            // Form10'yi açmak ve kullanıcı bilgilerini taşımak için
            using (var form10 = new Form10(selectedMarka, selectedModel, selectedTasarim, selectedStokAdeti, selectedFiyat, connectionString))
            {

                form10.ShowDialog();


                // Form10 kapandığında yapılacak işlemler (isteğe bağlı)
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f11 = new Form11();
            f11.Show();
        }
    }
}
