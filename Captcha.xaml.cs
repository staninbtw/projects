using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
        }
        void RND()
        {
            int size = 6;
            string a = "";
            string buk = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                a += buk[rnd.Next(0, buk.Length)];
                rnd_text.Text = a;
            }
            tb_captcha.Clear();
        }

        private void Imchel_click(object sender, RoutedEventArgs e)
        {
            if ( tb_captcha.Text == rnd_text.Text)
            {
                this.Close();
            }
            else 
            {
                MessageBox.Show("Попробуйте еще раз");
                RND();
                
            }
        }

        private void Reverse_click(object sender, RoutedEventArgs e)
        {
            RND();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RND();
        }
    }
}
