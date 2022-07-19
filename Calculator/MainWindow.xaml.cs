using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            TextScreen.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, DisablePaste));
            this.DataContext = this;
        }
        private string display = "";
        private double? firstNum = null;
        private bool usedOperator = false;
        private int operationNum = 0;
        public string Display 
        {
            get { return display; } 
            set 
            { 
                display = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Display"));
            } 
        }
        public double? FirstNum 
        { 
            get { return firstNum; } 
            set { firstNum = value; } 
        }
        public bool UsedOperator
        {
            get { return usedOperator; }
            set { usedOperator = value; }
        }
        public int OperationNum
        {
            get { return operationNum; }
            set { operationNum = value; }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Format()
        {
            Validator.ChangeFontSize(TextScreen);
            Validator.SetFocus(TextScreen);
        }
        private void DisablePaste(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            Format();
        }
        private void WindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            e.Handled = e.Key == Key.Back;
            if (e.Key == Key.OemPlus || e.Key == Key.Add)
            {
                FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
                Display = FirstNum.ToString();
                OperationNum = 1;
                UsedOperator = true;
                Format();
            }
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
                Display = FirstNum.ToString();
                OperationNum = 2;
                UsedOperator = true;
                Format();
            }
            if (e.Key == Key.Multiply)
            {
                FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
                Display = FirstNum.ToString();
                OperationNum = 3;
                UsedOperator = true;
                Format();
            }
            if (e.Key == Key.Divide)
            {
                FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
                Display = FirstNum.ToString();
                OperationNum = 4;
                UsedOperator = true;
                Format();
            }
            if (e.Key == Key.Return)
            {
                FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
                Display = FirstNum.ToString();
                FirstNum = null;
                OperationNum = 0;
                UsedOperator = true;
                Format();
            }
            if (e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
            {
                Display = ButtonOperations.AddDot(Display, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.C || e.Key == Key.Delete)
            {
                Display = "";
                FirstNum = null;
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.Z)
            {
                Display = ButtonOperations.ChangeSign(Display);
                Format();
            }
            if (e.Key == Key.X)
            {
                FirstNum = Validator.CheckOperation(5, Display, FirstNum, UsedOperator);
                Display = FirstNum.ToString();
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.Back)
            {
                if (!UsedOperator)
                    Display = ButtonOperations.Backspace(Display, TextScreen);
                Format();
            }
            if (e.Key == Key.D0 || e.Key == Key.NumPad0)
            {
                if (Validator.ZeroIsValid(Display))
                    Display = Validator.InsertElement(Display, null, UsedOperator);
                else
                    Display = ButtonOperations.Backspace(Display, TextScreen);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
            if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                Display = Validator.InsertElement(Display, null, UsedOperator);
                UsedOperator = false;
                Format();
            }
        }      
        private void ButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.ZeroIsValid(Display))
                Display = Validator.InsertElement(Display, '0', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonOne_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '1', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '2', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonThree_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '3', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonFour_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '4', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonFive_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '5', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonSix_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '6', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '7', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonEight_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '8', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonNine_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.InsertElement(Display, '9', UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Display = "";
            FirstNum = null;
            UsedOperator = false;
            Format();
        }
        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (!UsedOperator)
                Display = ButtonOperations.Backspace(Display, TextScreen);
            Format();
        }
        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
            Display = FirstNum.ToString();
            OperationNum = 1;
            UsedOperator = true;
            Format();
        }
        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
            Display = FirstNum.ToString();
            OperationNum = 2;
            UsedOperator = true;
            Format();
        }
        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
            Display = FirstNum.ToString();
            OperationNum = 3;
            UsedOperator = true;
            Format();
        }
        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
            Display = FirstNum.ToString();
            UsedOperator = true;
            OperationNum = 4;
            Format();
        }
        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedOperator);
            Display = FirstNum.ToString();
            OperationNum = 0;
            FirstNum = null;
            UsedOperator = true;
            Format();
        }
        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            Display = ButtonOperations.AddDot(Display, UsedOperator);
            UsedOperator = false;
            Format();
        }
        private void ButtonSign_Click(object sender, RoutedEventArgs e)
        {
            Display = ButtonOperations.ChangeSign(Display);
            Format();
        }
        private void ButtonSquare_Click(object sender, RoutedEventArgs e)
        {
            FirstNum = Validator.CheckOperation(5, Display, FirstNum, UsedOperator);
            Display = FirstNum.ToString();
            UsedOperator = true;
            Format();
        }
    }
}
