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
    public partial class Form6 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form6()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form6_FormClosing;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
           
            LoadProducts();

            // TODO: This line of code loads data into the 'zaiwoneDataSet.KupaBardak' table. You can move, or remove it, as needed.
            this.kupaBardakTableAdapter.Fill(this.zaiwoneDataSet.KupaBardak);
            kupaBardakBindingSource.DataSource = this.zaiwoneDataSet.KupaBardak;

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
                    string query = "SELECT Renk, Tasarim, StokAdeti, Fiyat FROM KupaBardak";
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
        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
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

            

                string selectedRenk = Convert.ToString(gridView1.GetFocusedRowCellValue("Renk"));
                string selectedTasarim = Convert.ToString(gridView1.GetFocusedRowCellValue("Tasarim"));
                string selectedStokAdeti = Convert.ToString(gridView1.GetFocusedRowCellValue("StokAdeti"));
                string selectedFiyat = Convert.ToString(gridView1.GetFocusedRowCellValue("Fiyat"));
                










                this.Hide();

                // Form7'yi açmak ve kullanıcı bilgilerini taşımak için
                using (var form7 = new Form7(selectedRenk, selectedTasarim, selectedStokAdeti, selectedFiyat, connectionString))
                {

                    form7.ShowDialog();


                    // Form7 kapandığında yapılacak işlemler (isteğe bağlı)
                }
            
        }

            private void simpleButton1_Click(object sender, EventArgs e)
            {
                this.Hide();
                Form8 f8 = new Form8();
                f8.Show();
            }

            private void gridControl1_Click(object sender, EventArgs e)
            {

            }
        }
        
    }


