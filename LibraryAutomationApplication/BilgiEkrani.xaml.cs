using LibraryAutomationApplication.Classlar.Parametreler;
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
using System.Windows.Threading;

namespace LibraryAutomationApplication
{
    /// <summary>
    /// Interaction logic for BilgiEkrani.xaml
    /// </summary>
    public partial class BilgiEkrani : Window
    {
        public BilgiEkrani()
        {
            InitializeComponent();
        }

        private void btn_BilgiEkraniKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            Hata();
            

        }
        void Hata()
        {
            if (Prm.Hata == 0)
            {
                Olumlu_Bilgi.Visibility = Visibility.Visible; //olumlu bilgi ekranı gelsin
                Olumsuz_Bilgi.Visibility = Visibility.Hidden; //olumsuz bilgi ekranı kapansın
                img_Olumlu.Visibility = Visibility.Visible;
                img_Olumsuz.Visibility = Visibility.Hidden;
                BilgiEkrani_Content.Content = Prm.BilgiEkraniContent; //tabel textine wpf de content denir buna atama yapıcaz
                BilgiEkrani_Header.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF8ACEC2"));
                BilgiEkrani_Content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#27ae60"));

            }
            else
            {
                Olumlu_Bilgi.Visibility = Visibility.Hidden; //olumlu bilgi ekranı kapansın 
                Olumsuz_Bilgi.Visibility = Visibility.Visible; //olumsuz bilgi ekranı açılsın
                img_Olumlu.Visibility = Visibility.Hidden;
                img_Olumsuz.Visibility = Visibility.Visible;
                BilgiEkrani_Content.Content = Prm.BilgiEkraniContent; //tabel textine wpf de content denir buna atama yapıcaz
                BilgiEkrani_Header.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#e74c3c"));
                BilgiEkrani_Content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#e74c3c"));
            }
            ///  7 saniye sonra kapanan timer

            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(4)
                //4  saniye sonra kapansın interval zaman aralığiı
            }; //timer bir thread olduğu için süslü parantezin sonuna ; konur
            timer.Tick += delegate (object sender, EventArgs e)
            { //timer_Tick artıralan timer durdurup pencereyi kapatır
                ((DispatcherTimer)timer).Stop();
                if (this.ShowActivated) this.Close();

            };
            timer.Start();
        }

    }
}
