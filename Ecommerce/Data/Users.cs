using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Data
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
            Roles = new HashSet<Roles>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Orders> Orders { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Roles> Roles { get; set; }
    }
}
