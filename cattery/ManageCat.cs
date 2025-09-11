using cattery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace catteryLib
{
    public class ManageCat
    {
        public ManageCat() 
        {
            Cats = new List<Cat>();
        }
        public List<Cat> Cats { get; set; }

        public void AddCatt(Cat cat)
        {
            Cats.Add(cat);
        }
        public void RemoveCatt(Cat cat)
        { 
            Cats.Remove(cat);
        }
    }
}
