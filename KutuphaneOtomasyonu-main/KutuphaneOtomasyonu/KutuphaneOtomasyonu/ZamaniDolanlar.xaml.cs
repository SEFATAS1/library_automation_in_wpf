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

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for ZamaniDolanlar.xaml
    /// </summary>
    public partial class ZamaniDolanlar : UserControl
    {
        public ZamaniDolanlar()
        {
            InitializeComponent();
        }

        DbBaglanti baglanti = new DbBaglanti();

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.OpenConnection();
            baglanti.Filter_Search("SELECT * FROM Uye WHERE Adi LİKE  '%" + Ara_txt.Text + "%'", ZamaniDolanlar_dgv, Ara_cmb);
            baglanti.CloseConnection();
        }
    }
}
