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
    /// Interaction logic for KitapEkleOnizleme.xaml
    /// </summary>
    public partial class KitapEkleOnizleme : Window
    {
        public KitapEkleOnizleme()
        {
            InitializeComponent();
        }

        DbBaglanti baglanti = new DbBaglanti();

        private void KitapEkleOnizleme_Load(object sender, RoutedEventArgs e)
        {
            Adi_txt1.Text = KitapEkle.KitapAdı;
            Yazari_txt2.Text = KitapEkle.YazarAdı;
            Cevirmen_txt3.Text = KitapEkle.CevirmenAdı;
            Yayinevi_txt4.Text = KitapEkle.YayıneviAdı;
            YayimYili_txt5.Text = KitapEkle.YayimYili;
            
            DemirbasNo_txt7.Text = KitapEkle.DemirbasNo;
            ISBN_txt8.Text = KitapEkle.ISBN;
            KayitTarihi_txt9.Text = KitapEkle.KayitTarihi;
            BaskiNo_txt10.Text = KitapEkle.BaskiNo;
            
            Kitaplik_cmb.SelectedIndex = KitapEkle.Konumu;
            Raf_cmb.SelectedIndex = KitapEkle.Konumu2;
            Durum_cmb.SelectedIndex = KitapEkle.Durumu;
            KategoriAdlari_cmb.SelectedIndex = KitapEkle.Kategori;
        }

        private void KitapEkle_KitapEkleOnizleme_Iptal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KitapEkle_KitapEkleOnizleme_Ekle_Click(object sender, RoutedEventArgs e)
        {
            if (DemirbasNo_txt7.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Demirbaş numarası bulunamadı!!");
                this.Close();
            }
            else
            {
                baglanti.OpenConnection();

                if (Yazari_txt2.Text == "")
                {
                    Yazari_txt2.Text = "YOK";
                }
                else
                {
                    baglanti.ExecuteQueries("INSERT INTO Yazar (Adi_SoyAdi) VALUES ('" + Yazari_txt2.Text + "')");                    
                }
                int deger1 = baglanti.LastInsertedId();

                if (Cevirmen_txt3.Text == "")
                {
                    Cevirmen_txt3.Text = "YOK";
                }
                else
                {
                    baglanti.ExecuteQueries("INSERT INTO Cevirmen (Adi_Soyad) VALUES ('" + Cevirmen_txt3.Text + "')");
                }
                int deger2 = baglanti.LastInsertedId();

                if (Yayinevi_txt4.Text == "")
                {
                    Yayinevi_txt4.Text = "YOK";
                }
                else
                {
                    baglanti.ExecuteQueries("INSERT INTO Yayinevi (Adi) VALUES ('" + Yayinevi_txt4.Text + "')");
                }
                int deger3 = baglanti.LastInsertedId();

                baglanti.ExecuteQueries("INSERT INTO Baski (Baski_Sayisi, Cevirmen_Id, Yayinevi_Id) VALUES ('" + BaskiNo_txt10.Text + "', '"+deger2+"', '"+deger3+"')");
                int deger4 = baglanti.LastInsertedId();

                baglanti.ExecuteQueries("INSERT INTO Kitap (Demirbas_No, Adi, Yazar_Id, Kategori_Id, Baski_Id, Yayim_Yili, Kayit_Tarihi, Kitaplik, Raf, Durum_Id, ISBN) VALUES ('"+ DemirbasNo_txt7.Text +"',  '"+ Adi_txt1.Text +"', '"+ deger1 +"', '"+ KategoriAdlari_cmb.SelectedIndex +"', '"+ deger4 +"', '"+ YayimYili_txt5.Text +"', '"+ KayitTarihi_txt9.Text +"', '"+ Kitaplik_cmb.Text +"', '"+ Raf_cmb.Text + "', '" + Durum_cmb.SelectedIndex + "', '"+ISBN_txt8.Text+"')");
                this.Close();
                System.Windows.Forms.MessageBox.Show("Kayıt Başarıyla Oluşturuldu");
            }
            baglanti.CloseConnection();        
        }
    }    
}
