using LibraryAutomationApplication.Classlar;
using LibraryAutomationApplication.Classlar.Parametreler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LibraryAutomationApplication
{
    /// <summary>
    /// Interaction logic for winKitapEkle.xaml
    /// </summary>
    public partial class winKitapEkle : Window
    {
        

        public winKitapEkle()
        {
            InitializeComponent();
        }

        sbyte resimSecildimi = 0; //önce resim seçilmemiş olsun default resimi kaydetmek için yapıyorum 

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {//baskisayisi için integer olmalı 
            if (!char.IsDigit(e.Text, e.Text.Length-1))
            { //harf girmesini engeller 
                e.Handled = true; 
            }
        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            { //harf girmesini engeller 
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_3(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            { //harf girmesini engeller 
                e.Handled = true;
            }
        }

        private void btn_KitapKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1; //gk eski haline dönecek

        }

        private void btn_KitapEkleBilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_Bilgi); //classdan popupshow popup bilgiyi gönder
            Bonus.SesCal();
        }

        private void btn_KitapEkle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //kitap ekleye basınca boş geçilemeyen kısımlar olsun 
            if (txt_barkod.Text != "" && txt_kitapturu.Text !="" && txt_kitapadi.Text != "")
            {//boş değilse 
                Prm veri = new Prm();
                Prm.BarkodNo = txt_barkod.Text;
                veri.Barkod = txt_barkod.Text; //VERİ İÇERİSİNDEKİ BARKODA barkod textboxdan veri gönderiyoruz
                veri.KitapAdi = txt_kitapadi.Text;
                veri.BaskiYeri = txt_baskiyeri.Text;
                veri.BaskiTarihi = dt_baskitarihi.Text;
                veri.BaskiSayisi = txt_baskisayisi.Text;
                veri.KitapTuru = txt_kitapturu.Text;
                veri.SayfaSayisi = txt_sayfasayisi.Text;
                veri.Konusu = txt_konusu.Text;
                veri.Dili = txt_dili.Text;
                veri.TeminTuru = txt_teminturu.Text;
                veri.TeminTarihi = dt_temin.Text;
                veri.YayinEviID = 1;
                veri.YazarAdiID = 1;
                if (resimSecildimi==1)
                {//resim seçilme işlevi yapıldıysa
                    veri.Resim = Prm.ResimAdi; //database kaydederken o resmin yolunu kaydedecek bu sayede
                }
                else //resim seçilmediyse default resim olacak çünkü null düşer
                {
                    veri.Resim = Environment.CurrentDirectory +"\\KitapResmi\\books.png";
                        //şuan içersinide bulunduğumuz programın kurulu olduğu alan 
                }
                if (DBislemci.EklemeIslemi(veri))
                {
                    Prm.Hata = 0;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Kayıt işlemi başarılı";  //label content yazıcaz 
                    bilgi.Show(); //göster bilgi ekranını 
                }
                else
                {
                    Prm.Hata = 1;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Zorunlu barkod, kitap türü , kitap adı \n alanlarını doldurunuz";  //label content yazıcaz 
                    bilgi.Show(); //göster bilgi ekranını 
                }
            }
            else
            {//boşsa eğer hatalı bilgi ekran açılacak 
                Prm.Hata = 1;
                BilgiEkrani bilgi = new BilgiEkrani();
                Prm.BilgiEkraniContent  = "Zorunlu barkod, kitap türü , kitap adı \n alanlarını doldurunuz";  //label content yazıcaz 
                bilgi.Show(); //göster bilgi ekranını 
            }
        }

        string SecilenResimAdi;
        private void btn_ResimEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //belgelerim içerisine klasör oluşturma varsa oluşturma durumu
                if (!Directory.Exists(Prm.BelgelerimYolu_MyDocuments +"\\LibraryAutomationApplication\\Resimler"))
                {//BÖYLE BİR KLASÖR YOK 
                    Directory.CreateDirectory(Prm.BelgelerimYolu_MyDocuments + "\\LibraryAutomationApplication\\Resimler");
                } //git bu klasörü oluştur  
                //open file ile resim seciyoruz
                OpenFileDialog dlg = new OpenFileDialog(); //openfiledialog constructor bu nesneyi oluşturuyor
                dlg.Title = "Resim Seç"; //AÇILAN PENCERENİN BAŞLIĞI 
                dlg.InitialDirectory = ""; //pencere açıldığında varsayılan olarak gelecek dizin
                dlg.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg"; //resimden başka hiçbirşey gelmesin diye filtreleme yapıyoruz                            
                dlg.FilterIndex = 1;

                if ((bool)dlg.ShowDialog()) //resmi biri seçmişse true dönmüşse işlem başarılıdır
                {
                    //openfiledialog ile seçilen resmi oluşturduğumuz klasör içerisine kopyalama işlevi
                    SecilenResimAdi = dlg.FileName; //RESİMADİ secilen dosyanın ismi atadık
                    DateTime zaman = DateTime.Now; //resmin yüklendiği Gün/Ay/Yıl Saat:dakika:saniye verir 
                    string format = "dd-MM-yyyy-_hh-mm--ss"; //gelen zamanı formatlıyoruz
                    Prm.ResimAdi = Prm.BelgelerimYolu_MyDocuments + "\\LibraryAutomationApplication\\Resimler\\" + Prm.BarkodNo +
                        zaman.ToString(format) +".jpg"; //bu şekilde olacak resim file name
                    
                    File.Copy(SecilenResimAdi, Prm.ResimAdi,true); //secilen resmimizi Parametrelerdeki resim adına kopyaladık resimler klasörüne koyduk
                    //belgelerin içerisindeki resmimizin yolunu Uri ye çevirip img_KitapResmi source verme
                    BitmapImage img = new BitmapImage(); //resim elemanı oluştur
                    img.BeginInit();  
                    img.UriSource = new Uri(@"" + Prm.ResimAdi);
                    img.EndInit();
                    img_KitapResmi.Source = img; //resim kaynağını ayarla 

                    //resim  ekleme başarılı olursa olacak olan 
                    Prm.Hata = 0;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Resim Ekleme İşlemi Başarılı";  //label content yazıcaz 
                    bilgi.Show(); //göster bilgi ekranını 

                    resimSecildimi = 1;
                }
                else
                {
                    Prm.Hata = 1;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Resim Ekleme İşlemi başarısız";  //label content yazıcaz 
                    bilgi.Show(); //göster bilgi ekranını 
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Hatalı Yükleme");
            }
        }
    }
}
