using Recipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services
{
    public class CategoryService : CategoryInterface
    {

        private RecipesContext rc;
        public CategoryService(RecipesContext rc)
        {
            this.rc = rc;
        }

        public void deleteById(int id)
        {

            rc.Categories.Remove(rc.Categories.Find(id));
            rc.SaveChanges();
        }

        public void edit(Category c)
        {
            rc.Categories.Update(c);
            rc.SaveChanges();
        }

        public List<Category> getAllCategory()
        {
            return rc.Categories.ToList();
        }

        public Category getById(int id)
        {
            return rc.Categories.Find(id);
        }

        public void post(Category c)
        {
            rc.Categories.Add(c);
            rc.SaveChanges();
        }
    }
}
