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
    /// Логика взаимодействия для AdWorkerPage.xaml
    /// </summary>
    public partial class AdWorkerPage : Page
    {

        private worker _currentWorker = new worker();

        public AdWorkerPage(worker selectedWorker)
        {
            InitializeComponent();

            if (selectedWorker != null)
                _currentWorker = selectedWorker;

            DataContext = _currentWorker;
        }

        private void BtnSaveEditWorker_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentWorker.FIO_worker))
                errors.AppendLine("Введите имя работника");
            if (string.IsNullOrWhiteSpace(_currentWorker.Position))
                errors.AppendLine("Укажите должность");
            if (string.IsNullOrWhiteSpace(_currentWorker.Number))
                errors.AppendLine("Введите номер телефона");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentWorker.Code_worker == 0)
                diplomEntities1.GetContext().worker.Add(_currentWorker);

            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Работник добавлен/изменен");
                Manager.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
