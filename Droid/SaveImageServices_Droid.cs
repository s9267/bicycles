using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Java.IO;
using Android.OS;
using Android.Provider;
using Android.Net;
using bicycles.Droid;
using bicycles.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SaveImageServicesImplementation))]
namespace bicycles.Droid
{
    public class SaveImageServicesImplementation : ISaveImageServices
    {
        public SaveImageServicesImplementation()
        {
        }

        public void Save(string filename, byte[] image)
        {
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            //adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name
            string name = System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath, image);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Uri.FromFile(new File(filePath)));
                var context = MainActivity.Instance;
                context.SendBroadcast(mediaScanIntent);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
        }
    }
}
