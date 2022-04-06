namespace FunBooksAndVideos.Models
{
    public class Order
    {
        public int POId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public string[] ItemLines { get; set; }
    }
}
