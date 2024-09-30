namespace MvcAdoCrud.Models
{
    public class CustomerProduct
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
