using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Supplier.Request
{
    public class AddSupplierToCompany
    {
        public int CompanyId { get; set; }
        public int SupplierId { get; set; }


    }
}
