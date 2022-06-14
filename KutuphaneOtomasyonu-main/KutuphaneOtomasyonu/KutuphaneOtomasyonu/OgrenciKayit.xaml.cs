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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;
using KutuphaneOtomasyonu.Classes;

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for OgrenciKayit.xaml
    /// </summary>
    public partial class OgrenciKayit : UserControl
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }

        public static string OgrenciAdı;
        public static string OgrenciSoyadı;
        public static int OgrenciBolumAdı;
        public static string OgrenciTelNo;
        public static string OgrenciMail;
        public static string OgrenciNo;
        public static string ISBN;


        DbBaglanti baglanti = new DbBaglanti();

        private void OgrenciKayit_UyeEkle(object sender, RoutedEventArgs e)
        {
            OgrenciAdı = OgrenciKayit_OgrenciAdı_txt1.Text;
            OgrenciSoyadı = OgrenciKyit_OgrenciSoyadı_txt2.Text;
            OgrenciBolumAdı = Bolum_cmb.SelectedIndex;
            OgrenciTelNo = OgrenciKayit_TelNo_txt4.Text;
            OgrenciMail = OgrenciKayit_Mail_txt5.Text;
            OgrenciNo = OgrenciKayit_OgrenciNo_txt6.Text;
            OgrenciKayitOnizleme dd = new OgrenciKayitOnizleme();
            dd.Show();

            OgrenciKayit_OgrenciAdı_txt1.Clear();
            OgrenciKyit_OgrenciSoyadı_txt2.Clear();
            OgrenciKayit_TelNo_txt4.Clear();
            OgrenciKayit_Mail_txt5.Clear();
            OgrenciKayit_OgrenciNo_txt6.Clear();
        }

        private void OgrenciKayit_Listele(object sender, RoutedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.ShowDataInGridView("SELECT Uye.*, Bolum.Adi FROM Uye RIGHT JOIN Bolum ON Bolum.Id = Uye.Bolum_Id where Uye_Numara", OgrenciKayitListesi_dvg);
            baglanti.CloseConnection();
        }

        private void OgrenciKayit_Sil(object sender, RoutedEventArgs e)
        {
            if (OgrenciKayit_OgrenciNo_txt6.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Öğrenci numarası bulunamadı!!");
            }
            else
            {
                baglanti.OpenConnection();
                System.Windows.Forms.DialogResult result;
                result = System.Windows.Forms.MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Sil", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
                baglanti.Delete("DELETE FROM Uye WHERE Uye_Numara = '" + OgrenciKayit_OgrenciNo_txt6.Text + "'");
                System.Windows.Forms.MessageBox.Show("Kayıt başarıyla silinmiştir.");
            }
        }

        private void OgrenciKayit_Güncelle(object sender, RoutedEventArgs e)
        {
            if (OgrenciKayit_OgrenciNo_txt6.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Öğrenci numarası bulunamadı!!");
            }
            else
            {
                if (OgrenciKayit_OgrenciAdı_txt1.Text == "" && OgrenciKyit_OgrenciSoyadı_txt2.Text == "" && OgrenciKayit_TelNo_txt4.Text == "" && OgrenciKayit_Mail_txt5.Text == "")
                {
                    Bolum_cmb.SelectedIndex = 0;
                    OgrenciKayit_OgrenciAdı_txt1.Text = "Bilgi girilmedi";
                    OgrenciKyit_OgrenciSoyadı_txt2.Text = "Bilgi girilmedi";
                    OgrenciKayit_TelNo_txt4.Text = "Bilgi girilmedi";
                    OgrenciKayit_Mail_txt5.Text = "Bilgi girilmedi";
                }
                else
                {
                    baglanti.OpenConnection();
                    baglanti.Update("UPDATE Uye SET Adi = '" + OgrenciKayit_OgrenciAdı_txt1.Text + "', Soyadi = '" + OgrenciKyit_OgrenciSoyadı_txt2.Text + "', Telefon_No = '" + OgrenciKayit_TelNo_txt4.Text + "', E_Posta = '" + OgrenciKayit_Mail_txt5.Text + "', Bolum_Id = '" + Bolum_cmb.SelectedIndex + "' WHERE Uye_Numara = '" + OgrenciKayit_OgrenciNo_txt6.Text + "'");
                    System.Windows.Forms.MessageBox.Show("Kayıt başarıyla güncellendi.");
                    
                }
                baglanti.CloseConnection();
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.Filter_Search("SELECT * FROM Uye WHERE Adi LİKE  '%" + Ara_txt.Text + "%'", OgrenciKayitListesi_dvg, Ara_cmb);
            baglanti.CloseConnection();
        }
    }
}
