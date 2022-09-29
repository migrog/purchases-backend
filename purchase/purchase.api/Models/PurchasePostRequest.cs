using System;
using System.Collections.Generic;
using purchase.domain.entities;

namespace purchase.api.Models
{
    public class PurchasePostRequest
    {
        public PurchasePost Purchase { get; set; }
        public List<PurchaseDetailPost> Detail { get;set; }
    }
    public class PurchasePost
    {
        public int UserId { get; set; }
        public double Total { get; set; }
        public string CurrencyTypeEnum { get; set; }
    }
    public class PurchaseDetailPost
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
