using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services
{
    public interface IngredientsInterface
    {

        public List<Ingredient> getAllCategory();
        public void post(Ingredient c);
        public void edit(Ingredient c);
        public void deleteById(int id);
        public Ingredient getById(int id);
    }
}
