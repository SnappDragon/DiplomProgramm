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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {

        private client _currentClient = new client();

        public ClientPage()
        {
            InitializeComponent();
            DataContext = _currentClient;
        }

        private void BtnAdClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdClientPage(null));
        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var clientsForRemoving = DGridClients.SelectedItems.Cast<client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {clientsForRemoving.Count()} выбранных клиентов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    diplomEntities1.GetContext().client.RemoveRange(clientsForRemoving);
                    diplomEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Клиенты удалены");

                    DGridClients.ItemsSource = diplomEntities1.GetContext().client.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdClientPage((sender as Button).DataContext as client));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                diplomEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                DGridClients.ItemsSource = diplomEntities1.GetContext().client.ToList();
            }
        }
    }
}
