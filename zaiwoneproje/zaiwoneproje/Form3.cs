using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;




namespace zaiwoneproje
{
    public partial class Form3 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form3_FormClosing;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadUsers();
            
            // TODO: This line of code loads data into the 'zaiwoneDataSet.Kullanicilar' table. You can move, or remove it, as needed.
            this.kullanicilarTableAdapter.Fill(this.zaiwoneDataSet.Kullanicilar);
            kullanicilarBindingSource.DataSource = this.zaiwoneDataSet.Kullanicilar;

            ApplyColorMode(ColorModeHelper.CurrentColorMode);



            ApplyColorMode(ColorModeHelper.CurrentColorMode);
            this.WindowState = FormWindowState.Maximized;

        }
        private void LoadUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Ad, Soyad, KullaniciAdi, Sifre, Telefon, Yetki  FROM Kullanicilar";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    gridControl1.DataSource = reader;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanından kullanıcılar yüklenirken hata oluştu: " + ex.Message);
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
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            string selectedAd = Convert.ToString(gridView1.GetFocusedRowCellValue("Ad"));
            string selectedSoyad = Convert.ToString(gridView1.GetFocusedRowCellValue("Soyad"));
            string selectedKullaniciAdi = Convert.ToString(gridView1.GetFocusedRowCellValue("KullaniciAdi"));
            string selectedSifre = Convert.ToString(gridView1.GetFocusedRowCellValue("Sifre"));
            string selectedTelefon = Convert.ToString(gridView1.GetFocusedRowCellValue("Telefon"));
            string selectedYetki = Convert.ToString(gridView1.GetFocusedRowCellValue("Yetki"));

            this.Hide();

            // Form4'yi açmak ve kullanıcı bilgilerini taşımak için
            using (var form4 = new Form4(selectedAd, selectedSoyad, selectedKullaniciAdi, selectedSifre, selectedTelefon, selectedYetki, connectionString))
            {

                form4.ShowDialog();


                // Form4 kapandığında yapılacak işlemler (isteğe bağlı)
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
