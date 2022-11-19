using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.IO;
using ZadanieDomowe6._13.Properties;

namespace ZadanieDomowe6._13
{
    public partial class Main : Form
    {
        public bool IsMaximize
        {
            get
            {
                return Settings.Default.IsMaximize;
            }
            set
            {
                Settings.Default.IsMaximize = value;
            }
        }
        public Main()
        {
            InitializeComponent();
            if (IsMaximize)
                WindowState = FormWindowState.Maximized;

        }


        public void btnChoose_Click(object sender, EventArgs e)
        {
            ofdPicturePath.ShowDialog();
            string picturePath = ofdPicturePath.FileName;  //Wybieranie pliku zdjêcia z dysku
            pbPhoto.Image = Image.FromFile(picturePath);

            btnDeleteVisibility();

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ourSettings");
            key.SetValue("path", picturePath); //zapisywanie ostaniego zdjêcia
            key.Close();
        }

        private void btnDeleteVisibility()
        {
            if (pbPhoto.Image == null)
                btnDelete.Visible = false; //Widocznoœæ przycisku "Usuñ"
            else
                btnDelete.Visible = true;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ourSettings");
            string picturePath = "";
            key.SetValue("path", picturePath); //zapisywanie ostaniego zdjêcia
            key.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pbPhoto.Image = null; //Usuwanie wartœci z picturebox'a
            btnDeleteVisibility();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\ourSettings");

            if (key != null)
            {
                string picturePath = key.GetValue("path").ToString();
                if (picturePath.Length > 0)
                {
                    Console.WriteLine("path :" + key.GetValue("path").ToString());
                    pbPhoto.Image = Image.FromFile(picturePath); //Odczytywanie ostatniego zdjêcia
                    key.Close();
                }
            }
            btnDeleteVisibility();
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                IsMaximize = true;
            else
                IsMaximize = false;

            Settings.Default.Save();
        }
    }
}