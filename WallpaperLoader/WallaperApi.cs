using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WallpaperLoader.Models;

namespace WallpaperLoader
{
  static  class WallaperApi
    {
        private const string apiUrl= "https://wall.alphacoders.com/api2.0/get.php?auth=dcc164e06ea94f0187af2a6dfdc8bef8&";
       
        private  static  string Request(string URL)
        {
            Console.WriteLine(URL);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            System.Net.WebRequest req = System.Net.WebRequest.Create(URL);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
        public static  WallpaperModel GetRandomWalls()
        {
            return  JsonConvert.DeserializeObject<WallpaperModel>(Request(apiUrl + "method=random&count=30")); 
        }
        public static WallpaperModel GetSeach(string term, int page,int width,int height)
        {
            return JsonConvert.DeserializeObject<WallpaperModel>(Request(apiUrl + "method=search&term="+term+"&page="+page+"&width="+width+ "&height="+ height));
        }


    }
}
