using LibraryAutomationApplication.Classlar.Parametreler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryAutomationApplication.Classlar
{
    public class DBislemci
    {
        
        //datagridi doldurma methodumuz 
        public static bool GridDoldur(DataGrid grd )
        {
            sbyte i = 0; //sbyte i ile veri akışı var mı yok mu bunu öğrenmiş olacağız 
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\Dogan\source\repos\LibraryAutomationApplication\LibraryAutomationApplication\bin\Debug\DB\kitap.db");
            SQLiteCommand com = new SQLiteCommand("Select  tbl_Yazarlar.AdiSoyadi,  tbl_KitapListesi.Barkod,  tbl_KitapListesi.ID,  tbl_KitapListesi.KitapTuru,  tbl_KitapListesi.KitapKonusu,  tbl_KitapListesi.BaskiYeri,  tbl_KitapListesi.BaskiSayisi,  tbl_KitapListesi.BaskiTarihi,  tbl_KitapListesi.TeminTuru,  tbl_KitapListesi.TeminTarihi,  tbl_KitapListesi.SayfaSayisi,  tbl_KitapListesi.Resim,  tbl_KitapListesi.KitapAdi,  tbl_KitapListesi.EmanetDurumu,  tbl_Uyeler.AdSoyad,  tbl_Uyeler.ID As ID1 From  tbl_KitapListesi Inner Join  tbl_YayinEvleri    On tbl_YayinEvleri.ID = tbl_KitapListesi.YayinEviID Inner Join  tbl_Yazarlar    On tbl_Yazarlar.ID = tbl_KitapListesi.YazarAdiID Inner Join  tbl_Uyeler ", con);
            // query yaptığım kısmı select yaptım   ve verileri getirdim
            try
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable(); //datatable nesnesi oluşturduk 
                adp.Fill(dt);
                grd.ItemsSource = null; //boşalttık 
                grd.ItemsSource = dt.DefaultView;


            }
            catch (Exception e) 
            {//hata oluşursa burası dönecek 
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0)
            {
                return true;
            }
            else return false;
        }

        //veritabanına ekleme işlemi için method yazıcaz  //insert işlemi yapıcaz

        public static bool EklemeIslemi(Prm veri) //VERİ EKLEME METHODU bool veri türü çünkü başarılı ya da başarısız seçeneği var
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\Dogan\source\repos\LibraryAutomationApplication\LibraryAutomationApplication\bin\Debug\DB\kitap.db");
            SQLiteCommand com = new SQLiteCommand("Insert into tbl_KitapListesi " +
                "(Barkod,KitapAdi,Kitapturu,KitapKonusu,BaskiYeri,BaskiSayisi,BaskiTarihi,TeminTuru,TeminTarihi,SayfaSayisi,Resim,EkleyenID,YayinEviID,YazarAdiID)" +
                "values (@Barkod,@KitapAdi,@Kitapturu,@KitapKonusu,@BaskiYeri,@BaskiSayisi,@BaskiTarihi,@TeminTuru,@TeminTarihi,@SayfaSayisi,@Resim,@EkleyenID,@YayinEviID,@YazarAdiID)",con);

            com.Parameters.AddWithValue("@Barkod", veri.Barkod); //parametre ve atanacak değeri veriyoruz
            com.Parameters.AddWithValue("@KitapAdi", veri.KitapAdi);
            com.Parameters.AddWithValue("@Kitapturu", veri.KitapTuru);
            com.Parameters.AddWithValue("@KitapKonusu", veri.KitapKonusu);
            com.Parameters.AddWithValue("@BaskiYeri", veri.BaskiYeri);
            com.Parameters.AddWithValue("@BaskiSayisi", veri.BaskiSayisi);
            com.Parameters.AddWithValue("@BaskiTarihi", veri.BaskiTarihi);
            com.Parameters.AddWithValue("@TeminTuru", veri.TeminTuru);
            com.Parameters.AddWithValue("@TeminTarihi", veri.TeminTarihi);
            com.Parameters.AddWithValue("@SayfaSayisi", veri.SayfaSayisi);
            com.Parameters.AddWithValue("@Resim", veri.Resim);
            com.Parameters.AddWithValue("@EkleyenID", veri.EkleyenID);
            com.Parameters.AddWithValue("@YayinEviID", veri.YayinEviID);
            com.Parameters.AddWithValue("@YazarAdiID", veri.YazarAdiID);

            try
            {
                con.Open();
                i = (sbyte)com.ExecuteNonQuery(); //ekleme işlevi başarılı olursa 1 başarısız olursa 0 değerini döndürür
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Dispose(); //her seferinde yapsın bağlantıyı sıfırlasın 
            }
            if (i > 0)
                return true;
            else return false;

        }

    }
}
