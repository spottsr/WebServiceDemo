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

namespace WebServiceDemo
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

        private void Window_Initialized(object sender, EventArgs e)
        {
            // Populate Comboboxes with Temperature Scales
            ComboBoxFrom.ItemsSource = Enum.GetValues(typeof(WebServiceXConvertTemperature.TemperatureUnit));
            ComboBoxTo.ItemsSource = Enum.GetValues(typeof(WebServiceXConvertTemperature.TemperatureUnit));
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            WebServiceXConvertTemperature.ConvertTemperatureSoapClient units = new WebServiceXConvertTemperature.ConvertTemperatureSoapClient("ConvertTemperatureSoap12");

            double result = units.ConvertTemp(Convert.ToDouble(TextFieldFrom.Text),
                (WebServiceXConvertTemperature.TemperatureUnit)Enum.Parse(typeof(WebServiceXConvertTemperature.TemperatureUnit), ComboBoxFrom.SelectedItem.ToString()),
                (WebServiceXConvertTemperature.TemperatureUnit)Enum.Parse(typeof(WebServiceXConvertTemperature.TemperatureUnit), ComboBoxTo.SelectedItem.ToString()));

            
            TextFieldTo.Text = Convert.ToString(result);
        }
    }
}
