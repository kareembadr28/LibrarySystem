using LibrarySystem.Dtos;
using LibrarySystem.Dtos.PurchaseDtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePurchase(CreatePurchaseDto purchaseDto)
        {
            var result = await purchaseService.CreatePurchaseAsync(purchaseDto);
            return Created("",new ApiResponse(true, "Purchase created successfully", result));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            await purchaseService.DeletePurchaseAsync(id);
            return Ok(new ApiResponse(true, "Purchase deleted successfully"));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPurchases()
        {
            var result = await purchaseService.GetAllPurchasesAsync();
            return Ok(new ApiResponse(true, "Purchases retrieved successfully", result));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPurchaseById(int id)
        {
            var result = await purchaseService.GetPurchaseByIdAsync(id);
            return Ok(new ApiResponse(true, "Purchase retrieved successfully", result));
        }

        [HttpGet("by-customer/{customerId}")]
        [Authorize]
        public async Task<IActionResult> GetPurchasesByCustomer(int customerId)
        {
            var result = await purchaseService.GetPurchasesByCustomerAsync(customerId);
            return Ok(new ApiResponse(true, "Purchases retrieved successfully", result));
        }

        [HttpGet("by-book/{bookId}")]
        [Authorize]
        public async Task<IActionResult> GetPurchasesByBook(int bookId)
        {
            var result = await purchaseService.GetPurchasesByBookAsync(bookId);
            return Ok(new ApiResponse(true, "Purchases retrieved successfully", result));
        }

        [HttpGet("between-dates")]
        [Authorize]
        public async Task<IActionResult> GetPurchasesBetweenDates([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await purchaseService.GetPurchasesBetweenDatesAsync(startDate, endDate);
            return Ok(new ApiResponse(true, "Purchases retrieved successfully", result));
        }
    }
}
