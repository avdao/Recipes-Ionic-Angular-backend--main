
using Recipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services
{
    public class SkladisteService : SkladisteInterface
    {

        private RecipesContext rc1;


        public SkladisteService(RecipesContext rc1)
        {

            this.rc1 = rc1;
        }
        public void DeleteSkladiste(int id)
        {
            rc1.Skladistes.Remove(rc1.Skladistes.Find(id));
            rc1.SaveChanges();
        }

        public void edit(Skladiste s)
        {
            rc1.Skladistes.Update(s);
            rc1.SaveChanges();
        }

        public List<Skladiste> get()
        {

            return rc1.Skladistes.OrderByDescending(ob => ob.IspodMin).ThenBy(ob2 => ob2.FkNamirniceNavigation.Naziv).ToList();
            // List<Namirnice> n1 = new List<Namirnice>();
            // List<Skladiste> n2= new List<Skladiste>();
            // List<Skladiste> s = new List<Skladiste>();
            // s=rc1.Skladistes.ToList();
            // for(int i= 0; i < s.Count; i++)
            // {
            //     n1 = rc1.Namirnices.Where(o => o.Id == s[i].FkNamirnice).ToList();

            // }
            // n1 = n1.OrderBy(o => o.Naziv.ToLower()).ToList();
            // for (int i = 0; i < n1.Count; i++)
            // {
            //     n2 = rc1.Skladistes.Where(o => o.FkNamirnice== n1[i].Id).ToList();

            // }
            //// n2 = n2.OrderBy(o => o.FkNamirnice).ToList();



            // return rc1.Skladistes.OrderByDescending(ob => ob.IspodMin).ThenBy(n2=>n2.FkNamirnice).ToList();
            // // return rc1.Skladistes.OrderByDescending(ob => ob.IspodMin).ToList();

        }

        public Skladiste getById(int id)
        {
            return rc1.Skladistes.Find(id);
        }

        public void post(Skladiste s)
        {
            rc1.Skladistes.Add(s);
            rc1.SaveChanges();
        }

        public string returnV(string data)
        {
            throw new System.NotImplementedException();
        }
    }
}
