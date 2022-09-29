using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.domain.entities
{
    public partial class Product: EntityBase
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyTypeEnum { get; set; }

    }
}
