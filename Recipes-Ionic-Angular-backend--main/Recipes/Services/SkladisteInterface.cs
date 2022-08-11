using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services
{
    public interface SkladisteInterface
    {
        public string returnV(string data);

        public List<Skladiste> get();

        public Skladiste getById(int id);
        public void DeleteSkladiste(int id);


        public void post(Skladiste s);
        public void edit(Skladiste s);
    }
}