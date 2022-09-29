using System.Collections.Generic;
using purchase.domain.entities;

namespace purchase.api.Models
{
    public class PurchaseResponse
    {
        public Purchase Purchase { get; set; }
        public List<PurchaseDetail> Detail { get; set; }
    }
}
