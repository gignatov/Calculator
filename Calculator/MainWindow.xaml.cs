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
            this.DataContext = this;
        }
        private string display = "0";
        private double? firstNum = null;
        private bool usedPrimaryOperator = false;
        private bool usedSecondaryOperator = false;
        private int operationNum = 0;
        private string memory = "0";
        private bool usedMemory = false;
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
        public bool UsedPrimaryOperator
        {
            get { return usedPrimaryOperator; }
            set { usedPrimaryOperator = value; }
        }
        public bool UsedSecondaryOperator
        {
            get { return usedSecondaryOperator; }
            set { usedSecondaryOperator = value; }
        }
        public int OperationNum
        {
            get { return operationNum; }
            set { operationNum = value; }
        }
        public string Memory
        {
            get { return memory; }
            set { memory = value; }
        }
        public bool UsedMemory
        {
            get { return usedMemory; }
            set { usedMemory = value; }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Format()
        {
            Formatting.AddSpacing(TextScreen);
            Formatting.ChangeFontSize(TextScreen);
        }
        private void InsertNumber(char ch)
        {
            Display = Validator.InsertElement(Display, ch, UsedPrimaryOperator, UsedSecondaryOperator, UsedMemory);
            UsedPrimaryOperator = false;
            UsedSecondaryOperator = false;
            UsedMemory = false;
            Format();
        }
        private void ExecuteOperation(int op)
        {
            FirstNum = Validator.CheckOperation(OperationNum, Display, FirstNum, UsedPrimaryOperator);
            Display = FirstNum.ToString();
            OperationNum = op;
            UsedPrimaryOperator = true;
            Format();
        }
        private void WindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.OemPlus || e.Key == Key.Add)
            {
                ExecuteOperation(1);
            }
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                ExecuteOperation(2);
            }
            if (e.Key == Key.Multiply)
            {
                ExecuteOperation(3);
            }
            if (e.Key == Key.Divide || e.Key == Key.OemQuestion)
            {
                ExecuteOperation(4);
            }
            if (e.Key == Key.Return)
            {
                ExecuteOperation(0);
                FirstNum = null;
            }
            if (e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
            {
                Display = ButtonOperations.AddDot(Display, UsedPrimaryOperator, UsedSecondaryOperator, UsedMemory);
                UsedPrimaryOperator = false;
                UsedMemory = false;
                Format();
            }
            if (e.Key == Key.C || e.Key == Key.Delete)
            {
                Display = "0";
                FirstNum = null;
                OperationNum = 0;
                UsedPrimaryOperator = false;
                UsedSecondaryOperator = false;
                UsedMemory = false;
                Format();
            }
            if (e.Key == Key.Z)
            {
                Display = ButtonOperations.ChangeSign(Display);
                Format();
            }
            if (e.Key == Key.X)
            {
                Display = Validator.CheckOperation(5, Display, FirstNum, UsedPrimaryOperator).ToString();
                UsedSecondaryOperator = true;
                Format();
            }
            if (e.Key == Key.Back)
            {
                if (!UsedPrimaryOperator || !UsedMemory || !UsedSecondaryOperator)
                    Display = ButtonOperations.Backspace(Display, TextScreen);
                Format();
            }
            if (e.Key == Key.D0 || e.Key == Key.NumPad0)
            {
                if (Validator.ZeroIsValid(Display))
                    InsertNumber('0');
            }
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                InsertNumber('1');
            }
            if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                InsertNumber('2');
            }
            if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                InsertNumber('3');
            }
            if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                InsertNumber('4');
            }
            if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                InsertNumber('5');
            }
            if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                InsertNumber('6');
            }
            if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                InsertNumber('7');
            }
            if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                InsertNumber('8');
            }
            if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                InsertNumber('9');
            }
        }      
        private void ButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.ZeroIsValid(Display))
                InsertNumber('0');
        }
        private void ButtonOne_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('1');
        }
        private void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('2');
        }
        private void ButtonThree_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('3');
        }
        private void ButtonFour_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('4');
        }
        private void ButtonFive_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('5');
        }
        private void ButtonSix_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('6');
        }
        private void ButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('7');
        }
        private void ButtonEight_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('8');
        }
        private void ButtonNine_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber('9');
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Display = "0";
            FirstNum = null;
            OperationNum = 0;
            UsedPrimaryOperator = false;
            UsedSecondaryOperator = false;
            UsedMemory = false;
            Format();
        }
        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (!UsedPrimaryOperator || !UsedMemory || !UsedSecondaryOperator)
                Display = ButtonOperations.Backspace(Display, TextScreen);
            Format();
        }
        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation(1);
        }
        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation(2);
        }
        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation(3);
        }
        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation(4);
        }
        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation(0);
            FirstNum = null;
        }
        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            Display = ButtonOperations.AddDot(Display, UsedPrimaryOperator, UsedSecondaryOperator, UsedMemory);
            UsedPrimaryOperator = false;
            Format();
        }
        private void ButtonSign_Click(object sender, RoutedEventArgs e)
        {
            Display = ButtonOperations.ChangeSign(Display);
            Format();
        }
        private void ButtonSquare_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.CheckOperation(5, Display, FirstNum, UsedPrimaryOperator).ToString();
            UsedSecondaryOperator = true;
            Format();
        }

        private void ButtonMemoryClear_Click(object sender, RoutedEventArgs e)
        {
            Memory = MemoryOperations.MemoryClear();
            UsedMemory = true;
        }

        private void ButtonMemoryRecall_Click(object sender, RoutedEventArgs e)
        {
            Display = MemoryOperations.MemoryRecall(Memory);
            UsedMemory = true;
            UsedPrimaryOperator = false;
            UsedSecondaryOperator = false;
        }

        private void ButtonMemoryAdd_Click(object sender, RoutedEventArgs e)
        {
            Memory = MemoryOperations.MemoryAdd(Memory, Display);
            UsedMemory = true;
        }

        private void ButtonMemorySubtract_Click(object sender, RoutedEventArgs e)
        {
            Memory = MemoryOperations.MemorySubtract(Memory, Display);
            UsedMemory = true;
        }

        private void ButtonMemoryStore_Click(object sender, RoutedEventArgs e)
        {
            Memory = MemoryOperations.MemoryStore(Display);
            UsedMemory = true;
        }

        private void ButtonClearEntry_Click(object sender, RoutedEventArgs e)
        {
            Display = "0";
            Format();
        }

        private void ButtonReciprocal_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.CheckOperation(6, Display, FirstNum, UsedPrimaryOperator).ToString();
            UsedSecondaryOperator = true;
            Format();
        }

        private void ButtonSquareRoot_Click(object sender, RoutedEventArgs e)
        {
            Display = Validator.CheckOperation(7, Display, FirstNum, UsedPrimaryOperator).ToString();
            UsedSecondaryOperator = true;
            Format();
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            if (OperationNum == 1)
                Display = Validator.CheckOperation(8, Display, FirstNum, UsedPrimaryOperator).ToString();
            else if (OperationNum == 2)
                Display = (FirstNum - Validator.CheckOperation(8, Display, FirstNum, UsedPrimaryOperator)).ToString();
            else if (OperationNum == 3)
                Display = (FirstNum * Validator.CheckOperation(8, Display, FirstNum, UsedPrimaryOperator)).ToString();
            else if (OperationNum == 4)
                Display = (FirstNum / Validator.CheckOperation(8, Display, FirstNum, UsedPrimaryOperator)).ToString();
            else Display = Validator.CheckOperation(8, Display, FirstNum, UsedPrimaryOperator).ToString();
            UsedSecondaryOperator = true;
            Format();
        }
    }
}
