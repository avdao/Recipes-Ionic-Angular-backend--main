using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services
{
    public interface CategoryInterface
    {

        public List <Category> getAllCategory();
        public void post(Category c);
        public void edit(Category c);
        public void deleteById(int id);
        public Category getById(int id);
        
    }
}
