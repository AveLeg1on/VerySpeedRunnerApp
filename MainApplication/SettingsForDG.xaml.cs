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

namespace VerySpeedRunnerApp
{
    /// <summary>
    /// Логика взаимодействия для SettingsForDG.xaml
    /// </summary>
    public partial class SettingsForDG : Window
    {
        public SettingsForDG()
        {
            InitializeComponent();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            string txt = Rows.Text;
            if (!(int.TryParse(Rowsw.Text, out int rows)))
            {
                MessageBox.Show("Значение не соответствует разрешенным");
                Rows.Clear();
                return;
            }
            if (!(int.TryParse(Columns.Text, out int columns)))
            {
                MessageBox.Show("Значение не соответствует разрешенным");
                Columns.Clear();
                return;
            }
            if (!(int.TryParse(Range.Text, out int range)))
            {
                MessageBox.Show("Значение не соответствует разрешенным");
                Range.Clear();
                return;
            }
            else
            {
                using (StreamWriter wr = new StreamWriter("config.ini"))
                {
                    wr.WriteLine(rows);
                    wr.WriteLine(columns);
                    wr.WriteLine(range);
                    Close();
                }
            }
        }

        private void EX_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
    
