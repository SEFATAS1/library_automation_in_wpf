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

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for KayipKitaplar.xaml
    /// </summary>
    public partial class KayipKitaplar : UserControl
    {
        public KayipKitaplar()
        {
            InitializeComponent();
        }

        DateTime DtN = new DateTime();
                     
        private void KayıpKitap_Load(object sender, RoutedEventArgs e)
        {
            DtN = DateTime.Now;
            KayipKitap_BildirilmeTatihi_text3.Text = DtN.ToString("dd.MM.yyyy " + " HH:mm:ss");
        }
    }
}
