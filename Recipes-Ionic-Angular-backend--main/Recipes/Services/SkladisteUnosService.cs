

using Recipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services
{
    public class SkladisteUnosService: SkladisteUlazInterface
    {

        private RecipesContext rc1;


        public SkladisteUnosService(RecipesContext rc1)
        {

            this.rc1 = rc1;
        }
        public void DeleteSkladiste(int id)
        {
            rc1.SkladisteUlazs.Remove(rc1.SkladisteUlazs.Find(id));
            rc1.SaveChanges();
        }

        public void edit(SkladisteUlaz s)
        {
            rc1.SkladisteUlazs.Update(s);
            rc1.SaveChanges();
        }

        public List<SkladisteUlaz> get()

        {

            return rc1.SkladisteUlazs.ToList();
        }

        public SkladisteUlaz getById(int id)
        {
            return rc1.SkladisteUlazs.Find(id);
        }

        public void post(SkladisteUlaz s)
        {


            Skladiste storage = rc1.Skladistes.Where(o => o.FkNamirnice == s.FkNamirncie).First();
            storage.Kolicina+=s.Kolicina;
            storage.IspodMin = storage.Kolicina < storage.MinKolicina;
            rc1.Skladistes.Update(storage);
            s.DatumUnosa = System.DateTime.Now;
            rc1.SkladisteUlazs.Add(s);
            rc1.SaveChanges();
        }

        public string returnV(string data)
        {
            throw new System.NotImplementedException();
        }
    }
}
