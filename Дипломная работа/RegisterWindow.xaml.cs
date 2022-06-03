using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Windows.Shapes;
using Ubiety.Dns.Core;

namespace Дипломная_работа
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {

        private users _currentUser = new users();

        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = _currentUser;

            

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Введите пароль");
            if (string.IsNullOrWhiteSpace(_currentUser.Email))
                errors.AppendLine("Введите email");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.Code == 0)
                diplomEntities1.GetContext().users.Add(_currentUser);


            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Пользователь зарегистрирован");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            MainWindow lgform = new MainWindow();
            lgform.ShowDialog();

        }

        
    }
}
