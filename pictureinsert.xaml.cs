using Bank.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для pictureinsert.xaml
    /// </summary>
    public partial class pictureinsert : Window
    {
        BankContext db =new BankContext();
        public pictureinsert()
        {
            InitializeComponent();
        }
        
        private void insert_image(object sender, RoutedEventArgs e)
        {
            FileStream fStream = new FileStream(tb_path.Text, FileMode.Open, FileAccess.Read);
            Byte[] imageBytes = new byte[fStream.Length];
            fStream.Read(imageBytes, 0, imageBytes.Length);
            var picture = db.Cards.First(a=>a.Name == tb_name.Text && a.Picture ==null);
            if (picture != null)
            {
                picture.Picture = imageBytes;
                db.SaveChanges();
            }
        }
    }
}
