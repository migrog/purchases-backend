using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.domain.entities
{
    public class Purchase: EntityBase
    {
        public int UserId { get; set; }
        public double Total { get; set; }
        public DateTime CreateAt { get; set; }
        public string CurrencyTypeEnum { get; set; }

        public void setId(int id)
        {
            Id = id;
        }
    }
}
