using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.domain.entities.dtos
{
    public class PurchasePrintResponse
    {
        public PurchasePrint Purchase { get; set; }
        public List<PurchaseDetailPrint> Detail { get; set; }
    }
    public class PurchasePrint
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
    }
    public class PurchaseDetailPrint
    {
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }

    }
}
