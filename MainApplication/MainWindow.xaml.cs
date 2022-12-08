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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Libmas;
using Microsoft.Win32;

namespace VerySpeedRunnerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] mas = null;
        Pasword P = new Pasword();
         
        public MainWindow()
        {
           
            P.ShowDialog();
            
            InitializeComponent();
            ColANDRows.Focus();
            MessageBox.Show($"Вводить значения через {";"} "); 

          
        }
        int rows;
        int column;
        int dip;
        private void Fill_DG(object sender, RoutedEventArgs e)
        {

            try
            {            string str = ColANDRows.Text;
                var chil = str.IndexOf(';');
            var text = str.Substring(0,chil);
                str = str.Substring(chil + 1);
          
                int.TryParse(str, out rows);
                int.TryParse(text, out  column);
                mas = new int[rows, column];
               DG_Source.ItemsSource = VisualArray.ToDataTable(ClassForProgram.ZMass(mas, 10)).DefaultView;

            }
            catch
            {
                MessageBox.Show("Значения явно некоректные");
                return;
            }

           
        }

        private void DG_Source_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
           Spat.Content = $"Элемент с которым вы работаете: {e.Row.GetIndex()} x {e.Column.DisplayIndex}";
        }


        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Spat.Content = "";
            try
            {
                if (mas == null)
                {
                    return;
                }
                Distruct dis = new Distruct();

                DG_Answer.ItemsSource = VisualArray.ToDataTable(dis.EasyCalc(mas)).DefaultView;
            }
            catch(Exception)
            {

            }
        }

        private void Saver(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы |*.*| Текстовые файлы |*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                ClassForProgram.SMass(save.FileName, mas);
            }
        }

        private void Opener(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*)|*.*| Текстовые файлы |*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                mas = ClassForProgram.Openmas(open.FileName, mas);
                DG_Source.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
               
            }
        }

        private void Helper(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана матрица размера M *N.Для каждого столбца матрицы с четным номером(2, 4, …) найти сумму его элементов. Условный оператор не использовать.","Практическая 13", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        

        private void FWin_Loaded(object sender, RoutedEventArgs e)
        {
            P.Owner = this;

        }

        private void InputSet_Click(object sender, RoutedEventArgs e)
        {
            SettingsForDG settings = new SettingsForDG();
            settings.Owner = this;
            settings.ShowDialog();
        }

        private void GetSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.DefaultExt = "*.ini";
                open.Filter = "Все файлы (*.*)|*.*| Текстовые файлы |*.txt|  Файлы ini |*.ini";
                open.FilterIndex = 3;
                open.Title = "Открытие таблицы";
                if (open.ShowDialog() == true)
                {


                    ClassForProgram.SettingsValue(open.FileName, out rows, out column, out dip);
                    mas = new int[rows, column];
                    DG_Source.ItemsSource = VisualArray.ToDataTable(ClassForProgram.ZMass(mas, dip)).DefaultView;
                }
                else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
                Close();
            }
          
            }
            catch
            {

            }

            
          

        }
    }
}
