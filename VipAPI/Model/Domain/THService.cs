using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class THService
    {

        public int THServiceId { get; set; }

        public string ServiceName { get; set; }

        public double ServicePrice { get; set; }

        public int ServiceTypeId { get; set; }

        public ServiceType ServiceType { get; set; }


    }
}
