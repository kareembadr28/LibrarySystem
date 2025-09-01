using LibrarySystem.Dtos.PublisherDtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<BasicPublisherDto> AddPublisherAsync(BasicPublisherDto publisherDto);

        Task<IEnumerable<BasicPublisherDto>> GetAllPublishersAsync();

        Task<BasicPublisherDto> GetPublisherByIdAsync(int id);

        Task<BasicPublisherDto> GetPublisherByNameAsync(string name);

        Task<PublisherWithBooksDto> GetPublisherWithBooksAsync(int publisherId);

        Task<IEnumerable<PublisherWithBooksDto>> GetAllPublishersWithBooksAsync();

        Task UpdatePublisherAsync(int id, BasicPublisherDto publisherDto);

        Task DeletePublisherAsync(int id);

        Task<bool> IsPublisherExistAsync(string name);
    }
}
