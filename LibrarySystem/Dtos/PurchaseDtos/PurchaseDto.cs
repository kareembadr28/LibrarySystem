namespace LibrarySystem.Dtos.PurchaseDtos
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BookTitle { get; set; }
        public string CustomerName { get; set; }
    }
}
