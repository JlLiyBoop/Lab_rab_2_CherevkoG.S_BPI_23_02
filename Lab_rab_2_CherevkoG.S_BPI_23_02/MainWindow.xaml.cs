using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Lab_rab_2_CherevkoG.S_BPI_23_02
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(textN.Text);
                int k = int.Parse(textK.Text);
                double p = double.Parse(textP.Text);
                double x = double.Parse(textX.Text);
                double f = double.Parse(textF.Text);
                double y = double.Parse(textY.Text);

                double result = Calculate.CalcZ(n, k, p, x, f, y);

                Result.Text = $"Z = {result:F6}\n\nВходные параметры:\nN={n}, K={k}, P={p}, X={x}, F={f}, Y={y}";
                Result.Background = Brushes.LightGreen;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка вычисления: {ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool ValidateNK(string input, string pName, out int result, out string errorMessage)
        {
            result = 0;
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = $"{pName}: Не введено!";
                return false;
            }

            if (!int.TryParse(input, out result))
            {
                errorMessage = $"{pName}: Переменная должна быть целой!";
                return false;
            }

            if (result <= 0)
            {
                errorMessage = $"{pName}: Должен быть больше нуля";
                return false;
            }

            return true;
        }
        private bool ValidateOther(string input, string paramName, out double result, out string errorMessage)
        {
            result = 0;
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = $"{paramName}: Не введено!";
                return false;
            }

            if (!double.TryParse(input, out result))
            {
                errorMessage = $"{paramName}: Не похоже на число...";
                return false;
            }

            return true;
        }
    }
}
