using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using WpfLib;

namespace Pr_1_library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] mas; 
        private void miFillMas_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbRange.Text, out int randMas) || randMas <= 0)
            {
                MessageBox.Show("Введите корректное положительное число для диапазона.");
                return;
            }
            if (!int.TryParse(tbKol.Text, out int Count) || Count <= 0)
            {
                MessageBox.Show("Введите корректное положительное число для количества колонок.");
                return;
            }
            mas = LibMas.MasFill.CreateMas(randMas, Count);
            dataGrid.ItemsSource = LibMas.VisualArray.ToDataTable(mas).DefaultView;
        }

        private void miClear_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            mas = null;
            tbRange.Clear();
            tbKol.Clear();
        }

        private void miProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №1 Коноплина Д. ИСП-31 \nВариант 10. Ввести n целых чисел. Вычислить для чисел > 0 функцию корень х. Результат обработки каждого числа вывести на экран.");
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            LibMas.MasOper.OpenMas(ref mas);
            dataGrid.ItemsSource = LibMas.VisualArray.ToDataTable(mas).DefaultView;
        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Заполните массив");
            }
            else LibMas.MasOper.SaveMas(mas);
        }

        private void btnAnsw_Click(object sender, RoutedEventArgs e)
        {
            double[] sqrtMas = LibMas.CalcSqrt.SqrtOp(mas);
            dataGrid.ItemsSource = LibMas.VisualArray.ToDataTable(sqrtMas).DefaultView;
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;
            mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);   
        }
    }
}