using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WallpaperLoader.Models
{
    class WallpaperModel
    {

        public class Wallpaper
        {
            public string id { get; set; }
            public string width { get; set; }
            public string height { get; set; }
            public string file_type { get; set; }
            public string file_size { get; set; }
            public string url_image { get; set; }
            public string url_thumb { get; set; }
            public string url_page { get; set; }
        }

        
            public bool success { get; set; }
            public IList<Wallpaper> wallpapers { get; set; }
            public string total_match { get; set; }

    }

    

  
}

