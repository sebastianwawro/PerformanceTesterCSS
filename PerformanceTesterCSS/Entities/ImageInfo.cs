using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("image_infos")]
    public class ImageInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("file_location", TypeName = "varchar(255)")]
        public String FileLocation { get; set; }

        [Column("file", TypeName = "varchar(255)")]
        public String File { get; set; }

        [Column("name", TypeName = "varchar(255)")]
        public String Name { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("last_edit_date")]
        public DateTime LastEditDate { get; set; }

        [Column("is_deleted")]
        public Boolean IsDeleted { get; set; }

        [ForeignKey("creator_id")]
        public virtual User Creator { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
