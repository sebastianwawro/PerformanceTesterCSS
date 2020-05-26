using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("log_records")]
    public class LogRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("log_type", TypeName = "varchar(255)")]
        public String LogType { get; set; }

        [Column("log_message", TypeName = "varchar(255)")]
        public String LogMessage { get; set; }

        [Column("date_occured")]
        public DateTime DateOccured { get; set; }

        [Column("is_deleted")]
        public DateTime IsDeleted { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
