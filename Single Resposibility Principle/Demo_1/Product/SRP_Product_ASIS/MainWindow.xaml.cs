using SRP_Producto.Demo;
using System.Windows;

namespace SRP_Producto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductInventory product;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (product is null)
            {
                product = new ProductInventory();
            }

            product.Name = txtProductName.Text;
            product.Description = txtDescription.Text;
            product.Manufacturer = txtManufacturer.Text;
            decimal price;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("El precio no es válido. Por favor, ingrese un valor numérico.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            product.Price = price;
            product.SerialNumber = txtSerialNumber.Text;
            product.SaveProduct();
            CleanForm();
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            if(product is null)
            {
                product = new ProductInventory();
            }
            product.UploadImage(imgProductImage);
        }

        private void CleanForm()
        {
            product = null;
            txtDescription.Text = null;
            txtManufacturer.Text = null;
            txtSerialNumber.Text = null;
            txtPrice.Text = null;
            txtProductName.Text = null;
            imgProductImage.Source = null;
        }
    }
}
