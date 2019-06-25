using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventoryservices.Models
{
    public class CompanyDetails
    {
        public int id { get; set; }
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string role { get; set; }
        
    }
}
