using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KutuphaneOtomasyonu.Classes;

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for AkademisyenKayit.xaml
    /// </summary>
    public partial class AkademisyenKayit : System.Windows.Controls.UserControl
    {  
        public AkademisyenKayit()
        {
            InitializeComponent();
        }

        Anasayfa anasayfa = new Anasayfa();

        DbBaglanti baglanti = new DbBaglanti(); 

        public static string Ad;
        public static string Soyad;
        public static int Bolum;
        public static string Tel_No;
        public static string Mail;
        public static string Sicil_No;

        private void AkademisyenKayit_UyeEkle_Click(object sender, RoutedEventArgs e)
        {
            Ad = AkadeemisyenAd_txt1.Text;
            Soyad = AkademisyenSoyad_txt2.Text;
            Bolum = Bolum_cmb.SelectedIndex;
            Tel_No = AkademisyenTel_No_txt4.Text;
            Mail = AkademisyenMail_txt5.Text;
            Sicil_No = AkademisyenSicilNo_txt6.Text;
            AkademisyenKayitOnizleme aa = new AkademisyenKayitOnizleme();
            aa.Show();
            AkadeemisyenAd_txt1.Clear();   
            AkademisyenSoyad_txt2.Clear();   
            AkademisyenTel_No_txt4.Clear();   
            AkademisyenMail_txt5.Clear();    
            AkademisyenSicilNo_txt6.Clear();
        }
         
        private void AkademisyenKayit_Listele_Click(object sender, RoutedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.ShowDataInGridView("SELECT Uye.*, Bolum.Adi FROM Uye RIGHT JOIN Bolum ON Bolum.Id = Uye.Bolum_Id where Uye_Numara", Akademisyen_dvg);
            baglanti.CloseConnection();
        }

        private void AkademisyenKayit_Sil_Click(object sender, RoutedEventArgs e)
        {
           if(AkademisyenSicilNo_txt6.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Sicil Numarası bulunamadı!!");
            }
            else
            {
                baglanti.OpenConnection();
                DialogResult result;
                result = System.Windows.Forms.MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                baglanti.Delete("DELETE FROM Uye WHERE Uye_Numara = '" + AkademisyenSicilNo_txt6.Text + "'");
                System.Windows.Forms.MessageBox.Show("Kayıt başarıyla silinmiştir.");
            }

        }

        private void AkademisyenKayit_UyeGüncelle_Click(object sender, RoutedEventArgs e)
        {
            if(AkademisyenSicilNo_txt6.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Sicil numarası bulunamadı!!");
            }
            else
            {
                if (AkadeemisyenAd_txt1.Text == "" && AkademisyenSoyad_txt2.Text == "" && AkademisyenTel_No_txt4.Text == "" && AkademisyenMail_txt5.Text == "")
                {
                    Bolum_cmb.SelectedIndex = 0;
                    AkadeemisyenAd_txt1.Text = "Bilgi girilmedi";
                    AkademisyenSoyad_txt2.Text = "Bilgi girilmedi";
                    AkademisyenTel_No_txt4.Text = "Bilgi girilmedi";
                    AkademisyenMail_txt5.Text = "Bilgi girilmedi";
                    AkademisyenSicilNo_txt6.Text = "Bilgi girilmedi";
                }
                baglanti.OpenConnection();
                baglanti.Update("UPDATE Uye SET Adi = '" + AkadeemisyenAd_txt1.Text + "', Soyadi = '" + AkademisyenSoyad_txt2.Text + "', Telefon_No = '" + AkademisyenTel_No_txt4.Text + "', E_Posta = '" + AkademisyenMail_txt5.Text + "', Bolum_Id = '" + Bolum_cmb.SelectedIndex + "' WHERE  Uye_Numara = '" + AkademisyenSicilNo_txt6.Text + "'");
                System.Windows.Forms.MessageBox.Show("Kayıt başarıyla güncellendi.");
                baglanti.CloseConnection();
            }            
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.Filter_Search("SELECT * FROM Uye WHERE Adi LİKE  '%" + Ara_txt.Text + "%'", Akademisyen_dvg, Ara_cmb);
            baglanti.CloseConnection();
        }
    }
}
