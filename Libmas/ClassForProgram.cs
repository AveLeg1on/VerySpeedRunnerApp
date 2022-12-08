using System;
using System.Data;
using System.IO;

namespace Libmas
{
    public class ClassForProgram

    {
        /// <summary>
        ///Заполнение  одномерного массива случайными числами
        /// </summary>
        /// <param name="mas">Одномерный массив</param>
        /// <param name="value">Число пользователя</param>
        /// <returns>Заполненный одномерный массив</returns>
        public static int[] ZMass(int[] mas, int value)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(1, value);
            }
            return mas;
        }

        /// <summary>
        /// Сохраняет одномерный массив по указзаному пути
        /// </summary>
        /// <param name="mas">Одномернный массив</param>
        /// <param name="path">Путь к файлу</param>
        public static void SMass(string path, int[] mas)
        {
            using (StreamWriter wr = new StreamWriter(path))
            {
                wr.WriteLine(mas.Length);
                for (int i = 0; i < mas.Length; i++)
                {
                    wr.WriteLine(mas[i]);
                }

            }
        }
        /// <summary>
        /// для одномерного массива
        /// </summary>
        /// <param name="mas"> одномерный массив</param>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Заполенный массив с данными из файла</returns>
        public static int[] Openmas(string path, int[] mas)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                int.TryParse(sr.ReadLine(), out int lenght);
                mas = new int[lenght];
                for (int i = 0; i < mas.Length; i++)
                {
                    int.TryParse(sr.ReadLine(), out int value);
                    mas[i] = value;
                }
                return mas;
            }
        }
        /// <summary>
        ///Заполнение двумерного массива случайными числами
        /// </summary>
        /// <param name="mas">Двумерный массив</param>
        /// <param name="value">Число пользователя</param>
        /// <returns>Заполненный двумерный массив</returns>
        public static int[,] ZMass(int[,] mas, int value)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = rnd.Next(value);
                }
            }
            return mas;
        }
        /// <summary>
        /// Сохраняет двумерный массив по указзаному пути
        /// </summary>
        /// <param name="mas">Двумерный массив</param>
        /// <param name="path">Путь к файлу</param>
        public static void SMass(string path, int[,] mas)
        {
            using (StreamWriter wr = new StreamWriter(path))
            {
                wr.WriteLine(mas.GetLength(0));
                wr.WriteLine(mas.GetLength(1));

                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        wr.WriteLine(mas[i, j]);
                    }
                }
            }
        }
        /// <summary>
        /// для двумерного массива
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="mas">двумерный массив</param>
        /// <returns>Заполненный двумерный массив данными из файла</returns>
        public static int[,] Openmas(string path, int[,] mas)
        {
            using (StreamReader r = new StreamReader(path))
            {
                int.TryParse(r.ReadLine(), out int row);
                int.TryParse(r.ReadLine(), out int column);

                mas = new int[row, column];

                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        int.TryParse(r.ReadLine(), out int value);
                        mas[i, j] = value;
                    }
                }
                return mas;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="row"></param>
        ///  <param name="column"></param>
        /// <param name="diapazon"></param>
        /// <returns></returns>
        public static void SettingsValue(string path, out int row, out int column, out int diapazon)
        {
            using (StreamReader r = new StreamReader(path))
            {
                int.TryParse(r.ReadLine(), out  row);
                int.TryParse(r.ReadLine(), out  column);
                int.TryParse(r.ReadLine(), out diapazon);

               
            }
        }
    }
    //Класс для связывания массива с элементом DataGrid
    //для визуализации данных 
    public static class VisualArray
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i +1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        //Метод для двухмерного массива
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                res.Rows.Add(row);
            }
            return res;
        }
    }
}