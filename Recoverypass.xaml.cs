using Bank.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Recoverypass.xaml
    /// </summary>
    public partial class Recoverypass : Window
    {
        BankContext db = new BankContext();
        public Recoverypass()
        {
            InitializeComponent();
        }
        public static string? email { get; set; }
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
                bt_smena.IsEnabled = true;
            }
        }
        private void smena_parolya(object sender, RoutedEventArgs e)
        {
            var user = db.Users.FirstOrDefault(a => a.Mail == email);
            if (user != null)
            {
                user.Password = pass_tb.Password;
                db.SaveChanges();
                MessageBox.Show("Пароль успешно изменнен!");
                this.Close();
            }
        }
    }  
}
