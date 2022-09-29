using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.domain.entities
{
    public partial class PurchaseDetail: EntityBase
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
