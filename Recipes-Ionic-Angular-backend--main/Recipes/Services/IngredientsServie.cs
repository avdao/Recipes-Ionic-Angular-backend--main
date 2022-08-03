using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Recipes.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipes.Services
{
    public class IngredientsServie : IngredientsInterface
    {

        private RecipesContext rc;



        public IngredientsServie(RecipesContext rc)
        {
            this.rc = rc;
        }


        public void deleteById(int id)
        {
            rc.Ingredients.Remove(rc.Ingredients.Find(id));
            rc.SaveChanges();
            
        }

        public void edit(Ingredient c)
        {
            rc.Ingredients.Update(c);
            rc.SaveChanges();
        }

        public List<Ingredient> getAllCategory()
        {
            return rc.Ingredients.ToList();
        }

        public Ingredient getById(int id)
        {
            return rc.Ingredients.Find(id);
        }

        public void post(Ingredient c)
        {

            rc.Ingredients.Add(c);
            rc.SaveChanges();
        }
    }
}
