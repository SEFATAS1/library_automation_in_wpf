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

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for Raporlar.xaml
    /// </summary>
    public partial class Raporlar : UserControl
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=172.21.54.3; user id=multimode; password=Multimod.16; database=multimode;");

        private void Raporlar_load(object sender, RoutedEventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut1 = new MySqlCommand("Select Count(*) From Kitap", baglanti);
            MySqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                Toplamkitap_Lbl.Content = dr1[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            MySqlCommand komut2 = new MySqlCommand("Select Count(*) From Kayip_Kitap", baglanti);
            MySqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                Kayipkitap_Lbl.Content = dr2[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            MySqlCommand komut3 = new MySqlCommand("SELECT COUNT(Id), Barkod_Numarasi FROM Odunc GROUP BY Barkod_Numarasi ORDER BY COUNT(Id) DESC", baglanti);
            MySqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                Encokokunan_Lb.Items.Add(dr3["Barkod_Numarasi"]);
            }
            baglanti.Close();

            baglanti.Open();
            MySqlCommand komut4 = new MySqlCommand("Select Count(*) From Odunc", baglanti);
            MySqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                Emanetkitap_Lbl.Content = dr4[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            MySqlCommand komut5 = new MySqlCommand("Select Count(*) From Uye", baglanti);
            MySqlDataReader dr5 = komut5.ExecuteReader();
            if (dr5.Read())
            {
                UyeSayisi_Lbl.Content = dr5[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            MySqlCommand komut6 = new MySqlCommand("SELECT COUNT(Id), Uye_Numarasi FROM Odunc GROUP BY Uye_Numarasi ORDER BY COUNT(Id) DESC", baglanti);
            MySqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                Encokokunan_Lb.Items.Add(dr6["Uye_Numarasi"]);
            }
            baglanti.Close();
        }
    }
}
