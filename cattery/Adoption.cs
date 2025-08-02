using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cattery
{
    public class Adoption
    {
        public Adoption(Cat cat, Adopter adopter,DateOnly date) 
        {
            AdoptionCat = cat;
            AdoptionAdopter = adopter;
            AdoptionDate = date;
        }
        public Cat AdoptionCat { get; private set; }
        public Adopter AdoptionAdopter { get; private set; }
        public DateOnly AdoptionDate { get; private set; }

    }
}
