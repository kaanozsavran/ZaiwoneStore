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
    public partial class Form27 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Form27()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form27_FormClosing;
        }

        private void Form27_Load(object sender, EventArgs e)
        {

            LoadMusteri();

            // TODO: This line of code loads data into the 'zaiwoneDataSet.Musteriler' table. You can move, or remove it, as needed.
            this.musterilerTableAdapter.Fill(this.zaiwoneDataSet.Musteriler);
            musterilerBindingSource.DataSource = this.zaiwoneDataSet.Musteriler;
            ApplyColorMode(ColorModeHelper.CurrentColorMode);



            ApplyColorMode(ColorModeHelper.CurrentColorMode);
            this.WindowState = FormWindowState.Maximized;

        }
        private void LoadMusteri()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT MüsteriAdi,Adres,Telefon FROM Musteriler";
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
        private void Form27_FormClosing(object sender, FormClosingEventArgs e)
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
            string selectedMüsteriAdi = Convert.ToString(gridView1.GetFocusedRowCellValue("MüsteriAdi"));
            string selectedAdres = Convert.ToString(gridView1.GetFocusedRowCellValue("Adres"));
            string selectedTelefon = Convert.ToString(gridView1.GetFocusedRowCellValue("Telefon"));











            this.Hide();

            // Form28'yi açmak ve kullanıcı bilgilerini taşımak için
            using (var form28 = new Form28(selectedMüsteriAdi, selectedAdres, selectedTelefon, connectionString))
            {

                form28.ShowDialog();


                // Form28 kapandığında yapılacak işlemler (isteğe bağlı)
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form29 f29 = new Form29();
            f29.Show();
        }
    }
}
