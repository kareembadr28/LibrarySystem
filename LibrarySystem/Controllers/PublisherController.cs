using LibrarySystem.Dtos;
using LibrarySystem.Dtos.PublisherDtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPublisher(BasicPublisherDto publisherDto)
        {
            var result = await publisherService.AddPublisherAsync(publisherDto);
            return Created("",new ApiResponse(true,"Publisher Added Successfully",result));
        }

        [HttpGet("getAll")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> GetAllPublishers()
        {
            var result = await publisherService.GetAllPublishersAsync();
            return Ok(new ApiResponse(true, "Publishers Retrieved Successfully", result));
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            await publisherService.DeletePublisherAsync(id);
            return Ok(new ApiResponse(true, "Publisher Deleted Successfully"));
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePublisher(int id, BasicPublisherDto publisherDto)
        {
            await publisherService.UpdatePublisherAsync(id, publisherDto);
            return Ok(new ApiResponse(true, "Publisher Updated Successfully"));
        }

        [HttpGet("getAllWithBooks")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> GetAllPublishersWithBooks()
        {
            var result = await publisherService.GetAllPublishersWithBooksAsync();
            return Ok(new ApiResponse(true, "Publishers with Books Retrieved Successfully", result));
        }

        [HttpGet("getById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var result = await publisherService.GetPublisherByIdAsync(id);
            return Ok(new ApiResponse(true, "Publisher Retrieved Successfully", result));
        }

        [HttpGet("getByName/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPublisherByName(string name)
        {
            var result = await publisherService.GetPublisherByNameAsync(name);
            return Ok(new ApiResponse(true, "Publisher Retrieved Successfully", result));
        }

        [HttpGet("getWithBooks/{publisherId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPublisherWithBooks(int publisherId)
        {
            var result = await publisherService.GetPublisherWithBooksAsync(publisherId);
            return Ok(new ApiResponse(true, "Publisher with Books Retrieved Successfully", result));
        }

        [HttpGet("isExist/{name}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> IsPublisherExist(string name)
        {
            var result = await publisherService.IsPublisherExistAsync(name);
            return Ok(new ApiResponse(true, "Existence Check Completed", result));
        }



    }
}
