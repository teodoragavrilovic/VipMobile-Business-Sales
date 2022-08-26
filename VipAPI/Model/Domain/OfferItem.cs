using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Owned]
    public class OfferItem
    {
       //[Key]
        public int OfferItemId { get; set; }

        //[Key]
        //public int THOfferId { get; set; }
        //[JsonIgnore]
        //public THOffer THOffer { get; set; }

        public DateTime ActivationDate { get; set; }

        public int THServiceId { get; set; }

        public THService THService { get; set; }


    }
}
