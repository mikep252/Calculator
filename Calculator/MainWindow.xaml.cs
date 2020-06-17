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
        double lastnumber, result;
        SelectdOperator operator_selected;
        public MainWindow()
        {
            InitializeComponent();
            
            ACbutton.Click += ACbutton_Click;
           
          
        }

        private void ACbutton_Click(object sender, RoutedEventArgs e)
        {
            resultlabel.Content = "0";
            lastnumber = 0;
            result = 0;
        }

        private void Number_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            if (sender == zero_button)
            {
                selectedValue = 0;
            }
            if (sender == one_button)
            {
                selectedValue = 1;
            }
            if (sender == two_button)
            {
                selectedValue = 2;
            }
            if (sender == three_button)
            {
                selectedValue = 3;
            }
            if (sender == four_button)
            {
                selectedValue = 4;
            }
            if (sender == five_button)
            {
                selectedValue = 5;
            }
            if (sender == six_button)
            {
                selectedValue = 6;
            }
            if (sender == seven_button)
            {
                selectedValue = 7;
            }
            if (sender == eight_button)
            {
                selectedValue = 8;
            }
            if (sender == nine_button)
            {
                selectedValue = 9;
            }
           

            if (resultlabel.Content.ToString() == "0")
            {
                resultlabel.Content = $"{selectedValue}";
            }
            else
            {
                resultlabel.Content = $"{resultlabel.Content}{selectedValue}";
            }
        }

        private void percentagebutton_Click(object sender, RoutedEventArgs e)
        {
            double tempnNumber, newNumber;
            if(double.TryParse(resultlabel.Content.ToString(),out tempnNumber))
            {
                tempnNumber = tempnNumber / 100;
                if (lastnumber != 0)
                    tempnNumber *= lastnumber;
                resultlabel.Content = tempnNumber.ToString();
            }

            // 50 + 5% (2.5) = (52.5)
            // 80 + 10%  (8) = (88)
        }

        private void Equal_Button_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if(double.TryParse(resultlabel.Content.ToString(),out newNumber))
            {
                switch (operator_selected)
                {
                    case SelectdOperator.Addition:
                        result = SimpleMath.Add(lastnumber, newNumber);
                        break;
                    case SelectdOperator.Sustraction:
                        result = SimpleMath.Sustraction(lastnumber, newNumber);
                        break;
                    case SelectdOperator.Division:
                        result = SimpleMath.Divide(lastnumber, newNumber);
                        break;
                    case SelectdOperator.Multiplication:
                        result = SimpleMath.Multiply(lastnumber, newNumber);
                        break;
                }
                resultlabel.Content = result.ToString();
            }
        }
        private void operation_click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultlabel.Content.ToString(), out lastnumber))
            {
                resultlabel.Content = "0";
            }
            if (sender == multiplication)
            {
                operator_selected = SelectdOperator.Multiplication;
            }if(sender == division)
            {
                operator_selected = SelectdOperator.Division;
            }if(sender == minus)
            {
                operator_selected = SelectdOperator.Sustraction;
            }if(sender == plus)
            {
                operator_selected = SelectdOperator.Addition;
            }
        }

        private void Point_button_Click(object sender, RoutedEventArgs e)
        {
            if (resultlabel.Content.ToString().Contains("."))
                {
                /// do nothink
            }
            else {
                resultlabel.Content = $"{resultlabel.Content}.";
            }
        }

        private void plusminusbutton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultlabel.Content.ToString(),out lastnumber))
            {
                lastnumber = lastnumber * -1;
                resultlabel.Content = lastnumber.ToString();
            }
        }
    }
    public enum SelectdOperator
    {
        Addition,
        Sustraction,
        Multiplication,
        Division
    }
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Sustraction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if(n2 == 0 )
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0; 
            }
            return n1 / n2;
        }
    }
}
