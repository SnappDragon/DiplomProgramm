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
    /// Логика взаимодействия для AdClientPage.xaml
    /// </summary>
    public partial class AdClientPage : Page
    {

        private client _currentClient = new client();

        public AdClientPage(client selectedClient)
        {
            InitializeComponent();

            if(selectedClient != null)
                _currentClient = selectedClient;

            DataContext = _currentClient;

        }

        private void BtnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.FIO))
                errors.AppendLine("Введите ФИО");
            if (string.IsNullOrWhiteSpace(_currentClient.Number))
                errors.AppendLine("Укажите номер телефона");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClient.Code_client == 0)
                diplomEntities1.GetContext().client.Add(_currentClient);

            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Клиент добавлен/изменен");
                Manager.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
