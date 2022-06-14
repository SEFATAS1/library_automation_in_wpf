using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KutuphaneOtomasyonu.Classes;




namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection con;
        MySqlDataReader dr;
        MySqlCommand cmd;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textSifre_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSifre.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con = new MySqlConnection("server = 172.21.54.3; user id = multimode; password = Multimod.16; database = multimode");
            string sorgu = ("SELECT * FROM Memur WHERE Kullanici_Mail='" + txtKullanıcıAd.Text + "' AND Kullanici_Sifre='" + txtSifre.Text + "'");
            cmd = new MySqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Anasayfa bb = new Anasayfa();
                bb.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            con.Close();
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void KapatButonu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  
        }

        private void SimgeDurumu_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            SifreDegistirme ff = new SifreDegistirme();
            ff.Show();
        }

        private void HyperLink2_Click(object sender, RoutedEventArgs e)
        {
            KaydolEkranı ff = new KaydolEkranı();
            ff.Show();
        }
    }
}
