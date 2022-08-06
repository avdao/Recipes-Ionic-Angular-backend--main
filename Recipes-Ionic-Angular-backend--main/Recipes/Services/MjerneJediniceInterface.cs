using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services
{
    public interface MjerneJediniceInterface
    {

        public List<MjerneJedinice> getAllMjerneJedinice();
        public void post(MjerneJedinice c);
        public void edit(MjerneJedinice c);
        public void deleteById(int id);
        public MjerneJedinice getById(int id);
    }
}
