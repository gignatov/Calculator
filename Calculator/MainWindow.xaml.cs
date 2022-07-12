using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextScreen.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, DisablePaste));
        }
        private double? firstInputNumber = null;
        private double? secondInputNumber = null;
        private int op = 0;
        private bool hasDot = false;
        private bool usedEquals = false;
        private void DisablePaste(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            ChangeFontSize();
        }
        private void ChangeFontSize()
        {
            if (TextScreen.Text.Length <= 12)
                TextScreen.FontSize = 48;
            if (TextScreen.Text.Length > 12 && TextScreen.Text.Length <= 17)
                TextScreen.FontSize = 34;
            if (TextScreen.Text.Length > 17)
                TextScreen.FontSize = 24;
        }
        private void InsertTextScreenElement(char input)
        {
            if ((TextScreen.Text.Length == 1 && TextScreen.Text[0] == '0' ) || usedEquals)
                TextScreen.Text = null;
            if (TextScreen.Text.Length < 17)
                TextScreen.Text = (TextScreen.Text + input);
            ChangeFontSize();
            TextScreen.Focus();
            TextScreen.Select(TextScreen.Text.Length, 0);
            usedEquals = false;
        }
        private double? DoOperation(int op, double? firstNum, double? secondNum)
        {
            switch (op)
            {
                case 0:
                    return (firstNum);
                case 1:
                    return (firstNum + secondNum);
                case 2:
                    return (firstNum - secondNum);
                case 3:
                    return (firstNum * secondNum);
                case 4:
                    return (firstNum / secondNum);
                default: throw new Exception ("Invalid operator!");
            }
        }
        private void WindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPlus || e.Key == Key.Add)
                CheckInputs(1);
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
                CheckInputs(2);
            if (e.Key == Key.Multiply)
                CheckInputs(3);
            if (e.Key == Key.Divide)
                CheckInputs(4);
            if (e.Key == Key.Return)
                Equals();
            if (e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
                Float();
            if (e.Key == Key.C || e.Key == Key.Delete)
                Clear();
            if (e.Key == Key.Z)
                ChangeSign();
            if (e.Key == Key.X)
                Square();
        }
        private void CheckInputs(int oper)
        {
            if (TextScreen.Text.Length > 0)
            {
                if (firstInputNumber == null && secondInputNumber == null)
                {
                    firstInputNumber = Convert.ToDouble(TextScreen.Text);
                    TextScreen.Text = null;
                    op = oper;
                }
                else if (firstInputNumber != null && secondInputNumber == null)
                {
                    secondInputNumber = Convert.ToDouble(TextScreen.Text);
                    firstInputNumber = DoOperation(op, firstInputNumber, secondInputNumber);
                    secondInputNumber = null;
                    TextScreen.Text = null;
                    op = oper;
                }
                hasDot = false;
            }
            TextScreen.Focus();
        }
        private void Equals()
        {
            if (TextScreen.Text.Length != 0)
                CheckInputs(op);
            TextScreen.Text = firstInputNumber.ToString();
            firstInputNumber = null;
            op = 0;
            TextScreen.Focus();
            TextScreen.Select(TextScreen.Text.Length, 0);
            usedEquals = true;
            ChangeFontSize();
        }
        private void Float()
        {
            if (!hasDot)
            {
                InsertTextScreenElement(',');
                if (TextScreen.Text.Length == 1 && TextScreen.Text[0] == ',')
                    TextScreen.Text = TextScreen.Text.Insert(0, "0");
                hasDot = true;
                TextScreen.Focus();
                TextScreen.Select(TextScreen.Text.Length, 0);
            }
        }
        private void Clear()
        {
            firstInputNumber = null;
            TextScreen.Text = null;
            TextScreen.Focus();
            hasDot = false;
        }
        private void ChangeSign()
        {
            if (TextScreen.Text.Length > 0 && Convert.ToDouble(TextScreen.Text) != 0)
            {
                if (TextScreen.Text[0] == '-')
                    TextScreen.Text = TextScreen.Text.Remove(0, 1);
                else TextScreen.Text = '-' + TextScreen.Text;
            }
            TextScreen.Focus();
            TextScreen.Select(TextScreen.Text.Length, 0);
        }
        private void Square()
        {
            if (TextScreen.Text.Length > 0)
            {
                TextScreen.Text = (Convert.ToDouble(TextScreen.Text) * Convert.ToDouble(TextScreen.Text)).ToString();
                ChangeFontSize();
            }
            TextScreen.Focus();
            TextScreen.Select(TextScreen.Text.Length, 0);
        }
        private void ButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (TextScreen.Text.Length == 0)
                InsertTextScreenElement('0');
            else if (TextScreen.Text.Length > 1 && TextScreen.Text[0] == '0' && TextScreen.Text[1] == ',')
                InsertTextScreenElement('0');
            else if (TextScreen.Text[0] != '0')
                InsertTextScreenElement('0');
            TextScreen.Focus();
            TextScreen.Select(TextScreen.Text.Length, 0);
        }
        private void ButtonOne_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('1');
        }

        private void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('2');
        }

        private void ButtonThree_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('3');
        }

        private void ButtonFour_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('4');
        }

        private void ButtonFive_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('5');
        }

        private void ButtonSix_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('6');
        }

        private void ButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('7');
        }

        private void ButtonEight_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('8');
        }

        private void ButtonNine_Click(object sender, RoutedEventArgs e)
        {
            InsertTextScreenElement('9');
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (TextScreen.Text.Length > 0 && TextScreen.SelectionStart > 0)
            {
                int pos = TextScreen.SelectionStart;
                TextScreen.Text = TextScreen.Text.Remove(TextScreen.SelectionStart - 1, 1);
                TextScreen.Select(pos - 1, 0);
            }
            TextScreen.Focus();
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            CheckInputs(1);
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            CheckInputs(2);
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            CheckInputs(3);
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            CheckInputs(4);
        }
        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            Equals();
        }
        private void ButtonFloat_Click(object sender, RoutedEventArgs e)
        {
            Float();
        }
        private void ButtonSign_Click(object sender, RoutedEventArgs e)
        {
            ChangeSign();
        }

        private void ButtonSquare_Click(object sender, RoutedEventArgs e)
        {
            Square();
        }
    }
}
