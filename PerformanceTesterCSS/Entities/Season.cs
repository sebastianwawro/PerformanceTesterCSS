using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("seasons")]
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("name", TypeName = "varchar(255)")]
        public String Name { get; set; }

        [Column("edition_number", TypeName = "varchar(255)")]
        public String EditionNumber { get; set; }

        [Column("location", TypeName = "varchar(255)")]
        public String Location { get; set; }

        [Column("main_image_filename", TypeName = "varchar(255)")]
        public String MainImageFilename { get; set; }

        [Column("reg_start_date")]
        public DateTime RegStartDate { get; set; }

        [Column("reg_end_date")]
        public DateTime RegEndDate { get; set; }

        [Column("conf_start_date")]
        public DateTime ConfStartDate { get; set; }

        [Column("conf_end_date")]
        public DateTime ConfEndDate { get; set; }

        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }

        [Column("last_edit_date")]
        public DateTime? LastEditDate { get; set; }

        [Column("is_deleted")]
        public Boolean IsDeleted { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
