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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

namespace QuoteProgWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public CSI_Item nItem;
        public ItemWindow Wind_Item = null;
        public List<CSI_Item> CurItems;

        public int CurRow = 0;

        public MainWindow()
        {
            nItem = new CSI_Item(0);
            CurItems = new List<CSI_Item>();
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRow(new CSI_Item(0));
        }

        public void OpenItemWindow()
        {
            if(Wind_Item == null)
            {
                ItemWindow iWind = new ItemWindow();
                // Point point = Mouse.GetPosition(Application.Current.MainWindow);
                iWind.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                iWind.Owner = this;
                iWind.MyWind = this;
                Wind_Item = iWind;
                iWind.Show();
            }
            
        }

        private void OpenItemClick(object sender, RoutedEventArgs e)
        {
            OpenItemWindow();
        }

        public void AddLineItem(object sender, RoutedEventArgs e)
        {
            CSI_Item rItem = new CSI_Item(0);



            //int n_qty;
            //double n_uprice;
         
            //int.TryParse(tb_qty_new.Text, out n_qty);
            //double.TryParse(ValidateTextNumeric(tb_uprice_new.Text), out n_uprice);

            //rItem.ItemName = tb_item_new.Text;
            //rItem.Description = tb_desc_new.Text;
            //rItem.Quantity = n_qty;
            //rItem.SellPrice = n_uprice;

            AddRow(rItem);
            
        }

        public void AddRow(CSI_Item cItem)
        {

            StackPanel sp_cont_top = new StackPanel();

            Grid grd_cont = new Grid();
            ColumnDefinition cd_Item = new ColumnDefinition();
            ColumnDefinition cd_Qty = new ColumnDefinition();
            ColumnDefinition cd_UOM = new ColumnDefinition();
            ColumnDefinition cd_UPrice = new ColumnDefinition();
            ColumnDefinition cd_ExtPrice = new ColumnDefinition();

            cd_Item.MinWidth = 175;
            cd_Qty.MinWidth = 64;
            cd_Qty.MaxWidth = 64;
            cd_UOM.MinWidth = 64;
            cd_UOM.MaxWidth = 64;
            cd_UPrice.MinWidth = 100;
            cd_UPrice.MaxWidth = 100;
            cd_ExtPrice.MinWidth = 100;
            cd_ExtPrice.MaxWidth = 100;

            grd_cont.ColumnDefinitions.Add(cd_Item);
            grd_cont.ColumnDefinitions.Add(cd_Qty);
            grd_cont.ColumnDefinitions.Add(cd_UOM);
            grd_cont.ColumnDefinitions.Add(cd_UPrice);
            grd_cont.ColumnDefinitions.Add(cd_ExtPrice);

            RowDefinition mRow = new RowDefinition();
            mRow.MinHeight = 25;
            mRow.MaxHeight = 25;

            grd_cont.RowDefinitions.Add(mRow);

            Label lab_Item = new Label();
            grd_cont.Children.Add(lab_Item);
            lab_Item.Content = cItem.ItemName;
            lab_Item.SetValue(Grid.ColumnProperty, 0);
            lab_Item.Padding = new Thickness(5, 5, 5, 0);
            lab_Item.VerticalContentAlignment = VerticalAlignment.Bottom;
            lab_Item.FontWeight = FontWeights.Bold;

            Label lab_Qty = new Label();
            grd_cont.Children.Add(lab_Qty);
            lab_Qty.Content = cItem.Quantity.ToString("N0"); ;
            lab_Qty.SetValue(Grid.ColumnProperty, 1);
            lab_Qty.Padding = new Thickness(5, 5, 5, 0);
            lab_Qty.HorizontalContentAlignment = HorizontalAlignment.Center;
            lab_Qty.VerticalContentAlignment = VerticalAlignment.Bottom;
            lab_Qty.FontWeight = FontWeights.Bold;

            Label lab_UOM = new Label();
            grd_cont.Children.Add(lab_UOM);
            lab_UOM.Content = cItem.UOM.ToString(); 
            lab_UOM.SetValue(Grid.ColumnProperty, 2);
            lab_UOM.Padding = new Thickness(5, 5, 5, 0);
            lab_UOM.HorizontalContentAlignment = HorizontalAlignment.Center;
            lab_UOM.VerticalContentAlignment = VerticalAlignment.Bottom;
            lab_UOM.FontWeight = FontWeights.Bold;

            Label lab_UPrice = new Label();
            grd_cont.Children.Add(lab_UPrice);
            lab_UPrice.Content = cItem.UnitPrice;
            lab_UPrice.Padding = new Thickness(5, 5, 5, 0);
            lab_UPrice.VerticalContentAlignment = VerticalAlignment.Bottom;
            lab_UPrice.SetValue(Grid.ColumnProperty, 3);
            lab_UPrice.FontWeight = FontWeights.Bold;

            Label lab_ExtPrice = new Label();
            grd_cont.Children.Add(lab_ExtPrice);
            lab_ExtPrice.Content = cItem.ExtPrice;
            lab_ExtPrice.Padding = new Thickness(5, 5, 5, 0);
            lab_ExtPrice.VerticalContentAlignment = VerticalAlignment.Bottom;
            lab_ExtPrice.SetValue(Grid.ColumnProperty, 4);
            lab_ExtPrice.FontWeight = FontWeights.Bold;

            sp_cont_top.Children.Add(grd_cont);

            Label lab_desc = new Label();
            lab_desc.Content = cItem.Description;
            lab_desc.HorizontalAlignment = HorizontalAlignment.Left;
            lab_desc.Margin = new Thickness(10, 0, 0, 0);
            Binding dBind = new Binding("ActualWidth");
            dBind.Source = col_item;
            lab_desc.SetBinding(WidthProperty, dBind);

            sp_cont_top.Children.Add(lab_desc);

            sp_main.Children.Add(sp_cont_top);
            //RowDefinition rD = new RowDefinition();
            //rD.MaxHeight = 25;
            //rD.MinHeight = 25;
            //ItemGrid.RowDefinitions.Add(rD);
            ////Item Name
            //TextBox tbItem = new TextBox();
            //tbItem.Margin = new Thickness(0);
            //tbItem.Padding = new Thickness(0);
            //tbItem.VerticalContentAlignment = VerticalAlignment.Center;
            //tbItem.TextWrapping = TextWrapping.Wrap;
            //tbItem.BorderBrush = Brushes.Black;
            //tbItem.BorderThickness = new Thickness(1, 0, 1, 1);
            //tbItem.Text = cItem.ItemName;
            //ItemGrid.Children.Add(tbItem);

            //tbItem.SetValue(Grid.RowProperty, CurRow);
            //tbItem.SetValue(Grid.ColumnProperty, 0);

            ////Quantity
            //TextBox tbQty = new TextBox();
            //tbQty.Margin = new Thickness(0);
            //tbQty.Padding = new Thickness(0);
            //tbQty.VerticalContentAlignment = VerticalAlignment.Center;
            //tbQty.HorizontalContentAlignment = HorizontalAlignment.Center;
            //tbQty.TextWrapping = TextWrapping.Wrap;
            //tbQty.BorderBrush = Brushes.Black;
            //tbQty.BorderThickness = new Thickness(0, 0, 0, 1);
            //tbQty.LostFocus += Validate_Quantity;
            //ItemGrid.Children.Add(tbQty);
            //tbQty.Text = cItem.Quantity.ToString("N0");
            //tbQty.SetValue(Grid.RowProperty, CurRow);
            //tbQty.SetValue(Grid.ColumnProperty, 1);

            ////UOM
            //TextBox tbUOM = new TextBox();
            //tbUOM.Margin = new Thickness(0);
            //tbUOM.Padding = new Thickness(0);
            //tbUOM.VerticalContentAlignment = VerticalAlignment.Center;
            //tbUOM.TextWrapping = TextWrapping.Wrap;
            //tbUOM.HorizontalContentAlignment = HorizontalAlignment.Center;
            //tbUOM.BorderBrush = Brushes.Black;
            //tbUOM.BorderThickness = new Thickness(1, 0, 0, 1);
            //tbUOM.Text = cItem.UOM.ToString();
            //ItemGrid.Children.Add(tbUOM);

            //tbUOM.SetValue(Grid.RowProperty, CurRow);
            //tbUOM.SetValue(Grid.ColumnProperty, 2);

            ////Description
            //TextBox tbDesc = new TextBox();
            //tbDesc.Margin = new Thickness(0);
            //tbDesc.Padding = new Thickness(0);
            //tbDesc.VerticalContentAlignment = VerticalAlignment.Center;
            //tbDesc.TextWrapping = TextWrapping.NoWrap;
            //tbDesc.BorderBrush = Brushes.Black;
            //tbDesc.BorderThickness = new Thickness(1, 0, 0, 1);
            //tbDesc.Text = cItem.Description;

            //ItemGrid.Children.Add(tbDesc);

            //tbDesc.SetValue(Grid.RowProperty, CurRow);
            //tbDesc.SetValue(Grid.ColumnProperty, 3);

            ////Unit Price
            //TextBox tbUPrice = new TextBox();
            //tbUPrice.Margin = new Thickness(0);
            //tbUPrice.Padding = new Thickness(0);
            //tbUPrice.VerticalContentAlignment = VerticalAlignment.Center;
            //tbUPrice.TextWrapping = TextWrapping.Wrap;
            //tbUPrice.BorderBrush = Brushes.Black;
            //tbUPrice.BorderThickness = new Thickness(1, 0, 0, 1);
            //tbUPrice.LostFocus += TextBox_Validate;
            //tbUPrice.Text = cItem.UnitPrice;
            //ItemGrid.Children.Add(tbUPrice);

            //tbUPrice.SetValue(Grid.RowProperty, CurRow);
            //tbUPrice.SetValue(Grid.ColumnProperty, 4);

            ////Extended Price
            //TextBox tbExtPrice = new TextBox();
            //tbExtPrice.Margin = new Thickness(0);
            //tbExtPrice.Padding = new Thickness(0);
            //tbExtPrice.VerticalContentAlignment = VerticalAlignment.Center;
            //tbExtPrice.TextWrapping = TextWrapping.Wrap;
            //tbExtPrice.BorderBrush = Brushes.Black;
            //tbExtPrice.BorderThickness = new Thickness(1, 0, 1, 1);
            //tbExtPrice.AllowDrop = false;
            //tbExtPrice.IsHitTestVisible = false;
            //tbExtPrice.Focusable = false;
            //tbExtPrice.Text = cItem.ExtPrice;
            ////tbExtPrice.LostFocus += TextBox_Validate;
            //ItemGrid.Children.Add(tbExtPrice);

            //tbExtPrice.SetValue(Grid.RowProperty, CurRow);
            //tbExtPrice.SetValue(Grid.ColumnProperty, 5);
            //CurRow++;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|0(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$";
            //string substitution = @"";

            Regex regex = new Regex(pattern);
            //string result = regex.Replace(e.Text, substitution, 1);
        }

        //Create document method
        private void CreateDocument()
        {
            try
            {
                //Create an instance for word app
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //Set animation status for word application
                winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.
                winword.Visible = false;

                //Create a missing variable for missing value
                object missing = System.Reflection.Missing.Value;

                //Create a new document
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Add header into the document
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Header text goes here";
                }

                //Add the footers into the document
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Footer text goes here";
                }

                //adding text to document
                document.Content.SetRange(0, 0);
                document.Content.Text = "This is test document " + Environment.NewLine;

                //Add paragraph with Heading 1 style
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Heading 1";
                para1.Range.set_Style(ref styleHeading1);
                para1.Range.Text = "Para 1 text";
                para1.Range.InsertParagraphAfter();

                //Add paragraph with Heading 2 style
                Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading2 = "Heading 2";
                para2.Range.set_Style(ref styleHeading2);
                para2.Range.Text = "Para 2 text";
                para2.Range.InsertParagraphAfter();

                //Create a 5X5 table and insert some dummy record
                Word.Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);
                firstTable.Borders.Enable = 1;
                foreach (Word.Row row in firstTable.Rows)
                {
                    foreach (Word.Cell cell in row.Cells)
                    {
                        //Header row
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
                            cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                            //Center alignment for the Header cells
                            cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        }
                        //Data row
                        else
                        {
                            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                    }
                }

                //Save the document
                object filename = @"z:\Chuck\temp1.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
                MessageBox.Show("Document created successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Validate_Quantity(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            //Int32 selectionStart = textBox.SelectionStart;
            //Int32 selectionLength = textBox.SelectionLength;

            //string newText = String.Empty;
            //foreach (Char c in textBox.Text.ToCharArray())
            //{
            //    if (Char.IsDigit(c) || Char.IsControl(c))
            //    {
            //        newText += c;
            //    }
            //}
            //textBox.Text = newText;
            //textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
            string st = UtilsMain.ValidateTextDecimal(textBox.Text);
            textBox.Text = st;
        }

        private void TextBox_Validate(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            //Int32 selectionStart = textBox.SelectionStart;
            //Int32 selectionLength = textBox.SelectionLength;

            //string newText = String.Empty;
            ////string newText = textBox.Text;
            //float val = 0.00f;
            //newText = UtilsMain.ValidateTextDecimal(textBox.Text);
            //float.TryParse(newText, out val);
            //textBox.Text = "$" + string.Format("{0:N2}", val);
            //Console.WriteLine(string.Format("{0:N2}", val));
            //textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart + 1 : textBox.Text.Length;
            string st = UtilsMain.ValidateTextDecimal(textBox.Text);
            textBox.Text = st;
            UtilsMain.ParseCurrency(textBox);
        }

private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Validate(sender, e);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
