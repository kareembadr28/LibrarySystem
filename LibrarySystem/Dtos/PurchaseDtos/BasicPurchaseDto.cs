namespace LibrarySystem.Dtos.PurchaseDtos
{
    public class BasicPurchaseDto
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
    }
}
