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
using MySql.Data.MySqlClient;
using KutuphaneOtomasyonu.Classes;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for KitapEkle.xaml
    /// </summary>
    public partial class KitapEkle : System.Windows.Controls.UserControl
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        public static string KitapAdı;
        public static string YazarAdı;
        public static string CevirmenAdı;
        public static string YayıneviAdı;
        public static string YayimYili;
        public static string Dili;
        public static string DemirbasNo;
        public static string ISBN;
        public static string KayitTarihi;
        public static string BaskiNo;
        public static string StokAdedi;
        public static int Konumu;
        public static int Konumu2;
        public static int Durumu;
        public static int Kategori;

        DbBaglanti baglanti = new DbBaglanti(); 

        DateTime DtN = new DateTime();

        

        private void KitapListesi_Load(object sender, RoutedEventArgs e)
        {
            KayitTarihi_txt9.Text = DtN.ToString("dd.MM.yyyy " + " HH:mm");
        }

        private void KitapListesi_Ekle_Click(object sender, RoutedEventArgs e)
        {
            KitapAdı = Adi_txt1.Text;
            YazarAdı = Yazari_txt2.Text;
            CevirmenAdı = Cevirmen_txt3.Text;
            YayıneviAdı = Yayinevi_txt4.Text;
            YayimYili = YayimYili_txt5.Text;
            
            DemirbasNo = DemirbasNo_txt7.Text;
            ISBN = ISBN_txt8.Text;
            KayitTarihi = KayitTarihi_txt9.Text;
            BaskiNo = Baski_txt10.Text;
            Konumu = Kitaplik_cmb.SelectedIndex;
            Konumu2 = Raf_cmb.SelectedIndex;
            Durumu = Durum_cmb.SelectedIndex;
            Kategori = KategoriAdlari_cmb.SelectedIndex;

            KitapEkleOnizleme onizleme = new KitapEkleOnizleme();
            onizleme.Show();

            Adi_txt1.Clear();
            Yazari_txt2.Clear();
            Cevirmen_txt3.Clear();
            Yayinevi_txt4.Clear();
            YayimYili_txt5.Clear();
            
            DemirbasNo_txt7.Clear();
            ISBN_txt8.Clear();
            KayitTarihi_txt9.Clear();
            Baski_txt10.Clear();         
        }

        private void KitapListesi_Listele_Click(object sender, RoutedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.ShowDataInGridView("SELECT Demirbas_No AS 'Demirbaş_Numarası', Adi AS 'Adı', ISBN, Kitaplik AS 'Kitaplık', Raf, Durum_Adi AS 'Durum_Adı', Kategori_Adi AS 'Kategori_Adı', Yayinevi_Adi AS 'Yayınevi_Adı', Adi_Soyadi AS Yazar, Adi_Soyad AS 'Cevirmen', Kayit_Tarihi AS 'Kayıt_Tarihi', Yayim_Yili AS 'Yayım_Yılı' FROM Kitap, Cevirmen, Durum, Kategori, Baski, Yayinevi, Yazar WHERE Kitap.Baski_Id = Baski.Id AND Baski.Cevirmen_Id = Cevirmen.Id AND Kitap.Durum_Id = Durum.Id AND Kitap.Kategori_Id = Kategori.Id AND Baski.Yayinevi_Id = Yayinevi.Id AND Kitap.Yazar_Id = Yazar.Id", KitapEkle_dgv );
            baglanti.CloseConnection();
        }

        private void KitapListesi_Sil_Click(object sender, RoutedEventArgs e)
        {
            if (DemirbasNo_txt7.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Demirbaş numarası bulunamadı!!");
            }
            else
            {
                baglanti.OpenConnection();
                DialogResult result;
                result = System.Windows.Forms.MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                baglanti.Delete("DELETE FROM Kitap WHERE Demirbas_No = '" + DemirbasNo_txt7.Text + "'");
                System.Windows.Forms.MessageBox.Show("Kayıt başarıyla silinmişir.");
                baglanti.CloseConnection();
            }
        }

        private void KitapListesi_Güncelle_Click(object sender, RoutedEventArgs e)
        {
            if (DemirbasNo_txt7.Text== "")
            {
                System.Windows.Forms.MessageBox.Show("Demirbaş numarası bulunamadı!!");
            }
            else
            {
                if (Adi_txt1.Text == "" && Yazari_txt2.Text == ""  )
                {
                    Adi_txt1.Text = "Bilgi girilmedi";
                    Yazari_txt2.Text = "Bilgi girilmedi";
                    Adi_txt1.Text = "Bilgi girilmedi";
                    Adi_txt1.Text = "Bilgi girilmedi";
                }
                else
                {

                }
                baglanti.OpenConnection();

                baglanti.Update("UPDATE Yazar SET Yayinevi_Adi = '" + Yayinevi_txt4.Text + "'");
                int deger1 = baglanti.LastInsertedId();

                

                baglanti.Update("UPDATE Kitap SET Demirbas_No='" + DemirbasNo_txt7.Text + "', Adi='" + Adi_txt1.Text + "', Yazar_Id='" + Yazari_txt2.Text + "', Kategori_Id='" + KategoriAdlari_cmb.SelectedIndex + "', Baski_Id='" + Baski_txt10.Text + "', Yayim_Yili='" + YayimYili_txt5.Text + "', ISBN='" + ISBN_txt8.Text + "' ,Kayit_Tarihi='" + KayitTarihi_txt9.Text + "',  Kitaplik='" + Kitaplik_cmb.SelectedIndex + "', Raf='" + Raf_cmb.SelectedIndex + "', Durum_Id='" + Durum_cmb.SelectedIndex + "'");
                System.Windows.Forms.MessageBox.Show("Kayıt başarıyla güncellendi.");
                baglanti.CloseConnection();
            }
        }
    }
}
