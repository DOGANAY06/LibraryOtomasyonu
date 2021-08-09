using LibraryAutomationApplication.Classlar;
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

namespace LibraryAutomationApplication.UKontroller
{
    /// <summary>
    /// Interaction logic for ucKitapListesi.xaml
    /// </summary>
    public partial class ucKitapListesi : UserControl
    {
        public ucKitapListesi()
        {
            InitializeComponent();
        }
        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        //bu pencereden başka bir pencerenin elemanına erişmek için
        private void btn_KitapEkle_Click(object sender, RoutedEventArgs e)
        {//kitap ekleme penceresini cağırmalıyız
            winKitapEkle ekle = new winKitapEkle();
            ekle.Owner = gk; //eklenin sahibi gk
            gk.Opacity = 0.3; //gk saydam olsun
            ekle.ShowDialog(); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//kitapekle penceresi yüklendiğinde 
            DBislemci.GridDoldur(dtg_KitapListele);
        }
        //bu verileri çekicez
        string barkodNo;
        string kitapTuru, kitapYazari;

        private void dtg_KitapListele_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            barkodNo = ((TextBlock)dtg_KitapListele.Columns[0].GetCellContent(dtg_KitapListele.SelectedItem)).Text;
            //gridde seçilmiş barkodNo yu alıp bardkodNo verisine atıyoruz 
            kitapTuru = ((TextBlock)dtg_KitapListele.Columns[2].GetCellContent(dtg_KitapListele.SelectedItem)).Text;
            kitapYazari = ((TextBlock)dtg_KitapListele.Columns[3].GetCellContent(dtg_KitapListele.SelectedItem)).Text;


            MessageBox.Show(barkodNo + " - "+kitapTuru + " - " +kitapYazari);
        }
    }
}
