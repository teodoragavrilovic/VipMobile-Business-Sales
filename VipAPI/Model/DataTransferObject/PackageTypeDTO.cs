using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class PackageTypeDTO
    {
        [Key]
        public int PackageTypeId { get; set; }

        public string TypeName { get; set; }
    }
}
