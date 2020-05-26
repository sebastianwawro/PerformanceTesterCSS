using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("user_admin_privileges")]
    public class UserAdminPrivileges
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [ForeignKey("admin_id")]
        public virtual User Admin { get; set; }

        [Column("can_modify_settings")]
        public Boolean CanModifySettings { get; set; }

        [Column("can_modify_security_settings")]
        public Boolean CanModifySecuritySettings { get; set; }

        [Column("can_delete_papers")]
        public Boolean CanDeletePapers { get; set; }

        [Column("can_delete_reviews")]
        public Boolean CanDeleteReviews { get; set; }

        [Column("can_delete_seasons")]
        public Boolean CanDeleteSeasons { get; set; }

        [Column("can_delete_users")]
        public Boolean CanDeleteUsers { get; set; }

        [Column("can_modify_papers")]
        public Boolean CanModifyPapers { get; set; }

        [Column("can_modify_reviews")]
        public Boolean CanModifyReviews { get; set; }

        [Column("can_modify_seasons")]
        public Boolean CanModifySeasons { get; set; }

        [Column("can_modify_users")]
        public Boolean CanModifyUsers { get; set; }

        [Column("can_purge_papers")]
        public Boolean CanPurgePapers { get; set; }

        [Column("can_purge_reviews")]
        public Boolean CanPurgeReviews { get; set; }

        [Column("can_purge_seasons")]
        public Boolean CanPurgeSeasons { get; set; }

        [Column("can_purge_users")]
        public Boolean CanPurgeUsers { get; set; }

        [Column("can_delete_admin")]
        public Boolean CanDeleteAdmin { get; set; }

        [Column("can_modify_admin")]
        public Boolean CanModifyAdmin { get; set; }

        [Column("can_purge_admin")]
        public Boolean CanPurgeAdmin { get; set; }

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
