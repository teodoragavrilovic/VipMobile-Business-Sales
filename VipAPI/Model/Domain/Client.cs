using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Client
    {
        public int ClientId { get; set; }
    
        public string ClientName { get; set; }

        public int PIB { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public int YearOfFaundation { get; set; }
    }
}
