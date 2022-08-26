using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class THOfferDTO
    {
        public int THOfferId { get; set; }

        public DateTime ConfirmationDeadline { get; set; }

        public DateTime OfferDate { get; set; }

        public int THServiceRequestId { get; set; }

        public THServiceRequestDTO THServiceRequest { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeDTO Employee { get; set; }

        public List<OfferItemDTO> OfferItems { get; set; }
    }
}
