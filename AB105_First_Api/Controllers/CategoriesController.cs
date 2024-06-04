using AB105_First_Api.DAL;
using AB105_First_Api.DTOs.CategoriesDto;
using AB105_First_Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AB105_First_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            var category=_context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if(category==null) return NotFound();
            return StatusCode(StatusCodes.Status202Accepted,category);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _context.Categories.ToList();
            return StatusCode(StatusCodes.Status200OK, category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto categoryDto)
        {
            var category = new Category()
            {
                Name = categoryDto.Name,
            };
           await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto dto)
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == dto.Id);
            if (category is null) return BadRequest();
            category.Name = dto.Name;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK,category);

        }
    }
}
