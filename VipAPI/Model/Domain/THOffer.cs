using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class THOffer
    {
        public int THOfferId { get; set; }

        public DateTime ConfirmationDeadline { get; set; }

        public DateTime OfferDate { get; set; }

        public int THServiceRequestId { get; set; }

        public THServiceRequest THServiceRequest { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public List<OfferItem> OfferItems = new List<OfferItem>();
    }
}
