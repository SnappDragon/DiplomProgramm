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

namespace Дипломная_работа.View
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {

        private orders _currentOrder = new orders();

        public OrderPage()
        {

            InitializeComponent();

            if (MainWindow.Main.authVod != null)
            {
                BtnOrderAd.Visibility = Visibility.Collapsed;
                BtnOrderDelete.Visibility = Visibility.Collapsed;
            }

            DataContext = _currentOrder;

        }

        private void BtnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdOrderPage((sender as Button).DataContext as orders));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                diplomEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                DGridOrders.ItemsSource = diplomEntities1.GetContext().orders.ToList();

            }
        }

        private void BtnOrderDelete_Click(object sender, RoutedEventArgs e)
        {
            var ordersForRemoving = DGridOrders.SelectedItems.Cast<orders>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {ordersForRemoving.Count()} выбранных заказов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    diplomEntities1.GetContext().orders.RemoveRange(ordersForRemoving);
                    diplomEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Заказы удалены");

                    DGridOrders.ItemsSource = diplomEntities1.GetContext().orders.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void BtnOrderAd_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdOrderPage(null));
        }
    }
}
