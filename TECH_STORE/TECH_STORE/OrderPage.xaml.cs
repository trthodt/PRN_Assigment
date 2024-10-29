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
using Tech_BussinessObjects;
using Tech_Services.Implement;
using Tech_Services.Interface;

namespace TECH_STORE
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {

        private IOrderService _orderService;
        private int page = 1;
        private int pageSize = 5;
        private Order chosenOrder = null;
        public OrderPage()
        {
            InitializeComponent();
            _orderService = new OrderService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrder();
        }

        private void LoadOrder()
        {
            dtgOrder.ItemsSource = _orderService.GetOrdersPagination(page, pageSize);
            lblPage.Content = page;
        }

        private void dtgOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                chosenOrder = (Order)dtgOrder.SelectedItem;
                if (chosenOrder != null)
                {
                    dtgOrderDetail.ItemsSource = chosenOrder.OrderDetails;
                }
            } catch { } 
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (page == 1) { return; }
            page--;
            LoadOrder();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int total = _orderService.Count();
            decimal totalPage =  Math.Ceiling( (decimal) total / pageSize);
            if (page + 1 > totalPage) { return; }
            page++;
            LoadOrder();
        }
    }
}
