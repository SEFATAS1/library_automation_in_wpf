using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KutuphaneOtomasyonu.Classes;
using MySql.Data.MySqlClient;

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for AkademisyenKayitOnizleme.xaml
    /// </summary>
    public partial class AkademisyenKayitOnizleme : Window
    {
        public AkademisyenKayitOnizleme()
        {
            InitializeComponent();
        }

        DbBaglanti baglanti = new DbBaglanti();

        private void AkademisyenKayitOnizleme_Load(object sender, RoutedEventArgs e)
        {
            Adi_txt1.Text = AkademisyenKayit.Ad;
            Soyadi_txt2.Text = AkademisyenKayit.Soyad;
            Bolum_cmb.SelectedIndex = AkademisyenKayit.Bolum;
            TelNo_txt4.Text = AkademisyenKayit.Tel_No;
            Mail_txt5.Text = AkademisyenKayit.Mail;
            SicilNo_txt6.Text = AkademisyenKayit.Sicil_No;
        }

        private void AkademisyenKayit_UyeEkle_Iptal_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AkademisyenKayit_Click(object sender, RoutedEventArgs e)
        {
            if (SicilNo_txt6.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Sicil numarası boş!!");
                this.Close();
            }
            else 
            {
                if (Adi_txt1.Text == "" && Soyadi_txt2.Text == "" && TelNo_txt4.Text == "" && Mail_txt5.Text == "")
                {
                    Bolum_cmb.SelectedIndex = 0;
                    Adi_txt1.Text = "Bilgi girilmedi";
                    Soyadi_txt2.Text = "Bilgi girilmedi";
                    TelNo_txt4.Text = "Bilgi girilmedi";
                    Mail_txt5.Text = "Bilgi girilmedi";
                }
                else
                {
                    baglanti.OpenConnection();
                    baglanti.ExecuteQueries("INSERT INTO Uye (Uye_Numara, Adi, Soyadi, Telefon_No, E_Posta, Bolum_Id) VALUES ('" + SicilNo_txt6.Text + "', '" + Adi_txt1.Text + "', '" + Soyadi_txt2.Text + "', '" + TelNo_txt4.Text + "', '" + Mail_txt5.Text + "', '" + Bolum_cmb.SelectedIndex + "')");
                    this.Close();
                    System.Windows.Forms.MessageBox.Show("Kayıt Başarıyla Oluşturuldu");
                }    
            }           
            baglanti.CloseConnection();
        }
    }
}
