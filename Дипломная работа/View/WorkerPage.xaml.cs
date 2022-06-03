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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {

        private worker _currentWorker = new worker();

        public WorkerPage()
        {
            InitializeComponent();
            DataContext = _currentWorker;
        }

        private void BtnWorkerEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdWorkerPage((sender as Button).DataContext as worker));
        }

        private void BtnWorkerAd_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdWorkerPage(null));
        }

        private void BtnWorkerDelete_Click(object sender, RoutedEventArgs e)
        {
            var workerForRemoving = DGridWorkers.SelectedItems.Cast<worker>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {workerForRemoving.Count()} выбранных работников?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    diplomEntities1.GetContext().worker.RemoveRange(workerForRemoving);
                    diplomEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Работники удалены");

                    DGridWorkers.ItemsSource = diplomEntities1.GetContext().worker.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                diplomEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridWorkers.ItemsSource = diplomEntities1.GetContext().worker.ToList();
            }
        }
    }
}
