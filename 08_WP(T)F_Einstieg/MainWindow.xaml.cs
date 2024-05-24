using Microsoft.Win32;
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

namespace _08_WP_T_F_Einstieg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string textBox = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_Hey_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("haha!");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox = TXB_Eingabe.Text;
            LBL_Eingabe.Content = "Eingabe: " + TXB_Eingabe.Text;
        }

        private void BTN_Wrap_Click(object sender, RoutedEventArgs e)
        {
            new WrapPanel().Show();
        }

        private void BTN_Stack_Click(object sender, RoutedEventArgs e)
        {
            new StackPanel().Show();
        }

        private void BTN_DockPanel_Click(object sender, RoutedEventArgs e)
        {
            new DockPanel().Show();
        }

        private void BTN_Menue_Click(object sender, RoutedEventArgs e)
        {
            new Menue().Show();
        }

        private void BTN_UebersichtRest_Click(object sender, RoutedEventArgs e)
        {
            new UebersichtRest().Show();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Pictures(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png"
            };
            if (ofd.ShowDialog() == true)
            {
                Uri imageUri = new(ofd.FileName);
                IMG_Test.Source = new BitmapImage(imageUri);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            IMG_Test.Source = null;
        }
    }
}