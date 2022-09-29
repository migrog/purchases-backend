using System;
using System.Collections.Generic;
using System.Text;

namespace product.domain.entities
{
    public partial class Product : EntityBase
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string CurrencyTypeEnum { get; set; }

    }
}
