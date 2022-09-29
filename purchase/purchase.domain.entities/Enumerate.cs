using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.domain.entities
{
    public partial class Enumerate: EntityBase
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public int EnumerateTypeCode { get; set; }
    }
}
