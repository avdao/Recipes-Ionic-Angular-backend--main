

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
    public class RecipesService : RecipesInterface
    {
   
        private  RecipeContext rc;

        private RecipesContext rc1;


        public RecipesService(RecipeContext rc,RecipesContext rc1)
        {
            this.rc = rc;
            this.rc1=rc1;
        }

      /*  public string returnV(string data)
        {
            return data;
        }*/

        public List<Recipe> get(string search="")
        {
            List<Recipe> recipes = rc.Recipes.ToList();
            foreach (var recipe in recipes)
            {
                recipe.Ingredients = rc1.Ingredients.Where(o => o.RecipesId == recipe.RecipesId).ToList();
            }
            return rc.Recipes.Where(x => x.Title.Contains(search)|| string.IsNullOrEmpty(search)).ToList();
           // return rc.Recipes.ToList();
        }
    
        public string returnV(string data)
        {
            return data;
        }

        public Recipe getById(int id)
        {

            Recipe recipe = rc.Recipes.Find(id);
;
            recipe.Ingredients = rc1.Ingredients.Where(o => o.RecipesId== recipe.RecipesId).ToList();

            return recipe;
        }





        public void DeleteRecipe(int id)
        {
            foreach (var ingredient in getById(id).Ingredients)
            {
                rc.Ingredients.Remove(ingredient);
                Skladiste storage = rc.Skladistes.Where(o => o.FkNamirnice== ingredient.FkNaziv).First();
                storage.Kolicina -= ingredient.Kolicina;
                storage.IspodMin = storage.Kolicina < storage.MinKolicina;
                rc.Skladistes.Update(storage);
            }

            rc.Recipes.Remove(getById(id));
            rc.SaveChanges();
        }

        //        public void post(Recipe recipe)
        //        {

        //            rc.Recipes.Add(recipe);
        //            rc.SaveChanges();



        ///*
        //            foreach (var ingredient in recipe.Ingredients.ToArray())
        //            {
        //                ingredient.RecipesId = recipe.RecipesId;
        //                rc1.Ingredients.Add(ingredient);
        //                rc1.SaveChanges();

        //            }
        //*/




        //        }

        public void post(Recipe recipe)
        {
            Skladiste storage = new Skladiste();
            
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.FkNazivNavigation= rc1.Namirnices.Find(ingredient.Id);

                //Update kolicinu u Skladistu
                storage = rc.Skladistes.Where(o => o.FkNamirnice == ingredient.FkNaziv).First();
                storage.Kolicina += ingredient.Kolicina;
                storage.IspodMin = storage.Kolicina< storage.MinKolicina;
                rc.Skladistes.Update(storage);
            }

            rc.Recipes.Add(recipe);
            rc.SaveChanges();
        }


        public void edit(Recipe recipe)
        {
           
            Recipe oldRecipe = getById(recipe.RecipesId);

            //Remove old quantities
            foreach (var ingredient in oldRecipe.Ingredients)
            {
                ingredient.FkNazivNavigation = rc1.Namirnices.Find(ingredient.FkNaziv);


                Skladiste storage = rc1.Skladistes.Where(o => o.FkNamirnice == ingredient.FkNaziv).First();
                storage.Kolicina -= ingredient.Kolicina;
                storage.IspodMin = storage.Kolicina< storage.MinKolicina;
                rc1.Skladistes.Update(storage);
            }

            //Add new quantities from recipe ingredient to storage
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient. FkNazivNavigation = rc1.Namirnices.Find(ingredient.FkNaziv);

                Skladiste storage = rc1.Skladistes.Where(o => o.FkNamirnice == ingredient.FkNaziv).First();
                storage.Kolicina += ingredient.Kolicina;
                storage.IspodMin = storage.Kolicina < storage.MinKolicina;
                rc1.Skladistes.Update(storage);
            }






           rc1.Update(recipe);
            rc1.SaveChanges();
        }

      
    }
}
