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
    public partial class Form12 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Form12()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form12_FormClosing;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            LoadProducts();
            // TODO: This line of code loads data into the 'zaiwoneDataSet.MousePad' table. You can move, or remove it, as needed.
            this.mousePadTableAdapter.Fill(this.zaiwoneDataSet.MousePad);
            mousePadBindingSource.DataSource = this.zaiwoneDataSet.MousePad;

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
                    string query = "SELECT Desen, StokAdeti, Fiyat FROM MousePad";
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
        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
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
            string selectedDesen = Convert.ToString(gridView1.GetFocusedRowCellValue("Desen"));
            string selectedStokAdeti = Convert.ToString(gridView1.GetFocusedRowCellValue("StokAdeti"));
            string selectedFiyat = Convert.ToString(gridView1.GetFocusedRowCellValue("Fiyat"));











            this.Hide();

            // Form13'yi açmak ve kullanıcı bilgilerini taşımak için
            using (var form13 = new Form13(selectedDesen,  selectedStokAdeti, selectedFiyat, connectionString))
            {

                form13.ShowDialog();


                // Form13 kapandığında yapılacak işlemler (isteğe bağlı)
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14 f14 = new Form14();
            f14.Show();
        }
    }
}
