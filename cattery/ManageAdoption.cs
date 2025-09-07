using cattery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catteryLib
{
    public class ManageAdoption
    {
        public ManageAdoption(ManageCat catManagement)
        {
            CatManagement = catManagement;
        }
        public ManageCat CatManagement {  get; private set; }
        public List<Adoption> Adoptions; 
        internal void MakeAdoption(Adoption adoption)
        {
            Adoptions.Add(adoption);
            //devo anche  rimuovere il gatto da CatManagement
            CatManagement.RemoveCatt(adoption.AdoptionCat);
        }
        internal void RefoundAdoption(Adoption adoption,DateOnly refundDate)//this fun simply  modifies  the adoption info without removing it from thhe list.
        {
            adoption.AdoptionCat.Description += $"Adoption Failed: Started on: {adoption.AdoptionCat.LeftCattery} and ended on: {refundDate}";
            adoption.AdoptionCat.LeftCattery = null;
        }
    }
}
