using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryAutomationApplication.Classlar
{
    public class uc_cagir //usercontroller çağırmak için method yazıcağız
    {
        public static void Uc_ek(Grid grd, UserControl uc) //girid ve user kontrolü çağıracağız static değişmeyen olarak
        {//hangi bölümdeki butona tıklandığında ona göre getirecek 
            if (grd.Children.Count>0)
            {//seçilen button her hangi bir bölümse önce temizle 
                grd.Children.Clear(); //temizle diğerlerini
                grd.Children.Add(uc); //benim çağırdığım usercontrol ekle
            }
            //hiçbiri tanımlı değilse ilk çıkarak content yani varsayılan buttona tıklanmış hali açık olacak bu durum else
            else
            {
                grd.Children.Add(uc);
            }

        }
    }
}
