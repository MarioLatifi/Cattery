using cattery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace catteryLib
{
    public class ManageAdoption
    {
        public ManageAdoption(ManageCat catManagement)
        {
            CatManagement = catManagement;
        }
        public ManageAdoption() { }//per serializer/deserializer
        [JsonInclude]
        public ManageCat CatManagement {  get; private set; }
        [JsonInclude]
        public List<Adoption> Adoptions { get; set; } 
        internal void MakeAdoption(Adoption adoption)
        {
            Adoptions.Add(adoption);
            //devo anche  rimuovere il gatto da CatManagement
            CatManagement.RemoveCatt(adoption.AdoptionCat);
        }
        internal void RefundAdoption(Adoption adoption,DateOnly refundDate)//this fun simply  modifies  the adoption info without removing it from the list.
        {
            adoption.AdoptionCat.Description += $"Adoption Failed: Started on: {adoption.AdoptionCat.LeftCattery} and ended on: {refundDate}";
            adoption.AdoptionCat.LeftCattery = null;
        }
    }
}
