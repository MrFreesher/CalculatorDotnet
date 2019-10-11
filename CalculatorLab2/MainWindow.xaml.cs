using System;
using System.Collections.Generic;
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

namespace CalculatorLab2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int firstNumber= -1;
        private int secondNumber = -1;
        private char operation;


        public MainWindow()
        {
            InitializeComponent();
            oneNumberBtn.Click += addNumber;
            twoNumberBtn.Click += addNumber;
            threeNumberBtn.Click += addNumber;
            fourNumberBtn.Click += addNumber;
            fiveNumberBtn.Click += addNumber;
            sixNumberBtn.Click += addNumber;
            sevenNumberBtn.Click += addNumber;
            eightNumberBtn.Click += addNumber;
            nineNumberBtn.Click += addNumber;
            zeroNumberBtn.Click += addNumber;
            plusBtn.Click += addOperation;
            minusBtn.Click += addOperation;
            divideBtn.Click += addOperation;
            multiplyBtn.Click += addOperation;
            powerBtn.Click += addOperation;
            moduloBtn.Click += addOperation;
            calculateBtn.Click += calculate;
            resetAll();
        }

        private int sum(int a,int b)
        {
            return a + b;
        }
        private int substract(int a,int b)
        {
            return a - b;
        }
        private double multiply(int a,int b)
        {
            return a * b;
        }
        private double divide(int a,int b)
        {
            if (b == 0)
            {
                throw new Exception("Second number is zero. Cannot divide by zero");
            }
            else
            {
                return a / b;
            }
        }
        private void addNumber(object sender,EventArgs args)
        {
            Button b = (Button)sender;
            input.Text += b.Content;
            
        } 
        private void addOperation(object sender,EventArgs args)
        {

            if(input.Text != "") { 
                
                Button b = (Button)sender;
                input.Text += b.Content;
                operation = Convert.ToChar(b.Content);
                plusBtn.IsEnabled = false;
                minusBtn.IsEnabled = false;
                multiplyBtn.IsEnabled = false;
                divideBtn.IsEnabled = false;
                powerBtn.IsEnabled = false;
                moduloBtn.IsEnabled = false;
                calculateBtn.IsEnabled = true;
            }
        }
        

        private double power(int a,int b)
        {
            double aa = (double)a;
            double bb = (double)b;
            return Math.Pow(a,b);
        }
        private int modulo(int a,int b)
        {
            if (b == 0)
            {
                throw new Exception("Cannot perform modulo with second number as 0");
            }
            else
            {
                return a % b;
            }
        }

        private void calculate(object sender,EventArgs args)
        {
            try
            {
                var numbers = input.Text.Split(operation);
                firstNumber = Convert.ToInt32(numbers[0]);
                secondNumber = Convert.ToInt32(numbers[1]);

                switch (operation)
                {
                    case '+':
                        {
                            output.Content = sum(firstNumber, secondNumber).ToString();
                            break;
                        }
                    case '-':
                        {
                            output.Content = substract(firstNumber, secondNumber).ToString();
                            break;
                        }
                    case '*':
                        {
                            output.Content = multiply(firstNumber, secondNumber).ToString();
                            break;
                        }
                    case '/':
                        {
                            output.Content = divide(firstNumber, secondNumber).ToString();
                            break;
                        }
                    case '^':
                        {
                            output.Content = power(firstNumber, secondNumber).ToString();
                            break;
                        }
                    case '%':
                        {
                            output.Content = modulo(firstNumber, secondNumber).ToString();
                            break;
                        }

                }
            }catch(Exception e)
            {
                output.Content = e.Message;
            }
            finally
            {
                resetAll();
            }
        }
        private void resetAll()
        {
            input.Text = "";
            firstNumber = -1;
            secondNumber = -1;
            operation = '.';
            plusBtn.IsEnabled = true;
            minusBtn.IsEnabled = true;
            multiplyBtn.IsEnabled = true;
            divideBtn.IsEnabled = true;
            powerBtn.IsEnabled = true;
            moduloBtn.IsEnabled = true;
            calculateBtn.IsEnabled = false;

        }
    }
}
