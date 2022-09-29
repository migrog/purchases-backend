using System.Collections.Generic;

namespace purchase.api.Models
{
    public class PurchasePutRequest
    {
        public PurchasePut Purchase { get; set; }
        public List<PurchaseDetailPut> Detail { get; set; }    
    }
    public class PurchasePut
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CurrencyTypeEnum { get; set; }
    }
    public class PurchaseDetailPut
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
