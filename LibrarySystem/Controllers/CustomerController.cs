using LibrarySystem.Dtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet("GetCustomerWithBorrows/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCustomerWithBorrows(int id)
        {
            var customer = await customerService.GetCustomerWithBorrowsAsync(id);
            return Ok(new ApiResponse(true,"Customer found",customer));
        }

        [HttpGet("GetCustomerWithPurchases/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCustomerWithPurchases(int id)
        {
            var customer = await customerService.GetCustomerWithPurchasesAsync(id);
            return Ok(new ApiResponse(true, "Customer found", customer));
        }

        [HttpGet("GetByEmail/{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var customer = await customerService.GetByEmailAsync(email);
            if (customer == null)
            {
                return NotFound(new ApiResponse(false, "Customer not found"));
            }
            return Ok(new ApiResponse(true, "Customer found", customer));
        }

        [HttpGet("GetByUserName/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var customer = await customerService.GetByUserNameAsync(username);
            if(customer == null)
            {
                return NotFound(new ApiResponse(false, "Customer not found"));
            }
            return Ok(new ApiResponse(true, "Customer found", customer));
        }

        [HttpGet("IsExist/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IsExist(string username)
        {
            var isExist = await customerService.IsExistAsync(username);
            return Ok(new ApiResponse(true, "Check completed", isExist));
        }

    }
}
