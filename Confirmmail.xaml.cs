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
using System.Net.Mail;
using System.Net;
using Bank.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Confirmmail.xaml
    /// </summary>
    public partial class Confirmmail : Window
    {
        BankContext db = new BankContext();
        public Confirmmail()
        {
            InitializeComponent();
        }
        static string a = "";
        private void send_click(object sender, RoutedEventArgs e)
        {
            int size = 6;
            string buk = "0123456789";
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                a += buk[rnd.Next(0, buk.Length)];

            }         
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("tangry363@gmail.com", "ggcsxjxdmqowayhe");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("tangry363@gmail.com");
            var user = db.Users.FirstOrDefault(a => a.Mail.Trim() == mail_tb.Text);
            if (user != null)
            {
                mail_tb.IsEnabled = false;
                send_btn.IsEnabled = false;
                lb_kod.IsEnabled = true;
                conf_tb.IsEnabled = true;
                conf_btn.IsEnabled = true;
                mail.To.Add(new MailAddress(mail_tb.Text));
                mail.Subject = "Код поддтверждения";
                mail.IsBodyHtml = true;
                mail.Body = $"<b style = 'color:red;'>{a}</b>";
                client.Send(mail);
                MessageBox.Show("Смс с кодом отправлено на ваш e-mail, если у вас его нет проверьте папку спам.");
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }


        }

        private void confirm_mail(object sender, RoutedEventArgs e)
        {
            if (conf_tb.Text == a)
            {
              Recoverypass.email =Convert.ToString(mail_tb.Text);
                new Recoverypass().Show();
                a = "";
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный код!");
            }
        }
        private void conf_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mail_tb.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource = new BitmapImage(new Uri(@"D:\Важное\Учеба\ПО-32\Практика ООП\Bank\Bank\image\email.ico", UriKind.Relative));
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.Uniform;
                mail_tb.Background = textImageBrush;
            }
            else
            {

                mail_tb.Background = null;
            }
        }

    }
}
