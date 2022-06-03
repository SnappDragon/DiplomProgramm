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
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace Дипломная_работа
{
    /// <summary>
    /// Логика взаимодействия для PasswordError.xaml
    /// </summary>
    public partial class PasswordError : Window
    {

        private users _currentUser = new users();

        public PasswordError()
        {
            InitializeComponent();
            DataContext = _currentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void BtnPasswordEdit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentUser.Email))
                errors.AppendLine("Введите email");

            if(errors.Length > 0)
            {
               MessageBox.Show(errors.ToString());
                return;
            }

            users editpassword = null;

            diplomEntities1 db = new diplomEntities1();

            editpassword = db.users.Where(a => a.Login == _currentUser.Login && a.Email == _currentUser.Email).FirstOrDefault();

            if (editpassword != null)
            {

                MailAddress fromAdress = new MailAddress("aksutichevdiplom@gmail.com", "Техническая поддержка by Alexandr Aksutichev");
                MailAddress toAdress = new MailAddress(EmailBox.Text, LoginBox.Text);
                MailMessage message = new MailMessage(fromAdress, toAdress);
                message.Body = "Ваш логин: '" + editpassword.Login + "'" + Environment.NewLine +
                    "Ваш пароль: '" + editpassword.Password + "'" + Environment.NewLine +
                    "Для того, чтоб поставить на учетную запись нужный Вам пароль, обратитесь к Системному Администратору" + Environment.NewLine +
                    "С Уважением Aksutichev Alexandr";
                message.Subject = "Данные пользователя";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromAdress.Address, "atefes123123");

                smtpClient.Send(message);

                MessageBox.Show("Ваши данные были высланы на почту.");

            }
            else
                if (editpassword == null)
            {
                MessageBox.Show("Введен не верный логин или email. Проверьте данные и повторите попытку позже.");
                return;
            }
        }
    }
}
