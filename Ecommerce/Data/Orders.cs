using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Data
{
    public partial class Orders
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.Orders))]
        public virtual Products Product { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Orders))]
        public virtual Users User { get; set; }
    }
}
