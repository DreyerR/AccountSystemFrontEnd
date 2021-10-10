using AccountSystemFrontEnd.Models;
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
using AccountSystemFrontEnd.WebService;

namespace AccountSystemFrontEnd
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

        private async void btnViewCurrency_Click(object sender, RoutedEventArgs e)
        {
            GeneralResponse<Currency> response = await Api.FetchMemberCurrency();
            if (null != response)
            {
                lstViewOutput.Items.Clear();
                lstViewOutput.Items.Add(String.Format("Currency: {0} {1}", response.payload.CurrencyAmount, 
                    response.payload.CurrencyTypeName));
            }
            else
            {
                MessageBox.Show("Member could not be found", "Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void btnAddCurrency_Click(object sender, RoutedEventArgs e)
        {
            GeneralResponse<string> response = await Api.AddCurrency(double.Parse(txtAddAmount.Text));
            lstAddOutput.Items.Clear();
            lstAddOutput.Items.Add(response.payload);
        }

        private async void btnSubtractCurrency_Click(object sender, RoutedEventArgs e)
        {
            GeneralResponse<string> response = await Api.SubtractCurrency(double.Parse(txtSubAmount.Text));
            lstSubtractOutput.Items.Clear();
            lstSubtractOutput.Items.Add(response.payload);
        }
    }
}
