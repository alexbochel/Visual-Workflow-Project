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

namespace VisualWorkflowDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void fab_click(object sender, RoutedEventArgs e)
        {
            DataContext = new FabViewModel();
        }

        private void paint_click(object sender, RoutedEventArgs e)
        {
            DataContext = new PaintViewModel();
        }

        private void stores_click(object sender, RoutedEventArgs e)
        {
            DataContext = new StoresViewModel();
        }

        private void click_about(object sender, RoutedEventArgs e)
        {
            DataContext = new AboutView();
        }
    }
}
