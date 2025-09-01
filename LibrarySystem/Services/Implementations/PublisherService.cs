using LibrarySystem.Dtos.PublisherDtos;
using LibrarySystem.Exceptions;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySystem.Services.Implementations
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        public async Task<BasicPublisherDto> AddPublisherAsync(BasicPublisherDto publisherDto)
        {
            if (await publisherRepository.IsExistAsync(publisherDto.Name))
                throw new PublisherAlreadyExistsException("Publisher with the same name already exists.");
            var publisher = new Publisher
            {
                name = publisherDto.Name,
                address = publisherDto.Address,
                contactEmail = publisherDto.ContactEmail,
                phone = publisherDto.Phone
            };
          await publisherRepository.AddAsync(publisher);
           await publisherRepository.SaveChangesAsync();
            return publisherDto;

        }

        public async Task DeletePublisherAsync(int id)
        {
            var publisher =await publisherRepository.GetByIdAsync(id);
            if (publisher == null)
            
                throw new PublisherNotFoundException("Publisher not found");
            if(publisher.Books.Any())
                throw new PublisherHasBooksException("Cannot delete publisher with associated books.");
            await publisherRepository.DeleteAsync(publisher);
            await publisherRepository.SaveChangesAsync();

        }

        public async Task<IEnumerable<BasicPublisherDto>> GetAllPublishersAsync()
        {
            var publishers= await publisherRepository.GetAllAsync();
            return publishers.Select(p => new BasicPublisherDto
            {
                
                Name = p.name,
                Address = p.address,
                ContactEmail = p.contactEmail,
                Phone = p.phone
            }).ToList();
        }

        public async Task<IEnumerable<PublisherWithBooksDto>> GetAllPublishersWithBooksAsync()
        {
            var publishers = await publisherRepository.GetAllWithBooksAsync();
            return publishers.Select(p => new PublisherWithBooksDto
            {
                Name = p.name,
                Address = p.address,
                ContactEmail = p.contactEmail,
                Phone = p.phone,
                Books = p.Books.Select(b => b.title).ToList()

            }).ToList();

            }

        public async Task<BasicPublisherDto> GetPublisherByIdAsync(int id)
        {
            var publisher =await publisherRepository.GetByIdAsync(id);
            if (publisher == null)
                throw new PublisherNotFoundException("Publisher not found");
            return new BasicPublisherDto
            {
                Name = publisher.name,
                Address = publisher.address,
                ContactEmail = publisher.contactEmail,
                Phone = publisher.phone
            };
        }

        public async Task<BasicPublisherDto> GetPublisherByNameAsync(string name)
        {
            var publisher =await publisherRepository.GetByNameAsync(name);
            if (publisher == null)
                throw new PublisherNotFoundException("Publisher not found");
            return new BasicPublisherDto
            {
                Name = publisher.name,
                Address = publisher.address,
                ContactEmail = publisher.contactEmail,
                Phone = publisher.phone
            };
        }

        public async Task<PublisherWithBooksDto> GetPublisherWithBooksAsync(int publisherId)
        {
            var publisher =await publisherRepository.GetWithBooksAsync(publisherId);
            if (publisher == null)
                throw new PublisherNotFoundException("Publisher not found");
            return new PublisherWithBooksDto
            {
                Name = publisher.name,
                Address = publisher.address,
                ContactEmail = publisher.contactEmail,
                Phone = publisher.phone,
                Books = publisher.Books.Select(b => b.title).ToList()
            };

        }

        public Task<bool> IsPublisherExistAsync(string name)
        {
            return publisherRepository.IsExistAsync(name);
        }

        public async Task UpdatePublisherAsync(int id, BasicPublisherDto publisherDto)
        {
            var publisher =await publisherRepository.GetByIdAsync(id);
            if (publisher == null)
                throw new PublisherNotFoundException("Publisher not found");
            publisher.name = publisherDto.Name;
            publisher.address = publisherDto.Address;
            publisher.contactEmail = publisherDto.ContactEmail;
            publisher.phone = publisherDto.Phone;
            publisherRepository.Update(publisher);
            await publisherRepository.SaveChangesAsync();
        }
    }
}
