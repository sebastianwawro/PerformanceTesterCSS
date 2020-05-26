using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("presences")]
    public class Presence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("user_index", TypeName = "varchar(255)")]
        public String UserIndex { get; set; }

        [Column("user_ip", TypeName = "varchar(255)")]
        public String UserIp { get; set; }

        [Column("date_commited")]
        public DateTime DateCommited { get; set; }

        [Column("is_deleted")]
        public Boolean IsDeleted { get; set; }
        
    }
}
