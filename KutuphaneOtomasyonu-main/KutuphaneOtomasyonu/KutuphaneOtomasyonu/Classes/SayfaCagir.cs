
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KutuphaneOtomasyonu.Classes
{
    public class SayfaCagir
    {
        public static void SayfaEkle(System.Windows.Controls.Grid grd, UserControl usrcntrl)
        {
            if (grd.Children.Count > 0)
            {
                grd.Children.Clear();
                grd.Children.Add(usrcntrl);
            }
            else
            {
                grd.Children.Add(usrcntrl);
            }

        }
        
    }
}
