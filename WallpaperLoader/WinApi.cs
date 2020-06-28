using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WallpaperLoader
{
   static  class WinApi
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static async void SetWallPaper(string WallpaperLocation, int WallpaperStyle, int TileWallpaper)
        {

            Console.WriteLine(WallpaperLocation);
            SystemParametersInfo(20, 0, WallpaperLocation, 0x01 | 0x02);
            RegistryKey rkWallPaper = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
            rkWallPaper.SetValue("WallpaperStyle", WallpaperStyle); 
            rkWallPaper.Close();
        }
        public  static async Task<string> Download(string url, string name)
        {
            return await Task.Run(() =>
              {
                  try
                  {
                      System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                      System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)req.GetResponse();
                      Stream stream = resp.GetResponseStream();
                      File.Create(name).Close();
                      byte[] b = null;
                      using (MemoryStream ms = new MemoryStream())
                      {
                          int count = 0;
                          do
                          {
                              byte[] buf = new byte[1024];
                              count = stream.Read(buf, 0, 1024);
                              ms.Write(buf, 0, count);
                          } while (stream.CanRead && count > 0);
                          b = ms.ToArray();
                      }
                      File.WriteAllBytes(name, b);
                      
                  }
                  catch(Exception EX)
                  {
                      MessageBox.Show(EX.Message);
                  }
                  return Path.GetFullPath(name);
              });


        }

    }
}
