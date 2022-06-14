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
    /// Interaction logic for OgrenciKayitOnizleme.xaml
    /// </summary>
    public partial class OgrenciKayitOnizleme : Window
    {
        public OgrenciKayitOnizleme()
        {
            InitializeComponent();
            
        }

        DbBaglanti baglanti = new DbBaglanti();

        public void OgrenciKayitOnizleme_load(object sender, RoutedEventArgs e)
        {
            Adi_txt1.Text = OgrenciKayit.OgrenciAdı;
            Soyadi_txt2.Text = OgrenciKayit.OgrenciSoyadı;
            Bolum_cmb.SelectedIndex = OgrenciKayit.OgrenciBolumAdı;
            TelNo_txt4.Text = OgrenciKayit.OgrenciTelNo;
            E_Posta_txt5.Text = OgrenciKayit.OgrenciMail;
            OkulNo_txt6.Text = OgrenciKayit.OgrenciNo;
        }

        private void OgrenciKayitOnizleme_Iptal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OgrenciOnizleme_UyeEkle_Click(object sender, RoutedEventArgs e)
        {
           if(OkulNo_txt6.Text == "")
           {
                System.Windows.Forms.MessageBox.Show("Öğrenci numarası bulunamadı!!");
                this.Close();
           }
           else
           {
                if (Adi_txt1.Text == "" && Soyadi_txt2.Text == "" && TelNo_txt4.Text == "" && E_Posta_txt5.Text == "")
                {
                    Bolum_cmb.SelectedIndex = 0;
                    Adi_txt1.Text = "Bilgi girilmedi";
                    Soyadi_txt2.Text = "Bilgi girilmedi";
                    TelNo_txt4.Text = "Bilgi girilmedi";
                    E_Posta_txt5.Text = "Bilgi girilmedi";
                }
                else
                {
                    baglanti.OpenConnection();
                    baglanti.ExecuteQueries("INSERT INTO Uye (Uye_Numara, Adi, Soyadi, Telefon_No, E_Posta, Bolum_Id) VALUES ('" + OkulNo_txt6.Text + "', '" + Adi_txt1.Text + "', '" + Soyadi_txt2.Text + "', '" + TelNo_txt4.Text + "', '" + E_Posta_txt5.Text + "', '" + Bolum_cmb.SelectedIndex + "')");
                    this.Close();
                }     
           }
            baglanti.CloseConnection();
        }
    }
}
