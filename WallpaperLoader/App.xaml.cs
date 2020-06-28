using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using WallpaperLoader.Properties;

namespace WallpaperLoader
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
		

		public App()
		{
			this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/white.xaml") };
		}
	}
}
