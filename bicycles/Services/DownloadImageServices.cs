using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace bicycles.Services
{
    public class DownloadImageServices
    {
        private HttpClient httpClient;

        public DownloadImageServices()
        {
            httpClient = new HttpClient();
        }

        public async Task<byte[]> GetImage(string url)
        {
            Stream stream = await httpClient.GetStreamAsync(url);
            return GetImageStreamAsBytes(stream);
        }

        private byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}
