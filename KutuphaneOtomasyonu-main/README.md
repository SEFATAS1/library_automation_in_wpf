### C# ve MySql Kullanılarak Hazırlanmış Kütüphane Otomasyonu Projesi
# Projenin Amacı ve Kapsamı:
Projemizin amacı okulumuzda öğrenim görmekte olan öğrencilere kitap kayıt ve kitap işlemleri verilerinin saklayabilecek hızlıca sistemi kullanıp memurlara erişim imkanı sağlayacak, kitap, öğrenci akademisyen bilgilerini girmesini ve düzenlemesini kolayca yapabileceği bilgisayar destekli bir sistemin ortaya konmasıdır.
</br>
Bu amaç doğrultusunda kütüphanede bulunan kitapların takibi, emanet , öğrenci , akademisyen kaydı ve kütüphane memurlarının raporları veya istediği bilgiyi kolay bir şekilde araması gibi detaylar yer almaktadır.
</br>
# Proje Süreci ve İlerleyişi: 
a)İlk olarak kütüphane memurları ile görüşüp eksiklikleri ve hataları belirledik.
b)Memurların ihtiyaç ve isteklerine göre ilerleyiş sürecimizi taslağa dökebilmek için gereksinim analizi ve E&R diyagramı oluşturduk. 
c)Oluşturduğumuz taslaklara göre kullanım pratikliği ve değişkenlerin elverişliliği sağlayan **MySql** veritabanını kullanarak tablolarımızı oluşturduk.
d)Sade ve kolay kullanım sağlayan bir tasarım modeli oluşturduk.
e)**C#** kullanarak back end kodlarımızı oluşturduk ve projemizi tamamladık.
</br>
# Otomasyonun Kullanım Şekli ve Prensipleri:
1)Kullanıcı girişi için exe dosyasını açıyoruz ve bizi kullanıcı giriş ekranı karşılıyor.Kayıtlı bir kullanıcıysak bilgileri doldurup giriş yap tuşuna basıyoruz ve anasayfaya yönlendiriliyoruz.
</br>
![image](https://user-images.githubusercontent.com/73906140/170838122-c84d8cbb-5eea-4cad-91df-2c5c35371c0a.png)
2)Otomasyona kayıtlı değilsek kullanıcı giriş ekranından kayıt ol tuşuna basıyoruz ve kaydolma ekranını açıyoruz ve bilgileri doldurarak kaydol tuşuna basıyoruz ve kaydoluyoruz.
![Kayıt Ol Ekranı](https://user-images.githubusercontent.com/100084384/170835575-61f97d47-cc76-48ee-98ab-d379826ccaf9.png)
3)Kayıtlı hesaba sahip kullanıcıysak ve şifresimizi unuttuysak kullanıcı giriş ekranında bulunan şifremi unuttum tuşuna basıyoruz ve mail adresimizi girip şifremizi mail adresimizden öğrenebiliyoruz.
![Şifremi Unuttum Ekranı](https://user-images.githubusercontent.com/100084384/170835611-ea7b4e82-3e8a-43b6-b63d-b2e5635ebaa4.png)
</br>
4)Kullanıcı bilgilerini doğru girip **Giriş Yap** butonuna bastıktan sonra bizi anasayfa karşılıyor ve soldaki menüden otomasyonun bütün fonksiyonlarına erişebiliyoruz.
![Anasayfa Ekranı](https://user-images.githubusercontent.com/100084384/170836332-bb557aa0-b575-4acc-af5d-d53373bd877d.png)
5)Kitap listesi butonuna basarak bütün kitapları görüntüleyebilir ve emanet vereceğimiz kitabı seçerek öğrenci bilgilerini doldurup **Emanet Ver** butonuna basarak kitabı öğrenciye emanet verebiliriz.
![Kitap Listesi Ekranı](https://user-images.githubusercontent.com/100084384/170836429-2e5d6de1-6dc6-47bf-a5d4-172f37c36564.png)
6)Kitap ekle butonuna basarak ekleyeceğimiz kitabın bilgilerini girebilir ve kaydet butonuna bastıktan sonra ön izleme sayfasıyla karşılaşıp kitap bilgilerini kaydedebiliriz.Bu ekranda kitap bilgilerini güncelleyip , kategori ekleyebilir ve var olan bir kitabı silebiliriz.
![Kitap Ekle Ekranı](https://user-images.githubusercontent.com/100084384/170836472-b743eaae-27b4-4798-b83e-86f6541d5466.png)
![Kitap Ekle Ön İzleme](https://user-images.githubusercontent.com/100084384/170836599-59f9683d-4127-4e41-a51f-c4b78d708956.png)
7)Akademisyen ekle butonuna basarak ekleyeceğimiz akademisyenin bilgilerini girebilir ve kaydet butonuna bastıktan sonra ön izleme sayfasıyla karşılaşıp akademisyen bilgilerini kaydedebiliriz.Kayıtlı olan akademisyenleri görüntüleyip bilgilerini güncelleyebilir ve silebiliriz.
![Akademisyen Ekle Ekranı](https://user-images.githubusercontent.com/100084384/170837139-9bb8e2ba-632f-4cc2-956f-dabe57fc9072.png)
</br>
![Akademisyen Önizleme](https://user-images.githubusercontent.com/100084384/170836641-48819450-66bb-4b85-8658-bc8765f70309.png)
8)Öğrenci ekle butonuna basarak ekleyeceğimiz öğrencinin bilgilerinibilgilerini girebilir ve kaydet butonuna bastıktan sonra ön izleme sayfasıyla karşılaşıp öğrenci bilgilerini kaydedebiliriz.Kayıtlı olan öğrencileri görüntüleyip bilgilerini güncelleyebilir ve silebiliriz.
![Öğrenci Kayıt Ekran](https://user-images.githubusercontent.com/100084384/170836540-6683015e-256c-4303-8eb3-e40248ff3196.png)
</br>
![Öğrenci Ön İzleme](https://user-images.githubusercontent.com/100084384/170836731-e1206ffe-f341-4a68-81b3-cef008a59805.png)
9)Anlık okuyucular butonuna basarak üzerinde emanet kitap olan akademisyen ve öğrencileri görüntüleyip kitabın memura teslim edilmesi üzerine **Emanetten Geri Al** butonu ile verileri anlık okuyuculardan kaldırabiliriz.
![Anlık Okuyucular Ekranı](https://user-images.githubusercontent.com/100084384/170836769-61bb84ac-89b2-4b37-8a21-f09dd9ff1549.png)
10)Zamanı dolanlar butonuna basarak teslim süresini aşmış akademisyen ve öğrencileri görüntüleyebiliriz.
![Zamanı Dolanlar Ekranı](https://user-images.githubusercontent.com/100084384/170836814-1badd46a-9673-4e26-9a2b-e7df5a802ce4.png)
11)Kayıp kitaplar butonuna basarak kütüphane içinde kaybolan kitapları görüntüleyip daha sonra kitabın bulunması üzerine durumunu değiştirebiliriz.
![Kayıp Kitaplar Ekranı](https://user-images.githubusercontent.com/100084384/170836834-5a4b0310-4d98-43f6-9b00-db0bdbd7679a.png)
12)Raporlar butonuna basarak kütüphane içerisinde memurun ihtiyacı olan istatistikler verilere ulaşabiliriz.
![Raporlar Ekranı](https://user-images.githubusercontent.com/100084384/170836862-3578b56a-b0c4-4fd1-9ec4-f65fb32cd575.png)
14)Ayarlar ekranı ile memur öğrencinin bölümünü seçip ona göre cezayı değiştirebilir ve uygulayabilir.
![Ayarlar Ekranı](https://user-images.githubusercontent.com/100084384/170837266-e079d42c-d51c-4b38-81b4-1f549896ab8f.png)
15)Oturumu kapat butonuna basarsak kullanıcı giriş ekranına döner ve kullanıcı giriş ekranındaki fonksiyonlara erişebiliriz.





