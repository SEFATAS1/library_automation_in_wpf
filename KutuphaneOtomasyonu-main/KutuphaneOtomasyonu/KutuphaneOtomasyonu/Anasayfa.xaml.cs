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
using System.Windows.Shapes;
using KutuphaneOtomasyonu.Classes;
using KutuphaneOtomasyonu;
using MySql.Data.MySqlClient;


namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for Anasayfa.xaml
    /// </summary>
    public partial class Anasayfa : Window
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=172.21.54.3; user id=multimode; password=Multimod.16; database=multimode;");

        private void KapatButonu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SimgeDurumuButon_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void anasayfa_btn(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new BosAnasayfa());
        }

        private void oturum_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow xx = new MainWindow();
            xx.Show();
        }

        private void MenuButon_KitapListesi_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new KitapListesi());
        }

        private void MenuButon_KitapEkle_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new KitapEkle());
        }

        private void MenuButon_AkademisyenKayıt_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new AkademisyenKayit());
        }

        private void MenuButon_OgrenciKayıt_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new OgrenciKayit());
        }

        private void MenuButon_AnlikOkuyucular_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new AnlikOkuyucular());
        }

        private void MenuButon_ZamaniDolanlar_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new ZamaniDolanlar());
        }

        private void MenuButon_KayipKitaplar_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new KayipKitaplar());
        }

        private void MenuButon_Raporlar_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new Raporlar());
        }

        private void MenuButon_BelgeSorgulama_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new BelgeSorgulama());
        }

        private void MenuButon_Ayarlar_Click(object sender, RoutedEventArgs e)
        {
            SayfaCagir.SayfaEkle(MasterPage, new Ayarlar());
        }

        bool flag = true;

        public object DataGv { get; private set; }

        private void MenuAcKapa_btn(object sender, RoutedEventArgs e)
        {
            double Genislik;
            Genislik = 288.4;

            if (flag == true)
            {
                GridLength grd = new GridLength(4, GridUnitType.Star);
                MenuBoyut.Width = grd;
                Anasayfa_Viewbox.Width = Genislik;               
                KitapEkle_lbl.Visibility = Visibility.Hidden;
                KitapListesi_lbl.Visibility = Visibility.Hidden;
                AkademisyenKayit_lbl.Visibility = Visibility.Hidden;
                OgrenciKayit_lbl.Visibility = Visibility.Hidden;
                AnlikOkuyucular_lbl.Visibility = Visibility.Hidden;
                KayipKitaplar_lbl.Visibility = Visibility.Hidden;
                ZamaniDolanlar_lbl.Visibility = Visibility.Hidden;
                Raporlar_lbl.Visibility = Visibility.Hidden;
                Ayarlar_lbl.Visibility = Visibility.Hidden;
                Cikis_lbl.Visibility = Visibility.Hidden;
                VersiyonNumarasi_lbl.Visibility = Visibility.Hidden;
                Baslik_lbl.Visibility = Visibility.Hidden;               
                flag = false;
            }
            else
            {
                GridLength grd = new GridLength(20, GridUnitType.Star);
                MenuBoyut.Width = grd;
                Anasayfa_Viewbox.Width = Genislik;               
                KitapEkle_lbl.Visibility = Visibility.Visible;
                KitapListesi_lbl.Visibility = Visibility.Visible;
                AkademisyenKayit_lbl.Visibility = Visibility.Visible;
                OgrenciKayit_lbl.Visibility = Visibility.Visible;
                AnlikOkuyucular_lbl.Visibility = Visibility.Visible;
                KayipKitaplar_lbl.Visibility = Visibility.Visible;
                ZamaniDolanlar_lbl.Visibility = Visibility.Visible;
                Raporlar_lbl.Visibility = Visibility.Visible;
                Ayarlar_lbl.Visibility = Visibility.Visible;
                Cikis_lbl.Visibility = Visibility.Visible;
                VersiyonNumarasi_lbl.Visibility = Visibility.Visible;
                Baslik_lbl.Visibility = Visibility.Visible;                
                flag = true;
            }
        }





        //public void TextSearch_TextChanged(DataGrid dvg)
        //{
        //    if (Filter_Cb.SelectedIndex == 0)
        //    {
        //        baglanti.Open();
        //        DataTable tbl = new DataTable();

        //        MySqlDataAdapter ara = new MySqlDataAdapter("select * from Kitap where Adi like '%" + TextSearch.Text + "%' ", baglanti);
        //        ara.Fill(tbl);
        //        DataGv.DataSource = tbl;
        //        baglanti.Close();

        //    }
        //    else if (Filter_Cb.SelectedIndex == 1)
        //    {
        //        baglanti.Open();
        //        DataTable tbl = new DataTable();

        //        MySqlDataAdapter ara = new MySqlDataAdapter("select * from Kitap where Yazar_Id like '%" + TextSearch.Text + "%' ", baglanti);
        //        ara.Fill(tbl);
        //        baglanti.Close();
        //        DataGv.DataSource = tbl;
        //    }
        //}     
    }
}
