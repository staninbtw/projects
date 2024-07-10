using Bank.Models;
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
using System.Windows.Threading;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankContext db = new BankContext();
        public MainWindow()
        {
            InitializeComponent();
                    
        }
        private void hide_click(object sender, RoutedEventArgs e)
        {
            new Registration().ShowDialog();
        }
        static int count = 0;
        private void login_click(object sender, RoutedEventArgs e)
        {
            count ++;
            var user = db.Users.FirstOrDefault(a => a.Mail.Trim() == tel_tb.Text && a.Password.Trim() == pass_tb.Password);
            if (user != null)
            {
                MessageBox.Show("Вы успешно авторизовались!!!");
                Home.email = Convert.ToString(tel_tb.Text);
                Home.password = Convert.ToString(pass_tb.Password);
                count = 0;
                new Home().ShowDialog();
            }   
            else
            {  
                MessageBox.Show("Неверный логин или пароль!");
            }
            if (count == 3) 
            {
                new Captcha().ShowDialog();
            }
            if(count >= 4) 
            {
                new Timer1().ShowDialog();
            }
        }

        private void conf_click(object sender, RoutedEventArgs e)
        {
            new Confirmmail().ShowDialog();
        }

        private void tb_email_changed(object sender, TextChangedEventArgs e)
        {
            if (tel_tb.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource = new BitmapImage(new Uri(@"D:\Важное\Учеба\ПО-32\Практика ООП\Bank\Bank\image\email.ico", UriKind.Relative));
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.Uniform;
                tel_tb.Background = textImageBrush;
            }
            else
            {

                tel_tb.Background = null;
            }
        }

        private void pass_pb_changed(object sender, RoutedEventArgs e)
        {
            if (pass_tb.Password == "")
            {
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource = new BitmapImage(new Uri(@"D:\Важное\Учеба\ПО-32\Практика ООП\Bank\Bank\image\password.ico", UriKind.Relative));
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.Uniform;
                pass_tb.Background = textImageBrush;
            }
            else
            {

                pass_tb.Background = null;
            }
        }
    }
}
