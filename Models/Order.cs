namespace OnlineBookStoreSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public IList<Book> Books { get; set; }


    }
}
