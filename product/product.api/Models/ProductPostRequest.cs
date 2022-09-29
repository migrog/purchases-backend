namespace product.api.Models
{
    public class ProductPostRequest
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }

        public string CurrencyTypeEnum { get; set; }
    }
}
