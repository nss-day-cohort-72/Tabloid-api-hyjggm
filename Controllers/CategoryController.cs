using Microsoft.AspNetCore.Mvc;
using Tabloid.Models;
using Tabloid.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Tabloid.Models.DTOs;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private TabloidDbContext _dbContext;

    public CategoryController(TabloidDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize(Roles ="Admin")]
    public IActionResult Get()
    {
        return Ok(_dbContext.Categories
        .OrderBy(c => c.Name)
        .ToList());
    }

    [HttpPost]
    [Authorize(Roles ="Admin")]
    public IActionResult AddNewCategory(CategoryDTO category)
    {
        Category newCategory = new Category
        {
            Id = category.Id,
            Name = category.Name
        };

        _dbContext.Add(newCategory);
        _dbContext.SaveChanges();

        CategoryDTO newCategoryDTO = new CategoryDTO
        {
            Id = newCategory.Id,
            Name = newCategory.Name
        };

        return Created($"/api/category/{category.Id}", newCategoryDTO);

    }



    
}
