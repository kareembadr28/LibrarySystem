using LibrarySystem.Dtos.PurchaseDtos;

namespace LibrarySystem.Dtos.CustomerDtos
{
    public class CustomerWithPurchasesDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<PurchaseDto> Purchases { get; set; } = new List<PurchaseDto>();
    }
}
