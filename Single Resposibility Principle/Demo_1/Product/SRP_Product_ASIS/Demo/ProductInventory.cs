using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace SRP_Producto.Demo
{
    public class ProductInventory
    {
        private string _logFilePath = "Log.txt";
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public byte[] ImageData { get; set; } 
        public ProductInventory()
        {
            

        }

        public void UploadImage(Image image)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar una imagen",
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Cargar y mostrar la imagen seleccionada
                Uri imageUri = new Uri(openFileDialog.FileName);
                image.Source = new System.Windows.Media.Imaging.BitmapImage(imageUri);
                if (image.Source is System.Windows.Media.Imaging.BitmapImage bitmapImage)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

                        encoder.Save(memoryStream);

                        ImageData = memoryStream.ToArray();
                    }
                }
            }
        }

        public void SaveProduct()
        {
           
            // Validar que ninguna de las propiedades esté vacía o nula
            if (string.IsNullOrEmpty(Name) || Price == 0 || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(Manufacturer) || string.IsNullOrEmpty(SerialNumber))
            {
                Log("Error al validar el producto");
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
           
            // Realizar la serialización XML
            XmlSerializer serializer = new XmlSerializer(typeof(ProductInventory));

            // Ruta del archivo XML donde se almacenarán los datos del producto
            string filePath = "product.xml";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, this);
            }
            MessageBox.Show("El producto se guardo correctamente!");
            Log("El producto se guardo");
        }

        public void Log(string message)
        {
            try
            {
                // Obtén la fecha y hora actual para el registro
                string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Formatea el mensaje de registro
                string logMessage = $"{timeStamp}: {message}";

                // Escribe el mensaje en el archivo de registro
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que pueda ocurrir al escribir en el archivo de registro.
                Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
            }
        }
    }
}
