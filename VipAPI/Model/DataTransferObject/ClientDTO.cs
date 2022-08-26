using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class ClientDTO
    {
        [Key]
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public int PIB { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public int YearOfFaundation { get; set; }
    }
}
