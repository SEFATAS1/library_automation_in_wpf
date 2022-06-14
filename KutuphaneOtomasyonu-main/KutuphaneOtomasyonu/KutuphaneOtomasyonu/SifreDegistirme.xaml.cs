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
using System.Security;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace KutuphaneOtomasyonu
{
    /// <summary>
    /// Interaction logic for SifreDegistirme.xaml
    /// </summary>
    public partial class SifreDegistirme : Window
    {
        public SifreDegistirme()
        {
            InitializeComponent();
        }

        public bool MailGonder(string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("denememailyollama@gmail.com");
            ePosta.To.Add(MailGonder1_txt.Text);

            ePosta.Subject = konu;
            ePosta.Body = icerik;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("denememailyollama@gmail.com", "denememailyollama1234");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Send(ePosta);
            object userState = true;
            bool kontrol = true;
            try
            {
                client.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                MessageBox.Show(ex.Message);
            }
            return kontrol;
        }

        string sifre;
       
        private void MailGonder_Click(object sender, RoutedEventArgs e)
        {
            MailGonder_lbl.Visibility = Visibility.Hidden;
            try
            {
                MySqlConnection baglanti = new MySqlConnection("server=172.21.54.3; user id=multimode; password=Multimod.16; database=multimode;");
                if (baglanti.State == System.Data.ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlCommand komut = new MySqlCommand("SELECT * FROM Memur WHERE Kullanici_Mail = '" + MailGonder1_txt.Text + "'");
                komut.Connection = baglanti;
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    sifre = oku["Kullanici_Sifre"].ToString();
                    this.Close();

                    MailGonder_lbl.Visibility = Visibility.Visible;
                    Color ff = new Color();
                    ff = Color.FromRgb(119, 247, 0);
                    MailGonder_lbl.Foreground = new SolidColorBrush(ff);
                    MailGonder_lbl.Content = "Girmiş olduğunuz bilgiler uyuşuyor sifreniz mail olarak göbderildi.";


                    MailGonder("ŞifRE HATIRLATMA", "ŞİFRENİZ:" + sifre);
                    baglanti.Close();
                }
                else
                {
                    Color gg = new Color();
                    gg = Color.FromRgb(119, 247, 0);
                    MailGonder_lbl.Visibility = Visibility.Visible;
                    MailGonder_lbl.Foreground = new SolidColorBrush(gg);
                    MailGonder_lbl.Content = "Girmiş olduğunuz bilgiler uyuşmuyor.";
                }
            }
            catch (Exception)
            {
                MailGonder_lbl.Visibility = Visibility.Visible;
                Color hh = new Color();
                hh = Color.FromRgb(246, 0, 0);
                MailGonder_lbl.Foreground = new SolidColorBrush(hh);
                MailGonder_lbl.Content = "Mail gönderme hatası!";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }

        private void MailGonder_txt(object sender, DependencyPropertyChangedEventArgs e)
        {
            MailGonder1_txt.Clear();
        }
    }
}
