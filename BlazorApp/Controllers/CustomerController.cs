using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public async Task<List<Customer>> Get(int page = 1, int pageSize = 10)
    {
        return await _customerService.GetPagedAsync(page, pageSize);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        await _customerService.CreateAsync(customer);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Customer customer)
    {
        await _customerService.UpdateAsync(id, customer);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _customerService.DeleteAsync(id);
        return NoContent();
    }
}

