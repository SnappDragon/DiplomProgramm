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
    /// Логика взаимодействия для TransportPage.xaml
    /// </summary>
    public partial class TransportPage : Page
    {
        public TransportPage()
        {
            InitializeComponent();

            if (MainWindow.Main.authVod != null)
            {
                BtnTransportAd.Visibility = Visibility.Collapsed;
                BtnTransportDelete.Visibility = Visibility.Collapsed;
            }

        }

        private void BtnTransportDelete_Click(object sender, RoutedEventArgs e)
        {
            var transForRemoving = DGridTransport.SelectedItems.Cast<transport>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {transForRemoving.Count()} выбранных заказов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    diplomEntities1.GetContext().transport.RemoveRange(transForRemoving);
                    diplomEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Заказы удалены");

                    DGridTransport.ItemsSource = diplomEntities1.GetContext().transport.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnTransportAd_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdTransportPage(null));
        }

        private void BtnTranportEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdTransportPage((sender as Button).DataContext as transport));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                diplomEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                DGridTransport.ItemsSource = diplomEntities1.GetContext().transport.ToList();
            }
        }
    }
}
