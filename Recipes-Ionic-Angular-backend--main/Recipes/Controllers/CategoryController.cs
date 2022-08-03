using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryInterface recipesService;


        public CategoryController(CategoryInterface recipesInterface)
        {
            recipesService = recipesInterface;
        }

        [HttpGet]
        public List<Category> get()
        {
            return recipesService.getAllCategory();

        }

        [HttpDelete("{id}")]
        public void deleteByid(int id)
        {
            recipesService.deleteById(id);
        }
        [HttpGet("{id}")]
        public Category getByid(int id)
        {
            return recipesService.getById(id);
        }


        [HttpPost]
        public void postData(Category c)
        {
            recipesService.post(c);
        }

        [HttpPut("{id}")]
        public void edit(Category c)
        {
            recipesService.edit(c);
        }






    }
}
