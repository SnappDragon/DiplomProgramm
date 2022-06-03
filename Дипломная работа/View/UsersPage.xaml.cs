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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {

        private users _currentUser = new users();

        public users delbtn;

        public UsersPage()
        {
            InitializeComponent();
            DataContext = _currentUser;            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdUserPage((sender as Button).DataContext as users));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGridUsers.SelectedItems.Cast<users>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить {usersForRemoving.Count()} выбранных пользователей?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
               {
                try
                {
                    diplomEntities1.GetContext().users.RemoveRange(usersForRemoving);
                    diplomEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Пользователи удалены");

                    DGridUsers.ItemsSource = diplomEntities1.GetContext().users.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            } 
        }

        private void BtnAd_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdUserPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                diplomEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridUsers.ItemsSource = diplomEntities1.GetContext().users.ToList();
            }    
        }

        private void BtnFilterUser_Click(object sender, RoutedEventArgs e)
        {
            if (TxtFilter.Text != "")
            {
                DGridUsers.ItemsSource = null;
                DGridUsers.ItemsSource = diplomEntities1.GetContext().users.Where(a => a.Login == TxtFilter.Text).ToList();
            }
            else
                if(TxtFilter.Text == "")
            {
                DGridUsers.ItemsSource= null;
                DGridUsers.ItemsSource = diplomEntities1.GetContext().users.ToList();
            }    
        }
    }
}
