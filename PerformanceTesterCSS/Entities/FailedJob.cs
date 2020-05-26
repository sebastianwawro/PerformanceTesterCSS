using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("failed_jobs")]
    public class FailedJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }
    }
}
