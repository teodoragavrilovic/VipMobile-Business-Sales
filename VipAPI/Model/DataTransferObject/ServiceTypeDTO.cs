using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class ServiceTypeDTO
    {
        [Key]
        public int ServiceTypeId { get; set; }

        public string ServiceTypeName { get; set; }

        public string Description { get; set; }
    }
}
