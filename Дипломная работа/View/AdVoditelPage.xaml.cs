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
    /// Логика взаимодействия для AdVoditelPage.xaml
    /// </summary>
    public partial class AdVoditelPage : Page
    {

        private voditel _currentVod = new voditel();

        public AdVoditelPage(voditel selectedVod)
        {
            InitializeComponent();

            if(selectedVod != null)
                _currentVod = selectedVod;

            DataContext = _currentVod;

        }

        private void BtnSaveVod_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentVod.FIO))
                errors.AppendLine("Введите ФИО");
            if (string.IsNullOrWhiteSpace(_currentVod.Category))
                errors.AppendLine("Укажите категорию прав");
            if (string.IsNullOrWhiteSpace(_currentVod.Number))
                errors.AppendLine("Введите номер телефона");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentVod.Code_voditel == 0)
                diplomEntities1.GetContext().voditel.Add(_currentVod);

            try
            {
                diplomEntities1.GetContext().SaveChanges();
                MessageBox.Show("Водитель добавлен/изменен");
                Manager.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
