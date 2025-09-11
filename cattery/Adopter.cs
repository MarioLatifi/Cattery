using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cattery
{
    public class Adopter
    {
        public Adopter() { }
        public Adopter(string name, string surname, string address, string cel) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name cannot be null or empty", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentException("surname cannot be null or empty", nameof(surname));
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("address cannot be null or empty", nameof(address));
            }
            if (string.IsNullOrWhiteSpace(cel))
            {
                throw new ArgumentException("cel cannot be null or empty", nameof(cel));
            }
            Name = name;
            Surname = surname;
            Address = address;
            Cel = cel;
        }
        [JsonInclude]//sennó con i private set non va il json deserializer
        public string Name { get; private set; }
        [JsonInclude]
        public string Surname { get; private set; }
        [JsonInclude]
        public string Address { get; private set; }
        [JsonInclude]
        public string Cel { get; private set; }
    }
}
