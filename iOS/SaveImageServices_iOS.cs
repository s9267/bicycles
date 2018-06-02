using System;
using bicycles.iOS;
using bicycles.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(SaveImageServicesImplementation))]
namespace bicycles.iOS
{
    
    public class SaveImageServicesImplementation : ISaveImageServices
    {
        public SaveImageServicesImplementation()
        {
        }

        public void Save(string filename, byte[] imageData)
        {
            var picture = new UIImage(NSData.FromArray(imageData));

            picture.SaveToPhotosAlbum((image, error) =>
            {
                //you can retrieve the saved UI Image as well if needed using
                //var i = image as UIImage;
                if (error != null)
                {
                    Console.WriteLine(error.ToString());
                }
            });
        }
    }
}
