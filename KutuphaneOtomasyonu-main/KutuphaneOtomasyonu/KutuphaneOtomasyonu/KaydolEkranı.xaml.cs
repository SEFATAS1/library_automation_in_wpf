using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using KutuphaneOtomasyonu.Classes;

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for KaydolEkranı.xaml
    /// </summary>
    public partial class KaydolEkranı : Window
    {
        DbBaglanti baglanti = new DbBaglanti(); 

        public KaydolEkranı()
        {
            InitializeComponent();
            
        }
        private void Kpt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        bool flag = true;
        private void Kaydol_Cilick(object sender, RoutedEventArgs e)
        {

            if (InglIsltm_Btn.IsChecked == flag)
            {
                baglanti.OpenConnection();
                baglanti.ExecuteQueries("insert into Memur(Adi,Soyadi,Okul_Id,Kullanici_Mail,Kullanici_Sifre) values ('" + KullaniciAdi_txt1.Text + "','" + KullaniciSoyadi_txt2.Text + "','" + 1 + "','" + KullaniciMail_txt3.Text + "','" + KullaniciSifresi_txt4.Text + "')");
                baglanti.CloseConnection();
                this.Close();
            }
            else if (InglMslk_Btn.IsChecked == flag)
            {
                baglanti.OpenConnection();
                baglanti.ExecuteQueries("insert into Memur(Adi,Soyadi,Okul_Id,Kullanici_Mail,Kullanici_Sifre) values ('" + KullaniciAdi_txt1.Text + "','" + KullaniciSoyadi_txt2.Text + "','" + 2 + "','" + KullaniciMail_txt3.Text + "','" + KullaniciSifresi_txt4.Text + "')");
                baglanti.CloseConnection();
                this.Close();
            }
        }
    }
}
