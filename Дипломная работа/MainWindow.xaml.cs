using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Дипломная_работа.View;

namespace Дипломная_работа
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private users _selectUser = new users();

        public static MainWindow Main;

        public users authVod;

        public MainWindow()
        {

            Main = this;
            InitializeComponent();
            DataContext = _selectUser;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void GoToRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterWindow reg1 = new RegisterWindow();
            reg1.ShowDialog();
        }

        public void Login_Click(object sender, RoutedEventArgs e)
        {

            var user = diplomEntities1.GetContext().users.Where(a => a.Login == LoginBox.Text && a.Password == PasswordBox.Text).FirstOrDefault();
            if (user.Role != null)
            {
                if (user.Role == "Администратор")
                {
                    this.Hide();
                    new AdminPanel().Show();
                }
                else
            if (user.Role == "Директор")
                {
                    this.Hide();
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.UserButton.Visibility = Visibility.Collapsed;
                    adminPanel.ShowDialog();
                }
                else
            if (user.Role == "Менеджер")
                {
                    this.Hide();
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.WorkerButton.Visibility = Visibility.Collapsed;
                    adminPanel.UserButton.Visibility = Visibility.Collapsed;
                    adminPanel.ShowDialog();
                }
                else
                if (user.Role == "Водитель")
                {
                    this.Hide();
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.WorkerButton.Visibility = Visibility.Collapsed;
                    adminPanel.UserButton.Visibility = Visibility.Collapsed;
                    adminPanel.ClientButton.Visibility = Visibility.Collapsed;
                    adminPanel.VoditelButton.Visibility = Visibility.Collapsed;
                    adminPanel.AutoButton.Visibility = Visibility.Collapsed;
                    adminPanel.ShowDialog();
                }
                else
                if (user.Role == "")
                {
                    this.Hide();
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.WorkerButton.Visibility = Visibility.Collapsed;
                    adminPanel.UserButton.Visibility = Visibility.Collapsed;
                    adminPanel.ClientButton.Visibility = Visibility.Collapsed;
                    adminPanel.VoditelButton.Visibility = Visibility.Collapsed;
                    adminPanel.AutoButton.Visibility = Visibility.Collapsed;
                    adminPanel.TransportButton.Visibility = Visibility.Collapsed;
                    adminPanel.OrderButton.Visibility = Visibility.Collapsed;
                    adminPanel.Show();

                }
            }
            else
                MessageBox.Show("Пользователь не найден. Проверьте правильность ввода логина и пароля.");
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            PasswordError vost = new PasswordError();
            vost.ShowDialog();

        }

    }
}
