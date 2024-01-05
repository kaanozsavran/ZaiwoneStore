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
    public partial class Form21 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Form21()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form21_FormClosing;
        }

        private void Form21_Load(object sender, EventArgs e)
        {

            LoadTedarikci();

            // TODO: This line of code loads data into the 'zaiwoneDataSet.Tedarikciler' table. You can move, or remove it, as needed.
            this.tedarikcilerTableAdapter.Fill(this.zaiwoneDataSet.Tedarikciler);
            tedarikcilerBindingSource.DataSource = this.zaiwoneDataSet.Tedarikciler;
            ApplyColorMode(ColorModeHelper.CurrentColorMode);



            ApplyColorMode(ColorModeHelper.CurrentColorMode);
            this.WindowState = FormWindowState.Maximized;

        }
        private void LoadTedarikci()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT TedarikciAdi,Ürün,AlisFiyati,Adres,Telefon FROM Tedarikciler";
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
        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
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
            string selectedTedarikciAdi = Convert.ToString(gridView1.GetFocusedRowCellValue("TedarikciAdi"));
            string selectedÜrün = Convert.ToString(gridView1.GetFocusedRowCellValue("Ürün"));
            string selectedAlisFiyati = Convert.ToString(gridView1.GetFocusedRowCellValue("AlisFiyati"));
            string selectedAdres = Convert.ToString(gridView1.GetFocusedRowCellValue("Adres"));
            string selectedTelefon = Convert.ToString(gridView1.GetFocusedRowCellValue("Telefon"));











            this.Hide();

            // Form22'yi açmak ve kullanıcı bilgilerini taşımak için
            using (var form22 = new Form22(selectedTedarikciAdi, selectedÜrün, selectedAlisFiyati, selectedAdres, selectedTelefon, connectionString))
            {

                form22.ShowDialog();


                // Form22 kapandığında yapılacak işlemler (isteğe bağlı)
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form23 f23 = new Form23();
            f23.Show();
        }
    }
}
