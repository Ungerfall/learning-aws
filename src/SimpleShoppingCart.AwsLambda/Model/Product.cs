namespace SimpleShoppingCart.Model
{
    public class Product
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}