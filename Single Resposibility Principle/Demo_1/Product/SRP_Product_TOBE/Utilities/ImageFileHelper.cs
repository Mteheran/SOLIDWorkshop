using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace SRP_Productos_ToBe.Utilities
{
    public  static class ImageFileHelper
    {
        public static byte[] GetImageBytes(System.Windows.Controls.Image image)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar una imagen",
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Uri imageUri = new Uri(openFileDialog.FileName);
                return LoadImage(image, imageUri);
                
            }
            return null;
        }

        private static byte[] LoadImage(System.Windows.Controls.Image image, Uri imageUri)
        {
            image.Source = new System.Windows.Media.Imaging.BitmapImage(imageUri);
            if (image.Source is System.Windows.Media.Imaging.BitmapImage bitmapImage)
            {
                return SaveImageBytes(bitmapImage);
            }
            return null;
        }
        private static byte[] SaveImageBytes(BitmapImage bitmapImage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

                encoder.Save(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}
