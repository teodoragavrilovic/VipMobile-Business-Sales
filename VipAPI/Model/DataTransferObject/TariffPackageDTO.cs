using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class TariffPackageDTO
    {
        [Key]
        public int TariffPackageId { get; set; }
        public string TariffPackageName { get; set; }

        public int AvlbMinutes { get; set; }

        public int AvlbSMS { get; set; }

        public int AvlbMB { get; set; }

        public double Price { get; set; }

        public int PackageTypeId { get; set; }
        public PackageTypeDTO PackageType { get; set; }
    }
}
