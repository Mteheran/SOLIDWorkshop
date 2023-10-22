using SRP_Productos_ToBe.Business;
using SRP_Productos_ToBe.Entities;
using SRP_Productos_ToBe.Utilities;
using System;
using System.Diagnostics;
using System.Windows;

namespace SRP_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductFacadeManager productFacadeManager;

        Product product;
        public MainWindow()
        {
            InitializeComponent();
            productFacadeManager = new ProductFacadeManager();
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveForm();
        }

        private void SaveForm()
        {
            if(ValidForm() && productFacadeManager.AddProduct(product))
            {
                MessageBox.Show("Datos Guardados Correctamente");
                CleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al guardar producto");
            }
        }

        public bool ValidForm()
        {
            if (ProductFormValidator.InvalidPrice(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("El precio es incorrecto");
                return false;
            }

            LoadProductFormData(price);

            if (ProductFormValidator.InvalidProductData(product))
            {
                MessageBox.Show("Los datos del producto no son correctos");
                return false;
            }
            return true;
        }
        private void LoadProductFormData(decimal price = 0)
        {
            if (product is null)
            {
                product = new Product();
                product.Id = Guid.NewGuid();
            }
            product.Name = txtProductName.Text;
            product.Description = txtDescription.Text;
            product.Manufacturer = txtManufacturer.Text;
            product.Price = price;
            product.SerialNumber = txtSerialNumber.Text;
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            LoadProductFormData(product == null ? 0 : product.Price);
            product.ImageData = ImageFileHelper.GetImageBytes(imgProductImage);
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
