using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public Adoption() { }//per serializer /deserializer
        [JsonInclude]
        public Cat AdoptionCat { get; private set; }
        [JsonInclude]
        public Adopter AdoptionAdopter { get; private set; }
        [JsonInclude]
        public DateOnly AdoptionDate { get; private set; }

    }
}
