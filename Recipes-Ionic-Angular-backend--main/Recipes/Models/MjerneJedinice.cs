using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class MjerneJedinice
    {
        public MjerneJedinice()
        {
            Namirnices = new HashSet<Namirnice>();
        }

        public int Id { get; set; }
        public string Jedinica { get; set; }
        public string JedinicaLong { get; set; }

        public virtual ICollection<Namirnice> Namirnices { get; set; }
    }
}
