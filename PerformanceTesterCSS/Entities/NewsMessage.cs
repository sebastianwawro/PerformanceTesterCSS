using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("news_messages")]
    public class NewsMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("message", TypeName = "varchar(16000)")]
        public String Message { get; set; }

        [Column("is_anonymous")]
        public Boolean IsAnonymous { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("last_edit_date")]
        public DateTime LastEditDate { get; set; }

        [Column("is_deleted")]
        public Boolean IsDeleted { get; set; }

        [ForeignKey("creator_id")]
        public virtual User Creator { get; set; }

        [ForeignKey("last_editor_id")]
        public virtual User LastEditor { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
