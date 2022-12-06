namespace APIAcougue.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public User Customer { get; set; }
        public List<SaleItem> Items { get; set; }

        public double TotalPrice()
        {
            return Items.Sum(item => item.TotalPrice());
        }
    }
}
