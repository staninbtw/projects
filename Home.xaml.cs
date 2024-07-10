using Bank.Models;
using Microsoft.Identity.Client;
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
using System.Xml.Linq;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        BankContext db = new BankContext();
        List<int> ints= new List<int>() {3,6,12,24};
        public Home()
        {
            InitializeComponent();
            mesyac_list.ItemsSource = ints;
        }
        public static string? email { get; set; }
        public static string? password { get; set; }
        static int a;
        
        private void card_click(object sender, RoutedEventArgs e)
        {
                cardlist.Visibility = Visibility.Visible;
            view_poplnit.Visibility = Visibility.Collapsed;
            view_credit.Visibility = Visibility.Collapsed;
            perevodi_view.Visibility = Visibility.Collapsed;
        }

        private void popolnenie_click(object sender, RoutedEventArgs e)
        {
            view_poplnit.Visibility = Visibility.Visible;
            cardlist.Visibility = Visibility.Collapsed;
            view_credit.Visibility = Visibility.Collapsed;
            perevodi_view.Visibility = Visibility.Collapsed;
        }

        private void perevod_2(object sender, RoutedEventArgs e)
        {
            perevodi_view.Visibility = Visibility.Visible;
            view_poplnit.Visibility = Visibility.Collapsed;
            cardlist.Visibility = Visibility.Collapsed;
            view_credit.Visibility = Visibility.Collapsed;
            loadlist();
        }

        private void popolnit_click(object sender, RoutedEventArgs e)
        {
            var selectcard = db.Cards.FirstOrDefault(d => d.Number == number_card.Text.Trim() && d.Cardowner == a);
            if (selectcard != null)
            {
                int lll = Convert.ToInt32(sum_tb.Text);
                int sum = Convert.ToInt32(selectcard.Money + lll);
                selectcard.Money = sum;
                db.SaveChanges();
                MessageBox.Show("Успешно!");
                loadlist();
            }
            else
            {
                nocard.Text = "Такой карты не существует!!!";
                nocard.Background = Brushes.Red;
                nocard.Foreground = Brushes.White;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadlist();
        }

        private void snyat_click(object sender, RoutedEventArgs e)
        {
            var selectcard = db.Cards.FirstOrDefault(d => d.Number == number_card.Text.Trim() && d.Cardowner == a);
            if (selectcard != null)
            {
                int lll = Convert.ToInt32(sum_tb.Text);
                int sum = Convert.ToInt32(selectcard.Money - lll);
                if (sum >= 0)
                {
                    selectcard.Money = sum;
                    db.SaveChanges();
                    MessageBox.Show("Успешно!");
                    loadlist();
                }
                else
                {
                    MessageBox.Show("Недостаточно средств!!!");
                }
            }
            else
            {
                nocard.Text = "Неверный номер карты!!!";
                nocard.Background = Brushes.Red;
                nocard.Foreground = Brushes.White;
            }
        }

        private void sum_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void number_card_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void credit_click(object sender, RoutedEventArgs e)
        {
            cardlist.Visibility = Visibility.Collapsed;
            view_poplnit.Visibility = Visibility.Collapsed;
            view_credit.Visibility = Visibility.Visible;
            loadcredit();
        }
        void loadlist() 
        {
            var author = db.Users.Where(l => l.Mail == email && l.Password == password).FirstOrDefault();
            if (author != null)
            {
                for (int i = 0; i <= author.Id; i++)
                {
                    a = i;
                }
                var loadcard = db.Cards.Where(c => c.Cardowner == a).ToList();
                cardlist.ItemsSource = loadcard;
                cardlist2.ItemsSource = loadcard;
            }
        }

        private void srok_credita(object sender, TextChangedEventArgs e)
        {
            vichesleniya();
        }

        private void mesyac_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vichesleniya();
        }
        void vichesleniya ()
        {
            try
            {
                if (summa_credita.Text != null && mesyac_list.SelectedItem != null)
                {
                    var dsad = summa_credita.Text;
                    var sda = mesyac_list.SelectedItem.ToString();
                    sum_mesyac.Text = ($"Кредит {Convert.ToInt32(dsad) / Convert.ToInt32(sda)}₸ x {sda} мес").ToString();
                }
            }
            catch(Exception) 
            {
                MessageBox.Show("Заполните поле!");
            } 
        }

        private void summa_credita_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        void loadcredit()
        {
            var loadcredit = db.Checks.Where(c => c.UserId == a).ToList();
            credit_list.ItemsSource = loadcredit;
        }

        private void perevod_1(object sender, RoutedEventArgs e)
        {
            if(cardlist2.SelectedItem!= null)
            {

            }
        }

        private void tb_numcard_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void sum_tb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            new info21().Show();
        }
    }
}