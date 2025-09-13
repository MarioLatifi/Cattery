using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cattery
{
    public enum Sex
    {
        Male,Female
    }
    public class Cat
    {
        public Cat() { }
        public Cat(string name,string race,Sex sex,string description, DateOnly? birth,DateOnly arrived,DateOnly? left,string? catImage)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name cannot be null or empty", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(race))
            {
                throw new ArgumentException("race cannot be null or empty", nameof(race));
            }
            Name = name;
            Race = race;
            CatSex = sex;
            if(string.IsNullOrWhiteSpace(description))
            {
                description = "No description";//almeno evito di throware sempre errori.
            }
            Description = description;
            Birth = birth;
            ArrivedToCattery = arrived;
            Birth = birth;
            LeftCattery = left;
            CatImage = catImage;
            //genero un numero casuale di 5 cifre
            RegenerateCui();

        }

        public void RegenerateCui()//potrebbe servire se il gatto viene restituito al gattile, per esempio.
        {
            Random random = new Random();
            int cuiNumber = random.Next(10000, 99999);
            //prima lettera del mese
            string monthLetter = ArrivedToCattery.Month.ToString().First().ToString().ToUpper();
            //anno
            string year = ArrivedToCattery.Year.ToString();
            //tre lettere casuali
            List<char> letters = new List<char>();
            for (int i = 0; i < 3; i++)
            {
                letters.Add((char)(random.Next(65, 90)));
            }
            //unisco tutto
            Cui = $"{cuiNumber}{monthLetter}{year}{letters[0]}{letters[1]}{letters[2]}";
        }
        [JsonInclude]
        public string Name { get; private set; }
        [JsonInclude]
        public string Race { get; private set; }
        [JsonInclude]
        public Sex CatSex { get; private set; }
        [JsonInclude]
        public DateOnly? Birth { get; private set; }
        [JsonInclude]
        public DateOnly ArrivedToCattery { get; internal set; }
        [JsonInclude]
        public DateOnly? LeftCattery { get; internal set; }
        [JsonInclude]
        public string Description { get; internal set; }
        [JsonInclude]
        public string Cui { get; internal set; }
        [JsonInclude]
        public string? CatImage { get; internal set; }

    }
}
