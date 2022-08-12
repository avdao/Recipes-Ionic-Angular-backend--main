using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Recipes.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
            Ingredient ingredient = rc.Ingredients.Find(id);
;
            Skladiste storage = rc.Skladistes.Where(obj => obj.FkNamirnice == ingredient.FkNaziv).First();
            storage.Kolicina -= ingredient.Kolicina;
            storage.IspodMin= storage.Kolicina < storage.MinKolicina;
            rc.Ingredients.Remove(ingredient);
            rc.SaveChanges();

        }

        public Ingredient c123(int n)
        {
            return rc.Ingredients.Find(n);


        }


        public  void edit(Ingredient c)
        {
            Skladiste storage = new Skladiste();
            int brojId = c.Id;
            Ingredient c2 = c123(brojId);




            decimal c3 = c2.Kolicina;
                //Update kolicinu u Skladistu
                storage = rc.Skladistes.Where(o => o.FkNamirnice == c.FkNaziv).First();
                storage.Kolicina+= c.Kolicina - c3;
            
                storage.IspodMin = storage.Kolicina < storage.MinKolicina;
                rc.Skladistes.Update(storage);

            rc.Entry(c2).CurrentValues.SetValues(c);
             //rc.Ingredients.Update(c);
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
