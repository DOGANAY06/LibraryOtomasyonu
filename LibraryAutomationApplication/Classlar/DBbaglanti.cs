using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationApplication.Classlar
{
    public class DBbaglanti
    {//veritabanı bağlantısı yapmak için kullanılan class
        
        
        public static string DBadres = @"Data Source =" + Environment.CurrentDirectory + "/kitap.db";
        //database connection sağlamak için iç dizine geçip buradan kitap.db seçtik
        public static string BagDurum;
        public static void BagTest()
        {
            //using SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Dogan\source\repos\LibraryAutomationApplication\LibraryAutomationApplication\bin\Debug\DB\kitap.db"); 
            //database bağlantısını yapıyoruz 
            using (SQLiteConnection conn = new SQLiteConnection(DBadres))
            if (conn.State == ConnectionState.Closed) //bağlantı durumu bağlı değilse kapalıdır 
            {
                try
                {
                    conn.Open(); //KAPALI AÇMAYI DENE 
                    BagDurum = "DB bağlanıldı ";
                }
                catch (Exception)
                {
                    BagDurum = "Bağlantı connection yok";
                }

            }
            else
            {
                BagDurum = "DB bağlanıldı";
            }
        }

    }
    }
