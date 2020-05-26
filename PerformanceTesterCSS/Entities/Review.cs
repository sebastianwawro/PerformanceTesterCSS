using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [ForeignKey("paper_version_id")]
        public virtual PaperVersion PaperVersion { get; set; }

        [ForeignKey("critic_id")]
        public virtual User Critic { get; set; }

        [ForeignKey("file_id")]
        public virtual DocumentFile File { get; set; }

        [Column("status")]
        public Int32 Status { get; set; }

        [Column("comment_for_author", TypeName = "varchar(16000)")]
        public String CommentForAuthor { get; set; }

        [Column("comment_for_admin", TypeName = "varchar(16000)")]
        public String CommentForAdmin { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("last_edit_date")]
        public DateTime LastEditDate { get; set; }

        [Column("is_deleted")]
        public Boolean IsDeleted { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
