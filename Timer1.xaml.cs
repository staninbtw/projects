using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Timer1.xaml
    /// </summary>
    public partial class Timer1 : Window
    {
        private int time = 11;
        private DispatcherTimer Timer;
        public Timer1()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                tb_timer.Text = string.Format("{0}:{1}", time / 60, time % 60);

            }
            else
            {
                Timer.Stop();
                this.Close();
            }
        }
        static int count = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            count++;
            if (count > 1)
            {
                for (int i = 0; i < count-1; i++)
                {
                    time += 10;
                }              
            }
            Fail_tb.Text = ($"Интерфейс заблокирован!!! Подождите:{time-1} сек");
        }
    }
}
