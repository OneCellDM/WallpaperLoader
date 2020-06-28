using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
using WallpaperLoader.Models;

namespace WallpaperLoader
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        RandomWallaperPage RandomWallaperPage = new RandomWallaperPage();
        SearchWallaperPage SearchWallaperPage = new SearchWallaperPage();
        public MainWindow()
        {
            InitializeComponent();
            RandomImageTabItem.Content = RandomWallaperPage.Content;
            SearchTabItem.Content = SearchWallaperPage.Content;


        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

    }
}
