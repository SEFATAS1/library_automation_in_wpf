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
    /// Interaction logic for AnlikOkuyucular.xaml
    /// </summary>
    public partial class AnlikOkuyucular : UserControl
    {
        public AnlikOkuyucular()
        {
            InitializeComponent();
        }

        DbBaglanti baglanti = new DbBaglanti();
      

        private void btnEmanetVer(object sender, RoutedEventArgs e)
        {
              
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.Filter_Search("SELECT * FROM Uye WHERE Adi LİKE  '%" + Ara_txt.Text + "%'", AnlikOkuyucular_dgv, Ara_cmb);
            baglanti.CloseConnection();
        }
    }
}
