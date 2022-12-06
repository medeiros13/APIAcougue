namespace APIAcougue.Models
{
    public class SaleItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
