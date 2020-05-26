using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("referral_records")]
    public class ReferralRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("guid", TypeName = "varchar(255)")]
        public String Guid { get; set; }

        [Column("roles", TypeName = "varchar(255)")]
        public String Roles { get; set; }

        [Column("issued_for", TypeName = "varchar(255)")]
        public String IssuedFor { get; set; }

        [ForeignKey("issued_by")]
        public virtual User IssuedBy { get; set; }

        [ForeignKey("used_by")]
        public virtual User UsedBy { get; set; }

        [Column("is_active")]
        public Boolean IsActive { get; set; }

        [Column("is_deleted")]
        public Boolean IsDeleted { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
