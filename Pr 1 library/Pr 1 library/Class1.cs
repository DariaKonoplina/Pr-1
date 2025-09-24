using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMas
{
    static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }

    static class MasFill
    {
        public static int[] CreateMas(int range, int count)
        {
            int[] mas = new int[count];
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            mas[i] = rnd.Next(-100,range);
            return mas;
        }
    }

    static class CalcSqrt
    {
        public static double[] SqrtOp(int[] massive)
        {
            double[] rez = new double[massive.Length];
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] > 0)
                {
                    rez[i] = Math.Sqrt(massive[i]);
                    rez[i] = Math.Round(rez[i], 2);
                }
                else
                    rez[i] = 0;
            }
            return rez;
        }
    }
    static class MasOper
    {
        public static void SaveMas(int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(mas.Length);
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }
        public static int[] OpenMas(ref int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int len = Convert.ToInt32(file.ReadLine());
                mas = new Int32[len];
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
            }
            return mas;
        }
    }
}   
