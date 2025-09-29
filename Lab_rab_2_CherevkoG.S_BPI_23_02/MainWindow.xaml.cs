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
            Params();
            ValidateAll();
        }
        private void Params()
        {
            comboN.ItemsSource = Calculate.GetNKValues();
            comboK.ItemsSource = Calculate.GetNKValues();
            comboP.ItemsSource = Calculate.GetOtherValues();
            comboX.ItemsSource = Calculate.GetOtherValues();
            comboF.ItemsSource = Calculate.GetOtherValues();
            comboY.ItemsSource = Calculate.GetOtherValues();

            comboN.SelectedIndex = 2;
            comboK.SelectedIndex = 2;
            comboP.SelectedIndex = 1;
            comboX.SelectedIndex = 1;
            comboF.SelectedIndex = 1;
            comboY.SelectedIndex = 1;
        }

        private void ButtonCalc_Click(object sender, RoutedEventArgs e)
        {
            if (buttonCalc.IsEnabled == false)
            {
                MessageBox.Show("Беда");
                return;
            }
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
        private void ValidateAll()
        {
            bool allValid = true;
            string errorMessage = "";

            if (!ValidateNK(textN.Text, "N", out int n, out string nError))
            {
                allValid = false;
                errorMessage += nError + "\n";
            }

            if (!ValidateNK(textK.Text, "K", out int k, out string kError))
            {
                allValid = false;
                errorMessage += kError + "\n";
            }

            if (!ValidateOther(textP.Text, "P", out double p, out string pError))
            {
                allValid = false;
                errorMessage += pError + "\n";
            }

            if (!ValidateOther(textX.Text, "X", out double x, out string xError))
            {
                allValid = false;
                errorMessage += xError + "\n";
            }

            if (!ValidateOther(textF.Text, "F", out double f, out string fError))
            {
                allValid = false;
                errorMessage += fError + "\n";
            }

            if (!ValidateOther(textY.Text, "Y", out double y, out string yError))
            {
                allValid = false;
                errorMessage += yError + "\n";
            }
            buttonCalc.IsEnabled = allValid;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                string value = comboBox.SelectedItem.ToString();
                switch (comboBox.Name)
                {
                    case "comboN": textN.Text = value; break;
                    case "comboK": textK.Text = value; break;
                    case "comboP": textP.Text = value; break;
                    case "comboX": textX.Text = value; break;
                    case "comboF": textF.Text = value; break;
                    case "comboY": textY.Text = value; break;
                }
            }
            ValidateAll();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateAll();
        }
    }
}
