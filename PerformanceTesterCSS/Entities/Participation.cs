using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("participations")]
    public class Participation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [ForeignKey("season_id")]
        //[NotMapped]
        public virtual Season Season { get; set; }

        //[Column("season_id")]
        [NotMapped]
        public Int32 SeasonId { get; set; }

        [ForeignKey("user_id")]
        //[NotMapped]
        public virtual User User { get; set; }

        //[Column("user_id")]
        [NotMapped]
        public Int32 UserId { get; set; }

        [Column("conf_participation")]
        public Boolean? ConferenceParticipation { get; set; }

        [Column("paper_publication")]
        public Boolean? PaperPublication { get; set; }

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
