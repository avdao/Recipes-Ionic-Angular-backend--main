using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MjerneJediniceController : ControllerBase
    {
        private readonly MjerneJediniceInterface mjerneJedinice;


        public MjerneJediniceController(MjerneJediniceInterface mjerneJedinice)
        {
            this.mjerneJedinice = mjerneJedinice;
        }

        [HttpGet]
        public List<MjerneJedinice> get()
        {
            return mjerneJedinice.getAllMjerneJedinice();

        }


        [HttpDelete("{id}")]
        public void deleteByid(int id)
        {
            mjerneJedinice.deleteById(id);
        }
        [HttpGet("{id}")]
        public MjerneJedinice getByid(int id)
        {
            return mjerneJedinice.getById(id);
        }


        [HttpPost]
        public void postData(MjerneJedinice c)
        {
            mjerneJedinice.post(c);
        }

        [HttpPut("{id}")]
        public void edit(MjerneJedinice c)
        {
            mjerneJedinice.edit(c);
        }




    }
}
