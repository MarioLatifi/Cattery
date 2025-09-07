using catteryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cattery
{
    public class Cattery
    {
        public Cattery(ManageCat catManagement, ManageAdoption adoptionManagement)//ricorda che Quando configurerai ManageAdoption  devi dargli come  parametro ManageCat
        {
            CatManagement = catManagement;
            AdoptionManagement = adoptionManagement;
        }
        public ManageCat CatManagement { get; private  set; }
        public ManageAdoption AdoptionManagement { get; private set; }
        public void AdoptCat(Cat cat, Adopter adopter, DateOnly adoptionDate)
        {
            cat.LeftCattery = adoptionDate;
            Adoption adoption = new Adoption(cat, adopter, adoptionDate);
            AdoptionManagement.MakeAdoption(adoption);
        }
        public void AddCat(Cat cat)
        {
            CatManagement.AddCatt(cat);
        }
        public void RemoveCat(Cat cat)//can also die =c.
        {
            CatManagement.RemoveCatt(cat);
        }
        public void RefundCat(Cat cat, DateOnly refundDate)
        {
            //i need to  search for the cat  in  the adoptionList.
            AdoptionManagement.RefoundAdoption(SearchByCat(cat), refundDate);
        }
        private Adoption SearchByCat(Cat cat)
        {
            for(int catPos = 0; catPos< AdoptionManagement.Adoptions.Count(); catPos++)
            {
                if (cat == AdoptionManagement.Adoptions[catPos].AdoptionCat)
                {
                    return AdoptionManagement.Adoptions[catPos];
                }
            }
            throw new ArgumentException("Did non find this cat on our  database");
        }
    }
}
