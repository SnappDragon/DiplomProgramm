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
    /// Логика взаимодействия для AdUserPage.xaml
    /// </summary>
    public partial class AdUserPage : Page
    {
        private users _currentUser = new users();

        public AdUserPage(users selectedUser)
        {
            InitializeComponent();

            if(selectedUser != null)
                _currentUser = selectedUser;

            DataContext = _currentUser;
            ComboRole.ItemsSource = diplomEntities1.GetContext().role.ToList();
        }

        private void BtnSaveAdUsers_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Укажите логин");
            if(string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Укажите пароль");
            if (string.IsNullOrWhiteSpace(_currentUser.Role))
                errors.AppendLine("Выберите роль");
            if(string.IsNullOrWhiteSpace(_currentUser.Email))
                errors.AppendLine("Введите email");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentUser.Code == 0 )
                diplomEntities1.GetContext().users.Add(_currentUser);

            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Пользователь добавлен/изменен");
                Manager.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
