using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteProgWPF
{
    //Need to move markup & net calculations to a different class, only needed when doing calculations
    public class CSI_Item
    {

        public string ItemName = "CSI00000";
        public int Quantity = 1;
        public UnitOfMeasure UOM = UnitOfMeasure.EA;
        public string Description = "No description.";
        public decimal SellPrice;
        // public double NetPrice;
        //  private double _sellPrice;
        //  public double Markup;

        public decimal ListPrice;
        public decimal NetPrice;
        public decimal Markup;
        public decimal Profit;
        private string _stPrice = "";
       

        
        public string UnitPrice
        {
            get
            {
                _stPrice = SellPrice.ToString("C2");
                return _stPrice;
            }
        }

        public string ExtPrice
        {
            get
            {
                return (SellPrice * Quantity).ToString("C2");
            }
        }


        public CSI_Item()
        {

        }

        public CSI_Item(int num)
        {
            Random r;
            ItemName = "New Item";
            Description = "Simple description here...";
            UOM = UnitOfMeasure.EA;

            r = new Random();
            Quantity = r.Next(1, 150);
            r = new Random();
            SellPrice = 45.31m + (45 * (decimal)r.NextDouble()); ;

        }
        

    }


    public enum UnitOfMeasure
    {
        EA,
        CASE,
        BAG,
        ROLL,
        PACK,
        SET,
        LB,
        FT
    }
}
