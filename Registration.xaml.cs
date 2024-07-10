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
using System.Xml.Schema;
using Bank.Models;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        BankContext db = new BankContext();
        public Registration()
        {
            InitializeComponent();
        }
        private void regist_bt(object sender, RoutedEventArgs e)
        {
            User newUser = new User() { Mail = tel_tb.Text.Trim(), Password = pass_tb.Password.Trim()};
            var user = db.Users.FirstOrDefault(a => a.Mail == tel_tb.Text);
            if (user == null && passconf_tb.Password == pass_tb.Password && tel_tb.Text != "" && pass_tb.Password != "" && passconf_tb.Password != "")
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрировались!!!");
                this.Close();
            }
            else if (user != null)
            {
                MessageBox.Show("Такой пользователь уже существует!");
            }
            else if (tel_tb.Text == "" || pass_tb.Password == "" || passconf_tb.Password == "")
            {
                zapolni_polya.Opacity = 100;
            }
        }
        private void passconf_tb_PasswordChanged(object sender, RoutedEventArgs e)
        {
        if (passconf_tb.Password != pass_tb.Password)
        {
            proverka_parolya.Text = "Пароли не совпадают";
            proverka_parolya.Background = Brushes.Peru;
        }
        else
        {
            proverka_parolya.Text = "Пароли совпадают";
            proverka_parolya.Background = Brushes.YellowGreen;
                bt_reg.IsEnabled= true;
            }
        }
        private void pass_tb_PasswordChanged(object sender, RoutedEventArgs e)
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

        private void tel_tb_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
