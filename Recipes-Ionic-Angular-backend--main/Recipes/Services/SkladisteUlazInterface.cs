using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using System.Collections.Generic;
namespace Recipes.Services
{
    public interface SkladisteUlazInterface
    {

        public string returnV(string data);

        public List<SkladisteUlaz> get();

        public SkladisteUlaz getById(int id);
        public void DeleteSkladiste(int id);


        public void post(SkladisteUlaz s);
        public void edit(SkladisteUlaz s);
    }
}
