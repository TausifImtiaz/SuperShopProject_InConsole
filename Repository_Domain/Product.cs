using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Domain
{

    [Serializable]
    public class Product : IEntity<int>
    {
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
    }
}