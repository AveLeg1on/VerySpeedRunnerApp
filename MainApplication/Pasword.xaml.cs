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

namespace VerySpeedRunnerApp
{
    /// <summary>
    /// Логика взаимодействия для Pasword.xaml
    /// </summary>
    public partial class Pasword : Window
    {
        public Pasword()
        {
            InitializeComponent();
        }

        private void Win_Strat(object sender, EventArgs e)
        {
            PB.Focus();        
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            if (PB.Password == "123")
            {
                Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
                PB.Clear();
                PB.Focus();
            }
           


        }

        private void GoTOExit(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
            
        }
    }
}
