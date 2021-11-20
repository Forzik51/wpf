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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double lastNumber, res;
        bool point = true;
        bool percenage = false;
        bool negative = false;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            result.Content = 0;
        }

        private void numbersBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            Button btn = sender as Button;
            if (btn != null)
            {
                selectedValue = int.Parse(btn.Content.ToString());
            }

            if (result.Content.ToString() == "0")
            {
                result.Content = $"{selectedValue}";
            }
            else if (result.Content.ToString() == "-0")
            {
                result.Content = $"-{selectedValue}";
            }
            else
            {
                result.Content = $"{result.Content}{selectedValue}";
            }
        }

        private void operatorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(result.Content.ToString(), out lastNumber))
            {
                result.Content = "0";
            }

            if (sender == plusBtn)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusBtn)
                selectedOperator = SelectedOperator.Substruction;
            if (sender == multiplyBtn)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionBtn)
                selectedOperator = SelectedOperator.Divide;
        }

        private void acBtn_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "0";
            res = 0;
            point = true;
            percenage = false;
            lastNumber = 0;

        }

        private void negativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(negative == false)
            {
                result.Content = $"-{result.Content}";
                negative = true;
            }
            else
            {
                result.Content = result.Content.ToString().Replace("-", string.Empty);
                negative = false;
            }
        }

        private void percenageBtn_Click(object sender, RoutedEventArgs e)
        {
            percenage = true;
        }

        private void pointBtn_Click(object sender, RoutedEventArgs e)
        {
            if(point == true)
            {
                result.Content = $"{result.Content}.";
                point = false;
            }
            
        }

        private void equalBtn_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(result.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        if (percenage == true)
                            res = lastNumber + lastNumber / 100 * newNumber;
                        else
                            res = Calculate.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substruction:
                        if (percenage == true)
                            res = lastNumber - lastNumber / 100 * newNumber;
                        else
                            res = Calculate.Sub(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        if (percenage == true)
                            res = lastNumber * newNumber / 100;
                        else
                            res = Calculate.Mul(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Divide:
                        if (percenage == true)
                            res = lastNumber / (newNumber / 100);
                        else
                            res = Calculate.Div(lastNumber, newNumber);
                        break;
                }

                result.Content = res;
            }
        }

        public enum SelectedOperator
        {
            Addition,
            Substruction,
            Multiplication,
            Divide
        }
    }

    public class Calculate
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Mul(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Div(double n1, double n2)
        {
            return n1 / n2;
        }
    }
}
