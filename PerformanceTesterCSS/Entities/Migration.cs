using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("migrations")]
    public class Migration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("migration", TypeName = "varchar(255)")]
        public String MigrationName { get; set; }

        [Column("batch")]
        public Int32 Batch { get; set; }
    }
}
