using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.domain.entities
{
    public partial class EnumerateType: EntityBase
    {
        public string Description { get; set; }
        public int Code { get; set; }
    }
}
