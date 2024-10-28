using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tech_Services.Implement;
using Tech_Services.Interface;

namespace TECH_STORE
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        private IProductService _productService;
        public ProductList()
        {
            InitializeComponent();
            _productService = new ProductService();
        }

        private void LoadProduct()
        {
            dtgProductList.ItemsSource = _productService.GetProducts();
        }

        private void pgProductList_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProduct();
        }
    }
}
