using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class SkladisteUlaz
    {
        public int Id { get; set; }
        public int FkNamirncie { get; set; }
        public decimal Kolicina { get; set; }
        public DateTime DatumUnosa { get; set; }

        public virtual Namirnice FkNamirncieNavigation { get; set; }
    }
}
