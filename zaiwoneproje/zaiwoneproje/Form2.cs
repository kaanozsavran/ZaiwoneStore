using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zaiwoneproje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.CurrentColorMode);
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string yazıBilgisi = "Zaiwone Store, tüm oyunlara dair aksesuarların bulunduğu genç girişimci olarak açtığım e-ticaret şirketidir.\r\n";

            MessageBox.Show(yazıBilgisi, "Hakkımızda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult result = MessageBox.Show("Shopier dükkanımıza yönlendirilmek ister misiniz?", "Hakkımızda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Web sitesine yönlendir
                System.Diagnostics.Process.Start("https://www.shopier.com/");
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Programı kapatmak istiyor musunuz?", "Program Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3);
            if (sonuc == DialogResult.No)
            {
                return;
            }
            else if (sonuc == DialogResult.Yes)
            {
                Application.Exit(); // Programı kapat

            }
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("İletişime geçebileceğiniz instagram hesabımıza yönlendiriliyorsunuz.", "BİZE ULAŞIN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Web sitesine yönlendir
                System.Diagnostics.Process.Start("https://www.instagram.com/zaiwonestore/");
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit(); // Programı kapat
            }
        }
        private void ApplyColorMode(ColorModeHelper.ColorMode colorMode)
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

        private void varsayılanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.ColorMode.Default);
            ApplyColorModeToOtherForms(ColorModeHelper.ColorMode.Default);
        }

        private void karanlıkModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.ColorMode.DarkMode);
            ApplyColorModeToOtherForms(ColorModeHelper.ColorMode.DarkMode);
        }

        private void maviModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyColorMode(ColorModeHelper.ColorMode.BlueMode);
            ApplyColorModeToOtherForms(ColorModeHelper.ColorMode.BlueMode);
        }
        private void ApplyColorModeToOtherForms(ColorModeHelper.ColorMode colorMode)
        {
            // Form3, Form4, Form5, Form6 gibi diğer formlardaki renk modlarını güncellemek için kullanılır.
            foreach (Form form in Application.OpenForms)
            {
                if (form == this || form is Form2) continue; // Mevcut formu ve Form2'yi atlatıyorum.

                if (form is Form3 form3)
                {
                    form3.ApplyColorMode(colorMode);
                }
                else if (form is Form4 form4)
                {
                    form4.ApplyColorMode(colorMode);
                }
                //diğer formların kontrolü
            }

            // Yardımcı sınıfta güncel renk modunu kaydediyoruz.
            ColorModeHelper.CurrentColorMode = colorMode;
        }

        private void kullanıcıTanımlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void kupaBardakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void tedarikçilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 f21 = new Form21();
            f21.Show();
        }

        private void telefonKılıfıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void mousePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void tShirtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void sweatShirtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.Show();
        }

        private void satışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 f24 = new Form24();
            f24.Show();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form27 f27 = new Form27();
            f27.Show();
        }
    }
}
