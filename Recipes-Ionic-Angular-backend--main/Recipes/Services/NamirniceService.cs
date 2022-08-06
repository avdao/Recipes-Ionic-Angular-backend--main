using Recipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services
{
    public class NamirniceService : NamirniceInterface
    {

        private RecipesContext rc1;


        public NamirniceService(RecipesContext rc1)
        {

            this.rc1 = rc1;
        }
        public void deleteById(int id)
        {
            rc1.Namirnices.Remove(rc1.Namirnices.Find(id));
            rc1.SaveChanges();
        }

        public void edit(Namirnice c)
        {
            rc1.Namirnices.Update(c);
            rc1.SaveChanges();
        }

        public List<Namirnice> getAllNamirnice()
        {
            return rc1.Namirnices.ToList();
        }

        public Namirnice getById(int id)
        {
            return rc1.Namirnices.Find(id);
        }

        public void post(Namirnice c)
        {
            rc1.Namirnices.Add(c);
            rc1.SaveChanges();
        }
    }
}
