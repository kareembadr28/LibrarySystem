using LibrarySystem.Dtos.BorrowDtos;

namespace LibrarySystem.Dtos.CustomerDtos
{
    public class CustomerWithBorrowsDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<BorrowDto> Borrows { get; set; } = new List<BorrowDto>();
    }
}
