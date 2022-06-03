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
    /// Логика взаимодействия для AutoparkPage.xaml
    /// </summary>
    public partial class AutoparkPage : Page
    {
        public AutoparkPage()
        {
            InitializeComponent();
        }

        private void BtnEditAuto_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdAutoPage((sender as Button).DataContext as autopark));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                diplomEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                DGridClients.ItemsSource = diplomEntities1.GetContext().autopark.ToList();
            }
        }

        private void BtnDeleteAuto_Click(object sender, RoutedEventArgs e)
        {
            var autoForRemoving = DGridClients.SelectedItems.Cast<autopark>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {autoForRemoving.Count()} выбранных автомобилей?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    diplomEntities1.GetContext().autopark.RemoveRange(autoForRemoving);
                    diplomEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Автомобили удалены");

                    DGridClients.ItemsSource = diplomEntities1.GetContext().autopark.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdAuto_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdAutoPage(null));
        }
    }
}
