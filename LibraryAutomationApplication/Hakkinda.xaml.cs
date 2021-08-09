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

namespace LibraryAutomationApplication
{
    /// <summary>
    /// Interaction logic for Hakkinda.xaml
    /// </summary>
    public partial class Hakkinda : Window
    {
        public Hakkinda()
        {
            InitializeComponent();
        }

        
        private void btn_HakkindaKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
