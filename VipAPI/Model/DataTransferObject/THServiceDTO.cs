using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class THServiceDTO
    {
        [Key]
        public int THServiceId { get; set; }

        public string ServiceName { get; set; }

        public double ServicePrice { get; set; }

        public int ServiceTypeId { get; set; }

        public ServiceTypeDTO ServiceType { get; set; }
    }
}
