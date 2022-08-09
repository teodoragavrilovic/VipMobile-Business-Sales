using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class THServiceRequest
    {
        public int THServiceRequestId { get; set; }

        public DateTime RequestDate { get; set; }

        public bool Approved { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }


    }
}
