using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class OfferItemDTO
    {
        //[Key]
        public int OfferItemId { get; set; }

       // [Key]
        //public int THOfferId { get; set; }
       // [JsonIgnore]
       // public THOfferDTO THOffer { get; set; }
        public DateTime ActivationDate { get; set; }

        public int THServiceId { get; set; }

        public THServiceDTO THService { get; set; }

    }
}
