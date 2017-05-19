using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteProgWPF
{
    public class CSI_Quote
    {
        //Base Info
        public string Date;
        public string QuoteNumber;

        //Customer Info
        public string CustName;
        public string CustCompany;
        public string CustPhone;
        public string CustEmail;
        public string CustLoc;

        //Line Items
        public List<CSI_Item> LineItems;

        //Additional Info
        public string LeadTiime;
        public string FreightTerms;
        public string FOBLocation;
        public string PaymentTerms;
        public string Expiration;

        public string QuoteOwner;
    }
}
