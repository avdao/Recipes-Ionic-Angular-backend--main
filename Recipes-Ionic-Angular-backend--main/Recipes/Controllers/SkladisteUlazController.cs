using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkladisteUlazController : ControllerBase
    {

        private readonly SkladisteUlazInterface namirnice;


        public SkladisteUlazController(SkladisteUlazInterface namirnice)
        {
            this.namirnice = namirnice;
        }



        [HttpGet]
        public List<SkladisteUlaz> get()
        {
            return namirnice.get();

        }


        [HttpDelete("{id}")]
        public void deleteByid(int id)
        {
            namirnice.DeleteSkladiste(id);
        }
        [HttpGet("{id}")]
        public SkladisteUlaz getByid(int id)
        {
            return namirnice.getById(id);
        }


        [HttpPost]
        public void postData(SkladisteUlaz c)
        {
            namirnice.post(c);
        }

        [HttpPut("{id}")]
        public void edit(SkladisteUlaz c)
        {
            namirnice.edit(c);
        }

    }
}
