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
    /// Логика взаимодействия для AdTransportPage.xaml
    /// </summary>
    public partial class AdTransportPage : Page
    {

        private transport _currentTrans = new transport();

        public AdTransportPage(transport selectedTrans)
        {
            InitializeComponent();

            if(selectedTrans != null)
                _currentTrans = selectedTrans;
            DataContext = _currentTrans;
        }

        private void BtnTransSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentTrans.Code_order < 1)
                errors.AppendLine("Введите код заказа");
            if (_currentTrans.Code_auto < 1)
                errors.AppendLine("Введите код автомобиля");
            if(_currentTrans.Code_voditel < 1)
                errors.AppendLine("Введите код водителя");
            if (string.IsNullOrWhiteSpace(_currentTrans.City))
                errors.AppendLine("Укажите город прибытия");
            if (string.IsNullOrWhiteSpace(_currentTrans.Date_otpr))
                errors.AppendLine("Укажите дату отправки");
            if (string.IsNullOrWhiteSpace(_currentTrans.Count))
                errors.AppendLine("Введите стоимость");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentTrans.Code_transport == 0)
                diplomEntities1.GetContext().transport.Add(_currentTrans);

            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Перевозка добавлена/изменена");
                Manager.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
