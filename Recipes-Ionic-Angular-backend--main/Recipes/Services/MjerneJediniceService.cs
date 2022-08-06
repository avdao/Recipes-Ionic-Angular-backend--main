using Recipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services
{
    public class MjerneJediniceService : MjerneJediniceInterface
    {
        

        private RecipesContext rc1;


        public MjerneJediniceService(RecipesContext rc1)
        {
            
            this.rc1 = rc1;
        }
        public void deleteById(int id)
        {
            rc1.MjerneJedinices.Remove(rc1.MjerneJedinices.Find(id));
            rc1.SaveChanges();
        }

        public void edit(MjerneJedinice c)
        {
            rc1.MjerneJedinices.Update(c);
            rc1.SaveChanges();
        }

     

        public List<MjerneJedinice> getAllMjerneJedinice()
        {
            return rc1.MjerneJedinices.ToList();
        }

        public MjerneJedinice getById(int id)
        {
            return rc1.MjerneJedinices.Find(id);
        }

        public void post(MjerneJedinice c)
        {
            rc1.MjerneJedinices.Add(c);
            rc1.SaveChanges();
        }
    }
}
