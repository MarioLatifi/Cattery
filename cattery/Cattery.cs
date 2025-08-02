using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cattery
{
    public class Cattery
    {
        public Cattery(List<Cat> catList,List<Adoption> adoptionList)
        {
            CatList = catList;
            AdoptionList = adoptionList;
        }
        public List<Cat> CatList { get; private set; }
        public List<Adoption> AdoptionList { get; private set; }
        public void AdoptCat(Cat cat, Adopter adopter, DateOnly adoptionDate)
        {
            //faccio un controllo giusto per sicurezza: mettiamo che volesse adottare un gatto che non c'é nel gattile:
            if(!CatList.Contains(cat))
            {
                throw new ArgumentException("The cat is not available for adoption.", nameof(cat));
            }
            else
            {
                CatList.Remove(cat);
                cat.LeftCattery = adoptionDate;
                Adoption adoption = new Adoption(cat, adopter, adoptionDate);
                AdoptionList.Add(adoption);
            }
        }
        public void AddCat(Cat cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat), "Cat cannot be null");
            }
            CatList.Add(cat);
        }
        public void RefundCat(Cat cat, DateOnly refundDate)
        {
            cat.Description = $"Adoption failed: started on:{cat.ArrivedToCattery} and ended on: {cat.LeftCattery}";
            cat.LeftCattery = null;
            cat.ArrivedToCattery = refundDate;
            cat.RegenerateCui();
            AddCat(cat);
        }
    }
}
