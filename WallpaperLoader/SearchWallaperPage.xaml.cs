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
    /// Логика взаимодействия для SearchWallaperPage.xaml
    /// </summary>
    public partial class SearchWallaperPage : Window
    {

        IList<WallpaperModel.Wallpaper> Wallpapers;
        int page = 1;
        public SearchWallaperPage()
        {
            InitializeComponent();
            NextPageButton.Visibility = Visibility.Collapsed;
            PrevPageButton.Visibility = Visibility.Collapsed;
            PageCounter.Visibility = Visibility.Collapsed;

        }
        private void search()
        {
            Listv.Items.Clear();
            GC.Collect();
            if (SearchDatatTextBox.Text.Trim().Length > 0)
            {
               
                try
                {
                    var SearchData = WallaperApi.GetSeach(term: SearchDatatTextBox.Text, page, int.Parse(widthTextbox.Text), int.Parse(HeightTextBox.Text));
                    if (SearchData.wallpapers != null)
                    {

                        PageCounter.Text = page.ToString();
                        foreach (var z in SearchData.wallpapers)
                                 Listv.Items.Add(z);
                            

                       var   tempTcheck = WallaperApi.GetSeach(term: SearchDatatTextBox.Text, page+1, int.Parse(widthTextbox.Text), int.Parse(HeightTextBox.Text));
                        PageCounter.Visibility = Visibility.Visible;

                        if (page==1)
                           PrevPageButton.Visibility = Visibility.Collapsed;

                        if(tempTcheck.wallpapers==null)                    
                            NextPageButton.Visibility = Visibility.Collapsed;

                        if (tempTcheck.wallpapers != null & page > 1)
                            PrevPageButton.Visibility = Visibility.Visible;

                        if (tempTcheck.wallpapers != null & page ==1)
                            NextPageButton.Visibility = Visibility.Visible;

                        if (tempTcheck.wallpapers == null & page == 1)
                           PageCounter.Visibility = Visibility.Collapsed;

                       




                    }
                    else
                    {
                        Console.WriteLine("null count");
                        if(page==1)
                        {
                            NextPageButton.Visibility = Visibility.Collapsed;
                            PrevPageButton.Visibility = Visibility.Collapsed;
                            PageCounter.Visibility = Visibility.Collapsed;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void SeacrhButton_Click(object sender, RoutedEventArgs e)
        {
            Listv.Items.Clear();
            page = 1;
           
            search();
           
          
        }
        private void SetToWallpaper_Click(object sender, RoutedEventArgs e)
        {

            if (Listv.SelectedIndex > -1)
            {
                var load = WinApi.Download(((WallpaperModel.Wallpaper)Listv.SelectedItem).url_image, ((WallpaperModel.Wallpaper)Listv.SelectedItem).id + "." + ((WallpaperModel.Wallpaper)Listv.SelectedItem).file_type);
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
            search();
            
        }

        private void DownloadImage_Click(object sender, RoutedEventArgs e)
        {
            if (Listv.SelectedItems.Count > 0)
            {

                FolderBrowserDialog FBD = new FolderBrowserDialog() { Description = "Выберите папку загрузки изображений" };
                if (FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < Listv.SelectedItems.Count; i++)
                    {
                        int index = Listv.Items.IndexOf(Listv.SelectedItems[i]);
                        var load = WinApi.Download(Wallpapers[index].url_image, FBD.SelectedPath + "\\" + Wallpapers[index].id + "." + Wallpapers[index].file_type);

                    }
                }
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            page ++;
            search();
            

        }

        private void PrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            page--;
            search();
        }
    }
}
