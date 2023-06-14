using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoundApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string replac(string s)
            {
                string input = s;
                string pattern = "\\.";
                string replacement = ",";
                string result = Regex.Replace(input, pattern, replacement);

                //Console.WriteLine("Original String: {0}", input);
                //Console.WriteLine("Replacement String: {0}", result);

                return result;
            }
            void app(string[] substrings)
            {


                // for example the input is 34.45
                // will split number to tow section dependec on '.'
                // one_section = 34
                // tow_section = 45
                string one_section = substrings[0];
                string tow_section = substrings[1];
                // tak the first number of tow_section = 78 => 7 and convert it into integer
                // and compire to 5<7<5 
                // if 7 > 5 will add 1 to one_section will become 35
                // if not will still same 34
                string FirstNumberOf_tow_section = Convert.ToString(tow_section[0]); // convert char to string bec char = 'num' string = "num" and ToInt32 dont allow char it will make logical error


                long F_int = Convert.ToInt32(FirstNumberOf_tow_section);

                if (F_int >= 5)
                {
                    // convert one_section into int and plus 1 and print it
                    int one_section_int = Convert.ToInt32(one_section);
                    one_section_int += 1;
                    lb.Content = one_section_int;
                }
                else
                {
                    lb.Content = one_section;
                }


            }

            string num = textbox.Text;
            if(textbox.Text.Length == 0)
            {
                MessageBox.Show("enter number", "warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            Regex regex = new Regex(",");
            string[] substrings = regex.Split(replac(num));
            if (substrings.Length > 2)
            {
                MessageBox.Show("this number is enncorrect", "error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (substrings.Length == 1)
            {
                MessageBox.Show("this number is not double", "wrong", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                app(substrings);
            }


        }

        private void textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}