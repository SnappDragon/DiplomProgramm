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
    /// Логика взаимодействия для AdOrderPage.xaml
    /// </summary>
    public partial class AdOrderPage : Page
    {

        private orders _currentOrder = new orders();

        public AdOrderPage(orders selectedOrder)
        {
            InitializeComponent();

            if(selectedOrder != null)
                _currentOrder = selectedOrder;
            DataContext = _currentOrder;

        }

        private void BtnSaveAdOrder_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentOrder.Code_client < 1)
                errors.AppendLine("Укажите код клиента");
            if (_currentOrder.Code_worker < 1)
                errors.AppendLine("Укажите код работника");
            if (string.IsNullOrWhiteSpace(_currentOrder.Type_gruz))
                errors.AppendLine("Введите тип груза");
            if (string.IsNullOrWhiteSpace(_currentOrder.Razmer_gruz))
                errors.AppendLine("Введите размер груза");
            if (string.IsNullOrWhiteSpace(_currentOrder.Ves_gruz))
                errors.AppendLine("Укажите вес груза");
            if (string.IsNullOrWhiteSpace(_currentOrder.Date_sdachi))
                errors.AppendLine("Введите дату сдачи");
            if (string.IsNullOrWhiteSpace(_currentOrder.City))
                errors.AppendLine("Введите город сдачи");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentOrder.Code_order == 0)
                diplomEntities1.GetContext().orders.Add(_currentOrder);

            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Заказ добавлен/изменен");
                Manager.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
