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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KutuphaneOtomasyonu.Classes;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for KitapListesi.xaml
    /// </summary>
    public partial class KitapListesi : UserControl
    {
        DbBaglanti baglanti = new DbBaglanti();

        

        private void KitapListesi_load(object sender, RoutedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.ShowDataInGridView("SELECT Demirbas_No AS DemirbasNumarasi, Adi AS Adi, ISBN, Kitaplik AS Kitaplik, Raf, Durum_Adi AS DurumAdi, Kategori_Adi AS KategoriAdi, Yayinevi_Adi AS YayıneviAdi, Adi_Soyadi AS Yazar_AdiSoyadi, Adi_Soyad AS CevirmenAdiSoyadi, Kayit_Tarihi AS KayitTarihi, Yayim_Yili AS YayimYili FROM Kitap, Cevirmen, Durum, Kategori, Baski, Yayinevi, Yazar WHERE Kitap.Baski_Id = Baski.Id AND Baski.Cevirmen_Id = Cevirmen.Id AND Kitap.Durum_Id = Durum.Id AND Kitap.Kategori_Id = Kategori.Id AND Baski.Yayinevi_Id = Yayinevi.Id AND Kitap.Yazar_Id = Yazar.Id", KitapListesi_dgv);
            baglanti.CloseConnection();
        }
      
        public KitapListesi()
        {
            InitializeComponent();
        }

        private void btnEmanetVer(object sender, RoutedEventArgs e)
        {
            if (UyeNumara_txt.Text == "" && TelefonNo_txt.Text == "" && Adi_txt.Text == "" && soyadi_txt.Text == "" && Eposta_txt.Text == "")
            {
                MessageBox.Show("Bilgileri lütfen doldurunuz.");
            }
            else
            {
                baglanti.OpenConnection();
                baglanti.ExecuteQueries("INSERT INTO sepet (Uye_Numara,Adi,Soyadi,Telefon_No,E_Posta,Demirbas_No, Kitap_Adi, Yazari, Yayinevi, Kitap_Sayisi, Teslim_Tarihi, İade_Tarihi) VALUES ('" + UyeNumara_txt.Text + "','" + Adi_txt.Text + "' ,'" + soyadi_txt.Text + "','" + TelefonNo_txt.Text + "','" + Eposta_txt.Text + "''" + demirbasno_txt.Text + "', '" + kitapadi_txt.Text + "', '" + yazari_txt.Text + "', '" + yayinevi_txt.Text + "', '" + kitapsayisi_txt.Text + "', '" + teslimtarihi_txt.Text + "', '" + iadetarihi_txt.Text + "'");
                //baglanti.Update("UPDATE Uye SET OkuduguKitapSayisi=OkuduguKitapSayisi+'"+int.Parse();
                baglanti.CloseConnection();
            }
            baglanti.OpenConnection();
            baglanti.Delete("DELETE * FROM sepet");
            baglanti.CloseConnection();
            MessageBox.Show("Kitaplar Emanet Edildi.");
                
            
            
        }
        

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.Filter_Search("SELECT * FROM Kitap WHERE Adi LİKE  '%"+ Ara_txt.Text +"%'", KitapListesi_dgv, Ara_cmb);
            baglanti.CloseConnection(); 
        }

        private void OgrenciBul_txtChange(object sender, TextChangedEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=172.21.54.3;userid=multimode;password=Multimod.16;database=multimode;");
            string sorgu = "SELECT OkuduguKitapSayisi FROM Uye";
            var deger = new MySqlCommand(sorgu, con);
            int deger1 = int.Parse(deger.ToString());

            if (deger1 == int.Parse( kitap_txt.Text))
            {

            }
            else
            {
                
                con.Open();
                MySqlCommand komut = new MySqlCommand("SELECT * FROM Uye WHERE Uye_Numara LIKE '" + UyeNumara_txt.Text + "' ", con);
                MySqlDataReader read = komut.ExecuteReader();
                while (read.Read())
                {
                    UyeNumara_txt.Text = read["Uye_Numara"].ToString();
                    Adi_txt.Text = read["Adi"].ToString();
                    soyadi_txt.Text = read["Soyadi"].ToString();
                    TelefonNo_txt.Text = read["Telefon_No"].ToString();
                    Eposta_txt.Text = read["E_posta"].ToString();
                }
                con.Close();
            }

           
            
        }

        private void KitapAra_txtChange(object sender, TextChangedEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=172.21.54.3;userid=multimode;password=Multimod.16;database=multimode;");
            con.Open();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM Kitap WHERE Demirbas_No LIKE '" + demirbasno_txt.Text + "' ", con);
            MySqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                demirbasno_txt.Text = read["Demirbas_No"].ToString();
                kitapadi_txt.Text = read["Adi"].ToString();
                yazari_txt.Text = read["Yazar_Id"].ToString();
              
               
             
            }
            con.Close();
        }

        private void Temizle_Click(object sender, RoutedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.Delete("DELETE FROM sepet WHERE Demirbas_No = '"+ demirbasno_txt.Text +"'");
            baglanti.CloseConnection();
            MessageBox.Show("Silme İşlemi Yapıldı.");
        }

        private void KitapListesi_Click(object sender, RoutedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.ShowDataInGridView("SELECT * FROM sepet", KitapListesi_dgv);
            baglanti.CloseConnection();
        }

        private void Ekle_btn(object sender, RoutedEventArgs e)
        {
            if (demirbasno_txt.Text == "" && kitapadi_txt.Text == "" && yazari_txt.Text == "" && yayinevi_txt.Text == "" && kitapsayisi_txt.Text == "" && teslimtarihi_txt.Text == "" && iadetarihi_txt.Text == "")
            {
                MessageBox.Show("Girilen Bilgiler Eksiktir!!");
            }
            else
            {
                baglanti.OpenConnection();
                baglanti.ExecuteQueries("INSERT INTO sepet (Demirbas_No, Kitap_Adi, Yazari, Yayinevi, Kitap_Sayisi, Teslim_Tarihi, İade_Tarihi) VALUES ('" + demirbasno_txt.Text + "', '" + kitapadi_txt.Text + "', '" + yazari_txt.Text + "', '" + yayinevi_txt.Text + "', '" + kitapsayisi_txt.Text + "', '" + teslimtarihi_txt.Text + "', '" + iadetarihi_txt.Text + "')");
                MessageBox.Show("Kitap başarıyla emanet edildi.");
                baglanti.CloseConnection();
            }
        }
    }

}
