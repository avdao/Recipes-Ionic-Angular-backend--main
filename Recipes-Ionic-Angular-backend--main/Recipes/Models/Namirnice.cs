using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Namirnice
    {
        public Namirnice()
        {
            Ingredients = new HashSet<Ingredient>();
            SkladisteUlazs = new HashSet<SkladisteUlaz>();
            Skladistes = new HashSet<Skladiste>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? MjernaJedinica { get; set; }

        public virtual MjerneJedinice MjernaJedinicaNavigation { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<SkladisteUlaz> SkladisteUlazs { get; set; }
        public virtual ICollection<Skladiste> Skladistes { get; set; }
    }
}
