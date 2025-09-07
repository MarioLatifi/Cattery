using cattery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catteryLib
{
    public class ManageCat
    {
        //uso costruttore  di default
        public List<Cat> Cats {  get; private set; }
        internal void AddCatt(Cat cat)
        {
            Cats.Add(cat);
        }
        internal void RemoveCatt(Cat cat)
        { 
            Cats.Remove(cat);
        }
    }
}
