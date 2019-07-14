using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDCoreReact.Models
{
    [Table("Store")]
    public class StoreModel
    {
        [Key, Column(Order = 0)]
        public int StoreId { get; set; }
        [Required, Column(Order = 1)]
        public string StoreName { get; set; }
        [Required, Column(Order = 2)]
        public string StoreAddress { get; set; }
        [Display(Name = "ProductSold")]
        public virtual List<SalesModel> SalesModels { get; set; }

    }
}
