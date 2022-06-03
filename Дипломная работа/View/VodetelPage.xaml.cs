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
    /// Логика взаимодействия для VodetelPage.xaml
    /// </summary>
    public partial class VodetelPage : Page
    {
        public VodetelPage()
        {
            InitializeComponent();
        }

        private void BtnEditVod_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdVoditelPage((sender as Button).DataContext as voditel));
        }

        private void BtnAdVod_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdVoditelPage(null));
        }

        private void BtnDeleteVod_Click(object sender, RoutedEventArgs e)
        {
            var vodForRemoving = DGridVod.SelectedItems.Cast<voditel>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {vodForRemoving.Count()} выбранных водителей?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    diplomEntities1.GetContext().voditel.RemoveRange(vodForRemoving);
                    diplomEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Водители удалены");

                    DGridVod.ItemsSource = diplomEntities1.GetContext().voditel.ToList();

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
                diplomEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                DGridVod.ItemsSource = diplomEntities1.GetContext().voditel.ToList();
            }
        }
    }
}
