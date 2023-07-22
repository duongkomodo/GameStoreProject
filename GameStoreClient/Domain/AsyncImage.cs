using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GameStoreClient.Domain
{
    public class AsyncImage:Image
    {
        public static readonly DependencyProperty ImagePathProperty =
        DependencyProperty.Register(
            nameof(Url), typeof(string), typeof(AsyncImage),
            new PropertyMetadata(async (o, e) =>
                await ((AsyncImage)o).LoadImageAsync((string)e.NewValue)));


        public string Url
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        private async Task LoadImageAsync(string url)
        {

            Source = await Task.Run(async () =>
            {

                using (WebClient client = new WebClient())
                {
                    byte[] bytes = await client.DownloadDataTaskAsync(url);
                   
                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = new MemoryStream(bytes);
                    bi.EndInit();
                    bi.Freeze();
                    return bi;
                };
          
                
            });

        }
    }
}
