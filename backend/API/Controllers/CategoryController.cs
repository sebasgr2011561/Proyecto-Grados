using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _categoryApplication.ListCategories(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _categoryApplication.ListSelectCategories();
            return Ok(response);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var response = await _categoryApplication.GetCategoryById(categoryId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequestDto categoryRequestDto)
        {
            var response = await _categoryApplication.CreateCategory(categoryRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryRequestDto categoryRequestDto)
        {
            var response = await _categoryApplication.UpdateCategory(categoryId, categoryRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{categoryId:int}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var response = await _categoryApplication.DeleteCategory(categoryId);
            return Ok(response);
        }
    }
}

