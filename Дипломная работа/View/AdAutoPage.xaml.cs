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
    /// Логика взаимодействия для AdAutoPage.xaml
    /// </summary>
    public partial class AdAutoPage : Page
    {

        private autopark _currentAuto = new autopark();

        public AdAutoPage(autopark selectedAuto)
        {
            InitializeComponent();

            if(selectedAuto != null)
                _currentAuto = selectedAuto;

            DataContext = _currentAuto;

        }

        private void BtnSaveAuto_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAuto.Number_car))
                errors.AppendLine("Ввежите госномер автомобиля");
            if (string.IsNullOrWhiteSpace(_currentAuto.Mark))
                errors.AppendLine("Введите марку автомобиля");
            if (string.IsNullOrWhiteSpace(_currentAuto.Gruz))
                errors.AppendLine("Укажите грузоподъемность автомобиля");
            if (string.IsNullOrWhiteSpace(_currentAuto.Massa))
                errors.AppendLine("Укажите массу автомобиля");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentAuto.Code_auto == 0)
                diplomEntities1.GetContext().autopark.Add(_currentAuto);

            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Авто удалено/добавлено");
                Manager.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
