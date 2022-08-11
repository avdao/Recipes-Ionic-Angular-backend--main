using Newtonsoft.Json.Linq;
using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services
{
    public interface NamirniceInterface
    {
        public List<Namirnice> getAllNamirnice();
        public void post(JObject data);
        public void edit(Namirnice c);
        public void deleteById(int id);
        public Namirnice getById(int id);
    }
}
