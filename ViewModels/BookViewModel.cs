namespace OnlineBookStoreSystem.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public DateTimeOffset CreatedDate { get { return DateTimeOffset.UtcNow; } }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
      

    }
}
