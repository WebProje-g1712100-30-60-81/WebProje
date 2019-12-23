using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Data
{
    public partial class Roles
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Roles))]
        public virtual Users User { get; set; }
    }
}
