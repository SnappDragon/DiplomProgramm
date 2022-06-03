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
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using Microsoft.Windows.Themes;
using System.Drawing;



namespace Дипломная_работа.View
{
    /// <summary>
    /// Логика взаимодействия для Osnova.xaml
    /// </summary>
    public partial class Osnova : Window
    {

        //private Button currentButton;
        //private Random random;
        //private int tempIndex;
        //private Window activeForm;

        

        public Osnova()
        {
            InitializeComponent();
            Manager.AdminFrame = AdminFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PackIconMaterial_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            MainWindow loginform = new MainWindow();
            loginform.ShowDialog();
        }
    }
}
