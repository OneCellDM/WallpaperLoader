using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WallpaperLoader.Models;

namespace WallpaperLoader
{
    /// <summary>
    /// Логика взаимодействия для RandomWallaperPage.xaml
    /// </summary>
    public partial class RandomWallaperPage : Window
    {
        IList<WallpaperModel.Wallpaper> Wallpapers;
        public RandomWallaperPage()
        {
            InitializeComponent();

            LoadImages();
        }
        public async void LoadImages()
        {
            
            
            Wallpapers = WallaperApi.GetRandomWalls().wallpapers;
            foreach (var z in Wallpapers)
            {

                Listv.Items.Add(z);
            }
        }

        private void SetToWallpaper_Click(object sender, RoutedEventArgs e)
        {

            if (Listv.SelectedIndex > -1)
            {
                var load = WinApi.Download(Wallpapers[Listv.SelectedIndex].url_image, Wallpapers[Listv.SelectedIndex].id + "." + Wallpapers[Listv.SelectedIndex].file_type);
                var await = load.GetAwaiter();
                await.OnCompleted(() =>
                {
                    WinApi.SetWallPaper(await.GetResult(), 10, 3);
                });
            }
            
        }

            

        private void update_Click(object sender, RoutedEventArgs e)
        {
            Listv.Items.Clear();
            GC.Collect();
            LoadImages();
        }

        private void DownloadImage_Click(object sender, RoutedEventArgs e)
        {
            if (Listv.SelectedItems.Count>0)
            {
                
                FolderBrowserDialog FBD = new FolderBrowserDialog() { Description = "Выберите папку загрузки изображений" };
                if (FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < Listv.SelectedItems.Count; i++)
                    {
                       int index= Listv.Items.IndexOf(Listv.SelectedItems[i]);
                        var load = WinApi.Download(Wallpapers[index].url_image, FBD.SelectedPath + "\\" + Wallpapers[index].id + "." + Wallpapers[index].file_type);
                        
                    }
                }
            }
        }

        private void PART_VerticalScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Listv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
