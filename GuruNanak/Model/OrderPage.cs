namespace GuruNanak.Model
{
    public class OrderPage
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quatity { get; set; } = 1;
        public decimal TotalPrice { get; set; }
    }
}
