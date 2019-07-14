using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDCoreReact.Models
{
    [Table("Sales")]
    public class SalesModel
    {
        [Key, Column(Order = 0)]
        public int SalesId { get; set; }
        [Required, Column(Order = 1)]
        public int ProductId { get; set; }
        [Required, Column(Order = 2)]
        public int CustomerId { get; set; }
        [Required, Column(Order = 3)]
        public int StoreId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed), Column (Order = 4)]
        public DateTime DateSold { get; set; }
        public virtual CustomerModel CustomerModel { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual StoreModel StoreModel { get; set; }
    }
}
