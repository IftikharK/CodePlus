using CodePlus.API.Data;
using CodePlus.API.Models.Domain;
using CodePlus.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CodePlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public CategoriesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            // Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await dBContext.Categories.AddAsync(category);
            await dBContext.SaveChangesAsync();

            // Domain model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            return Ok(response);
        }
    }
}
