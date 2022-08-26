using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class THServiceRequestDTO
    {
        [Key]
        public int THServiceRequestId { get; set; }

        public DateTime RequestDate { get; set; }

        public bool Approved { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeDTO Employee { get; set; }

        public int ClientId { get; set; }

        public ClientDTO Client { get; set; }

    
    }
}
