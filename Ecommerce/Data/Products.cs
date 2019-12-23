using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Data
{
    public partial class Products
    {
        public Products()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
