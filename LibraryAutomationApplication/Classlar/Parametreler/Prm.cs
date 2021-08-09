using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationApplication.Classlar.Parametreler
{
    public class Prm
    {
        #region Static Parametreler

        public static sbyte Hata; //static yeni bir nesne oluşturmadan ulaşmızı sağlar sbyte veri türü 0-1 

        public static string BilgiEkraniContent;

        public static string BelgelerimYolu_MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
        //Environment bilgisayarın ortam değişkenleri klasör dosyasından al 
        //belgelerim yolunu aldık
        public static string ResimAdi;
        public static string BarkodNo;


        #endregion



        #region veritabanına ekleme parametreleri 

        // _barkod, _kitapadı, 
        //alt _ private anlamındadır 
        private string barkod;
        private string kitapAdi;
        private string baskiYeri;
        private string baskiTarihi;
        private string baskiSayisi;
        private string kitapTuru;
        private string kitapKonusu;
        private string sayfaSayisi;
        private string dili;
        private string konusu;
        private string teminTuru;
        private string teminTarihi;
        private string resim;


        private int ekleyenID;
        private int yayinEviID;
        private int yazarAdiID;
        private bool emanetDurum;

        /// <summary>
        /// burada get kullanmamızın amacı get ile çağırlan classa işlediğimiz veriyi götürürüz set ile veriyi getiririz
        /// </summary>
        public string Barkod { get => barkod; set => barkod = value; }
        public string KitapAdi { get => kitapAdi; set => kitapAdi = value; }
    
        public string BaskiYeri { get => baskiYeri; set => baskiYeri = value; }
        public string BaskiTarihi { get => baskiTarihi; set => baskiTarihi = value; }
        public string BaskiSayisi { get => baskiSayisi; set => baskiSayisi = value; }
        public string KitapTuru { get => kitapTuru; set => kitapTuru = CultureInfo.CurrentCulture.TextInfo.ToUpper(value); }
        public string SayfaSayisi { get => sayfaSayisi; set => sayfaSayisi = value; }
        public string Dili { get => dili; set => dili = value; }
        public string Konusu { get => konusu; set => konusu = value; }
        public string TeminTuru { get => teminTuru; set => teminTuru = CultureInfo.CurrentCulture.TextInfo.ToUpper(value); }
        public string TeminTarihi { get => teminTarihi; set => teminTarihi = value; }
        public string Resim { get => resim; set => resim = value; }
        public int EkleyenID { get => EkleyenID1; set => EkleyenID1 = value; }
       
        public bool EmanetDurum { get => emanetDurum; set => emanetDurum = value; }
        
        public string KitapKonusu { get => kitapKonusu; set => kitapKonusu = value; }
        public int EkleyenID1 { get => ekleyenID; set => ekleyenID = value; }
        public int YayinEviID { get => yayinEviID; set => yayinEviID = value; }
        public int YazarAdiID { get => yazarAdiID; set => yazarAdiID = value; }



        #endregion
    }
}
