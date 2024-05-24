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

namespace A_03_WPF_Uebungen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string eingabe = string.Empty;

        private List<float> inputs = [];
        private List<string> operands = [];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateErgebnis()
        {
            LBL_Ergebnis.Content = eingabe;
        }

        private void BTN_Zero(object sender, RoutedEventArgs e)
        {
            eingabe += "0";
            UpdateErgebnis();
        }

        private void BTN_One(object sender, RoutedEventArgs e)
        {
            eingabe += "1";
            UpdateErgebnis();
        }

        private void BTN_Two(object sender, RoutedEventArgs e)
        {
            eingabe += "2";
            UpdateErgebnis();
        }

        private void BTN_Three(object sender, RoutedEventArgs e)
        {
            eingabe += "3";
            UpdateErgebnis();
        }

        private void BTN_Four(object sender, RoutedEventArgs e)
        {
            eingabe += "4";
            UpdateErgebnis();
        }

        private void BTN_Five(object sender, RoutedEventArgs e)
        {
            eingabe += "5";
            UpdateErgebnis();
        }

        private void BTN_Six(object sender, RoutedEventArgs e)
        {
            eingabe += "6";
            UpdateErgebnis();
        }

        private void BTN_Seven(object sender, RoutedEventArgs e)
        {
            eingabe += "7";
            UpdateErgebnis();
        }

        private void BTN_Eight(object sender, RoutedEventArgs e)
        {
            eingabe += "8";
            UpdateErgebnis();
        }

        private void BTN_Nine(object sender, RoutedEventArgs e)
        {
            eingabe += "9";
            UpdateErgebnis();
        }

        private void BTN_Calculate(object sender, RoutedEventArgs e)
        {
            StoreInput();
            float gg = inputs[0];

            for (int i = 0; i < operands.Count; i++)
            {
                if (operands[i] == "/")
                {
                    gg /= inputs[i + 1];
                }
                else if (operands[i] == "*")
                {
                    gg *= inputs[i + 1];
                }
                else if (operands[i] == "+")
                {
                    gg += inputs[i + 1];
                }
                else if (operands[i] == "-")
                {
                    gg -= inputs[i + 1];
                }
            }
            BTN_Clear(sender, e);
            LBL_Ergebnis.Content = gg;
        }

        private void BTN_Clear(object sender, RoutedEventArgs e)
        {
            inputs.Clear();
            operands.Clear();
            eingabe = string.Empty;
            LBL_Ergebnis.Content = string.Empty;
        }

        private void StoreInput()
        {
            inputs.Add(float.Parse(eingabe));
            LBL_Ergebnis.Content = string.Empty;
            eingabe = string.Empty;
        }

        private void BTN_Subtract(object sender, RoutedEventArgs e)
        {
            if (eingabe.Length != 0)
            {
                StoreInput();
                operands.Add("-");
            }
        }

        private void BTN_Sum(object sender, RoutedEventArgs e)
        {
            if (eingabe.Length != 0)
            {
                StoreInput();
                operands.Add("+");
            }
        }

        private void BTN_Divide(object sender, RoutedEventArgs e)
        {
            if (eingabe.Length != 0)
            {
                StoreInput();
                operands.Add("/");
            }
        }

        private void BTN_Multiply(object sender, RoutedEventArgs e)
        {
            if (eingabe.Length != 0)
            {
                StoreInput();
                operands.Add("*");
            }
        }

        //Übung 2________________________________________________________________________________________________________
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            var input = Input.Text.ToLower();
            var reverse = new string(input.Reverse().ToArray());

            if (input == reverse)
            {
                Output.Text = reverse;
                Output.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                Output.Text = reverse;
                Output.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}