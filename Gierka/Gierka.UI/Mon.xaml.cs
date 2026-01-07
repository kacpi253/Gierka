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

namespace Gierka.UI
{
    /// <summary>
    /// Logika interakcji dla klasy Mon.xaml
    /// </summary>
    public partial class Mon : UserControl
    {
        public Mon()
        {
            InitializeComponent();
        }
        private void Powrot(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {



                mainWindow.NavigateTo(new Gra());

            }
        }
        
    }
}
