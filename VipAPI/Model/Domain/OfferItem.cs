using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
   
    public class OfferItem
    {
        
        public int OfferItemId { get; set; }

        public int THOfferId { get; set; }

        public THOffer THOffer { get; set; }
        public DateTime ActivationDate { get; set; }

        public int THServiceId { get; set; }

        public THService THService { get; set; }


    }
}
