namespace product.api.Models
{
    public class ProductGetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }

        public string CurrencyTypeEnum { get; set; }
    }
}
