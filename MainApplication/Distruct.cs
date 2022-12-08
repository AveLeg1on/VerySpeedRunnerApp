using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerySpeedRunnerApp
{
    struct Distruct
    {/// <summary>
     /// Считает сумму элементов четных столбцов
     /// </summary>
     /// <param name="mas">Массив с сгенирированными значениями</param>
     /// <returns name="array">однострочный массив с суммой четных столбцов</returns>
        public int[] EasyCalc(int[,] mas)
        {
            int[] array= new int[mas.GetLength(1)];
          
                for (int i = 0; i < mas.GetLength(0); i++)
                {  for (int j = 1; j < mas.GetLength(1); j=j+2)
                    {
                    array[j] += mas[i, j];

                }
            }
            return array;
        }
    }
}
