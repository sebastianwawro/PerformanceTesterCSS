using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("papers")]
    public class Paper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [ForeignKey("participation_id")]
        public virtual Participation Participation { get; set; }

        [Column("title", TypeName = "varchar(255)")]
        public String Title { get; set; }

        [Column("sent_to_print_date")]
        public DateTime SentToPrintDate { get; set; }

        [Column("status")]
        public Int32 Status { get; set; }

        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }

        [Column("last_edit_date")]
        public DateTime? LastEditDate { get; set; }

        [Column("is_deleted")]
        public Boolean? IsDeleted { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
