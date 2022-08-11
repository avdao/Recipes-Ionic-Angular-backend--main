using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkladisteController : ControllerBase
    {

        private readonly SkladisteInterface namirnice;


        public SkladisteController(SkladisteInterface namirnice)
        {
            this.namirnice = namirnice;
        }



        [HttpGet]
        public List<Skladiste> get()
        {
            return namirnice.get();

        }


        [HttpDelete("{id}")]
        public void deleteByid(int id)
        {
            namirnice.DeleteSkladiste(id);
        }
        [HttpGet("{id}")]
        public Skladiste getByid(int id)
        {
            return namirnice.getById(id);
        }


        [HttpPost]
        public void postData(Skladiste c)
        {
            namirnice.post(c);
        }

        [HttpPut("{id}")]
        public void edit(Skladiste c)
        {
            namirnice.edit(c);
        }

    }
}
