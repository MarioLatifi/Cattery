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
        public ManageAdoption( )
        {
            Adoptions = new List<Adoption>();
        }
        [JsonInclude]
        public List<Adoption> Adoptions { get; set; } //pubblico perché quando lo deserializzo devo ri-assegnarlo
        public void MakeAdoption(Adoption adoption)
        {
            Adoptions.Add(adoption);
        }
        public void RefundAdoption(Adoption adoption,DateOnly refundDate)//this fun simply  modifies  the adoption info without removing it from the list.
        {
            adoption.AdoptionCat.Description += $"Adoption Failed: Started on: {adoption.AdoptionCat.LeftCattery} and ended on: {refundDate}";
            adoption.AdoptionCat.LeftCattery = null;
            Adoptions.Remove(adoption);
        }
    }
}
