using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Skladiste
    {
        public int Id { get; set; }
        public int FkNamirnice { get; set; }
        public decimal Kolicina { get; set; }
        public decimal MinKolicina { get; set; }
        public bool? IspodMin { get; set; }

        public virtual Namirnice FkNamirniceNavigation { get; set; }
    }
}
