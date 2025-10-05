using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab_rab_2_CherevkoG.S_BPI_23_02
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            R1ComboA.ItemsSource = Calculate.GetOtherValues();
            R1ComboF.ItemsSource = Calculate.GetFValues1();
            R1ComboA.SelectedIndex = 2;
            R1ComboF.SelectedIndex = 0;

            R2ComboA.ItemsSource = Calculate.GetOtherValues();
            R2ComboB.ItemsSource = Calculate.GetOtherValues();
            R2ComboF.ItemsSource = Calculate.GetFValues2();
            R2ComboA.SelectedIndex = 2;
            R2ComboB.SelectedIndex = 2;
            R2ComboF.SelectedIndex = 0;

            R3ComboA.ItemsSource = Calculate.GetOtherValues();
            R3ComboB.ItemsSource = Calculate.GetOtherValues();
            R3ComboC.ItemsSource = Calculate.GetCValues3();
            R3ComboD.ItemsSource = Calculate.GetDValues3();
            R3ComboA.SelectedIndex = 2;
            R3ComboB.SelectedIndex = 2;
            R3ComboC.SelectedIndex = 0;
            R3ComboD.SelectedIndex = 1;

            R4ComboA.ItemsSource = Calculate.GetOtherValues();
            R4ComboC.ItemsSource = Calculate.GetCValues4();
            R4ComboD.ItemsSource = Calculate.GetNKValues();
            R4ComboA.SelectedIndex = 2;
            R4ComboC.SelectedIndex = 0;
            R4ComboD.SelectedIndex = 0;

            R5ComboN.ItemsSource = Calculate.GetNKValues();
            R5ComboK.ItemsSource = Calculate.GetNKValues();
            R5ComboP.ItemsSource = Calculate.GetOtherValues();
            R5ComboX.ItemsSource = Calculate.GetOtherValues();
            R5ComboF.ItemsSource = Calculate.GetOtherValues();
            R5ComboY.ItemsSource = Calculate.GetOtherValues();
            R5ComboN.SelectedIndex = 4;
            R5ComboK.SelectedIndex = 2;
            R5ComboP.SelectedIndex = 2;
            R5ComboX.SelectedIndex = 2;
            R5ComboF.SelectedIndex = 2;
            R5ComboY.SelectedIndex = 2;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!AllOk()) return;

            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                string value = comboBox.SelectedItem.ToString();
                string comboBoxName = comboBox.Name;

                switch (comboBoxName)
                {
                    case "R1ComboA": R1TextA.Text = value; break;
                    case "R1ComboF": R1TextF.Text = value; break;

                    case "R2ComboA": R2TextA.Text = value; break;
                    case "R2ComboB": R2TextB.Text = value; break;
                    case "R2ComboF": R2TextF.Text = value; break;

                    case "R3ComboA": R3TextA.Text = value; break;
                    case "R3ComboB": R3TextB.Text = value; break;
                    case "R3ComboC": R3TextC.Text = value; break;
                    case "R3ComboD": R3TextD.Text = value; break;

                    case "R4ComboA": R4TextA.Text = value; break;
                    case "R4ComboC": R4TextC.Text = value; break;
                    case "R4ComboD": R4TextD.Text = value; break;

                    case "R5ComboN": R5TextN.Text = value; break;
                    case "R5ComboK": R5TextK.Text = value; break;
                    case "R5ComboP": R5TextP.Text = value; break;
                    case "R5ComboX": R5TextX.Text = value; break;
                    case "R5ComboF": R5TextF.Text = value; break;
                    case "R5ComboY": R5TextY.Text = value; break;
                }
            }
            ValidateAll();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!AllOk()) return;
            ValidateAll();
        }

        private bool AllOk()
        {
            try
            {
                if (buttonCalc == null || Result == null) return false;

                if (Radio1 == null || Radio2 == null || Radio3 == null || Radio4 == null || Radio5 == null) return false;

                if (Radio1.IsChecked == true)
                {
                    return R1TextA != null && R1TextF != null;
                }
                else if (Radio2.IsChecked == true)
                {
                    return R2TextA != null && R2TextB != null && R2TextF != null;
                }
                else if (Radio3.IsChecked == true)
                {
                    return R3TextA != null && R3TextB != null && R3TextC != null && R3TextD != null;
                }
                else if (Radio4.IsChecked == true)
                {
                    return R4TextA != null && R4TextC != null && R4TextD != null;
                }
                else if (Radio5.IsChecked == true)
                {
                    return R5TextN != null && R5TextK != null && R5TextP != null &&
                           R5TextX != null && R5TextF != null && R5TextY != null;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ValidateAll()
        {
            if (!AllOk())
            {
                buttonCalc.IsEnabled = false;
                Result.Text = "Инициализация...";
                Result.Background = Brushes.LightGray;
                return;
            }

            bool allValid = true;
            string errorMessage = "";

            if (Radio1.IsChecked == true)
            {
                if (!ValidateOther(R1TextA.Text, "a", out double a, out string aError))
                {
                    allValid = false;
                    errorMessage += aError + "\n";
                }
                if (!ValidateInt(R1TextF.Text, "f", out int f, out string fError))
                {
                    allValid = false;
                    errorMessage += fError + "\n";
                }
            }
            else if (Radio2.IsChecked == true)
            {
                if (!ValidateOther(R2TextA.Text, "a", out double a, out string aError))
                {
                    allValid = false;
                    errorMessage += aError + "\n";
                }
                if (!ValidateOther(R2TextB.Text, "b", out double b, out string bError))
                {
                    allValid = false;
                    errorMessage += bError + "\n";
                }
                if (!ValidateInt(R2TextF.Text, "f", out int f, out string fError))
                {
                    allValid = false;
                    errorMessage += fError + "\n";
                }
            }
            else if (Radio3.IsChecked == true)
            {
                if (!ValidateOther(R3TextA.Text, "a", out double a, out string aError))
                {
                    allValid = false;
                    errorMessage += aError + "\n";
                }
                if (!ValidateOther(R3TextB.Text, "b", out double b, out string bError))
                {
                    allValid = false;
                    errorMessage += bError + "\n";
                }
                if (!ValidateInt(R3TextC.Text, "c", out int c, out string cError))
                {
                    allValid = false;
                    errorMessage += cError + "\n";
                }
                if (!ValidateInt(R3TextD.Text, "d", out int d, out string dError))
                {
                    allValid = false;
                    errorMessage += dError + "\n";
                }
            }
            else if (Radio4.IsChecked == true)
            {
                if (!ValidateOther(R4TextA.Text, "a", out double a, out string aError))
                {
                    allValid = false;
                    errorMessage += aError + "\n";
                }
                if (!ValidateInt(R4TextC.Text, "c", out int c, out string cError))
                {
                    allValid = false;
                    errorMessage += cError + "\n";
                }
                if (!ValidateInt(R4TextD.Text, "d", out int d, out string dError))
                {
                    allValid = false;
                    errorMessage += dError + "\n";
                }
            }
            else if (Radio5.IsChecked == true)
            {
                if (!ValidateNK(R5TextN.Text, "N", out int n, out string nError))
                {
                    allValid = false;
                    errorMessage += nError + "\n";
                }
                if (!ValidateNK(R5TextK.Text, "K", out int k, out string kError))
                {
                    allValid = false;
                    errorMessage += kError + "\n";
                }
                if (!ValidateOther(R5TextP.Text, "P", out double p, out string pError))
                {
                    allValid = false;
                    errorMessage += pError + "\n";
                }
                if (!ValidateOther(R5TextX.Text, "X", out double x, out string xError))
                {
                    allValid = false;
                    errorMessage += xError + "\n";
                }
                if (!ValidateOther(R5TextF.Text, "F", out double f, out string fError))
                {
                    allValid = false;
                    errorMessage += fError + "\n";
                }
                if (!ValidateOther(R5TextY.Text, "Y", out double y, out string yError))
                {
                    allValid = false;
                    errorMessage += yError + "\n";
                }
            }

            buttonCalc.IsEnabled = allValid;
            if (allValid)
            {
                Result.Text = "Все параметры корректны";
                Result.Background = Brushes.LightGreen;
            }
            else
            {
                Result.Text = "Исправьте ошибки:\n" + errorMessage.Trim();
                Result.Background = Brushes.LightPink;
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

        private bool ValidateInt(string input, string paramName, out int result, out string errorMessage)
        {
            result = 0;
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = $"{paramName}: Не введено!";
                return false;
            }

            if (!int.TryParse(input, out result))
            {
                errorMessage = $"{paramName}: Должно быть целым числом!";
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

        private void ButtonCalc_Click(object sender, RoutedEventArgs e)
        {
            if (!buttonCalc.IsEnabled)
            {
                MessageBox.Show("Исправьте ошибки в параметрах");
                return;
            }

            try
            {
                double result = 0;
                string parameters = "";

                if (Radio1.IsChecked == true)
                {
                    double a = double.Parse(R1TextA.Text);
                    int f = int.Parse(R1TextF.Text);
                    result = Calculate.Calculate1(a, f);
                    parameters = $"a={a}, f={f}";
                }
                else if (Radio2.IsChecked == true)
                {
                    double a = double.Parse(R2TextA.Text);
                    double b = double.Parse(R2TextB.Text);
                    int f = int.Parse(R2TextF.Text);
                    result = Calculate.Calculate2(a, b, f);
                    parameters = $"a={a}, b={b}, f={f}";
                }
                else if (Radio3.IsChecked == true)
                {
                    double a = double.Parse(R3TextA.Text);
                    double b = double.Parse(R3TextB.Text);
                    int c = int.Parse(R3TextC.Text);
                    int d = int.Parse(R3TextD.Text);
                    result = Calculate.Calculate3(a, b, c, d);
                    parameters = $"a={a}, b={b}, c={c}, d={d}";
                }
                else if (Radio4.IsChecked == true)
                {
                    double a = double.Parse(R4TextA.Text);
                    int c = int.Parse(R4TextC.Text);
                    int d = int.Parse(R4TextD.Text);
                    result = Calculate.Calculate4(a, c, d);
                    parameters = $"a={a}, c={c}, d={d}";
                }
                else if (Radio5.IsChecked == true)
                {
                    int n = int.Parse(R5TextN.Text);
                    int k = int.Parse(R5TextK.Text);
                    double p = double.Parse(R5TextP.Text);
                    double x = double.Parse(R5TextX.Text);
                    double f = double.Parse(R5TextF.Text);
                    double y = double.Parse(R5TextY.Text);
                    result = Calculate.Calculate5(n, k, p, x, f, y);
                    parameters = $"N={n}, K={k}, P={p}, X={x}, F={f}, Y={y}";
                }

                Result.Text = $"Результат: {result:F6}\n\nПараметры:\n{parameters}";
                Result.Background = Brushes.LightGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычисления: {ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}