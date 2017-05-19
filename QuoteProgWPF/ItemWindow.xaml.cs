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
using System.Windows.Shapes;

namespace QuoteProgWPF
{
    /// <summary>
    /// Interaction logic for ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {

        public MainWindow MyWind;
        public CSI_Item MyItem;

        public bool IsUsingNet = false;
        public decimal SetListPrice;
        public decimal SetNetPrice;
        public decimal CalcNetPrice;
        public decimal SetMarkup;
        public decimal SetDiscount;
        

        public ItemWindow()
        {
            MyItem = new CSI_Item();
            InitializeComponent();
        }

        public void OnWindowClosed()
        {
            MyWind.Wind_Item = null;
        }

        public void CloseWindow()
        {
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            OnWindowClosed();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {

            CloseWindow();
        }

        public decimal GetMarkupPercent()
        {
            return SetMarkup * .01m;
        }

        public decimal CalculateNet()
        {
            return SetListPrice * (1 - (SetDiscount * .01m));
        }

        public decimal CalculatePrice()
        {
             return SetNetPrice / (1 - GetMarkupPercent());
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            MyItem.ItemName = textBox.Text;
        }

        private void Desc_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            MyItem.Description = textBox.Text;
        }

        private void List_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string st = UtilsMain.ValidateTextDecimal(textBox.Text);
            decimal.TryParse(st, out SetListPrice);
            UtilsMain.ParseCurrency(textBox);
        }

        private void Net_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string st = UtilsMain.ValidateTextDecimal(textBox.Text);
            decimal.TryParse(st, out SetNetPrice);
            MyItem.NetPrice = SetNetPrice;
            UtilsMain.ParseCurrency(textBox);

            MyItem.SellPrice = CalculatePrice();
            MyItem.Profit = MyItem.SellPrice - MyItem.NetPrice;

            tb_it_sell.Text = "$" + MyItem.SellPrice.ToString("N2");
            tb_it_profit.Text = "$" + MyItem.Profit.ToString("N2");
        }

        private void Discount_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string st = UtilsMain.ValidateTextDecimal(textBox.Text);
            decimal.TryParse(st, out SetDiscount);
            
            if (string.IsNullOrEmpty(st))
            {
                st = "0";
            }
            textBox.Text = st + "%";
        }

        private void Markup_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string st = UtilsMain.ValidateTextDecimal(textBox.Text);
            decimal.TryParse(st, out SetMarkup);
            
            if (string.IsNullOrEmpty(st))
            {
                st = "0";
            }
            textBox.Text = st + "%";

            MyItem.SellPrice = CalculatePrice();
            MyItem.Profit = MyItem.SellPrice - MyItem.NetPrice;

            tb_it_sell.Text = "$" + MyItem.SellPrice.ToString("N2");
            tb_it_profit.Text = "$" + MyItem.Profit.ToString("N2");
        }

        private void Price_LostFocus(TextBox textBox)
        {
            
            UtilsMain.ParseCurrency(textBox);
        }

        private void Qty_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

         

            string st = UtilsMain.ValidateTextInt(textBox.Text);
            int.TryParse(st, out MyItem.Quantity);
            if (string.IsNullOrEmpty(st))
            {
                st = "0";
            }
            textBox.Text = st;
        }

        private void CalcClick(object sender, RoutedEventArgs e)
        {
            MyItem.NetPrice = CalculateNet();
            SetNetPrice = MyItem.NetPrice;
            tb_it_net.Text = "$" + MyItem.NetPrice.ToString("N2");

            MyItem.SellPrice = CalculatePrice();
            MyItem.Profit = MyItem.SellPrice - MyItem.NetPrice;

            tb_it_sell.Text = "$" + MyItem.SellPrice.ToString("N2");
            tb_it_profit.Text = "$" + MyItem.Profit.ToString("N2");
        }

        private void Percent_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string st = UtilsMain.ValidateTextDecimal(textBox.Text);
            if(string.IsNullOrEmpty(st))
            {
                st = "0";
            }
            textBox.Text = st + "%";
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            MyWind.AddRow(MyItem);
            CloseWindow();
        }
    }
}
