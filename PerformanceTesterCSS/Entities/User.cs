using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTesterCSS.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("username", TypeName = "varchar(255)")]
        public String Username { get; set; }

        [Column("password", TypeName = "varchar(255)")]
        public String Password { get; set; }

        [Column("roles", TypeName = "varchar(255)")]
        public String Roles { get; set; }

        [Column("access_failed_count")]
        public Int32 AccessFailedCount { get; set; }

        [Column("email", TypeName = "varchar(255)")]
        public String Email { get; set; }

        [Column("email_confirm_code", TypeName = "varchar(255)")]
        public String EmailConfirmCode { get; set; }

        [Column("email_confirm_code_sent_time")]
        public DateTime EmailConfirmCodeSentTime { get; set; }

        [Column("email_verified_at")]
        public DateTime EmailVerifiedAt { get; set; }

        [Column("phone", TypeName = "varchar(255)")]
        public String Phone { get; set; }

        [Column("first_name", TypeName = "varchar(255)")]
        public String FirstName { get; set; }

        [Column("last_name", TypeName = "varchar(255)")]
        public String LastName { get; set; }

        [Column("organisation", TypeName = "varchar(2550)")]
        public String Organisation { get; set; }

        [Column("last_login_time")]
        public DateTime LastLoginTime { get; set; }

        [Column("vat_id", TypeName = "varchar(2550)")]
        public String VatID { get; set; }

        [Column("address", TypeName = "varchar(2550)")]
        public String Address { get; set; }

        [Column("city", TypeName = "varchar(2550)")]
        public String City { get; set; }

        [Column("country", TypeName = "varchar(2550)")]
        public String Country { get; set; }

        [Column("organisation_address", TypeName = "varchar(2550)")]
        public String OrganisationAddress { get; set; }

        [Column("postal_code", TypeName = "varchar(2550)")]
        public String PostalCode { get; set; }

        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }

        [Column("last_edit_date")]
        public DateTime? LastEditDate { get; set; }

        [Column("remember_token", TypeName = "varchar(100)")]
        public String RememberToken { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("is_deleted")]
        public Boolean IsDeleted { get; set; }

        [Column("is_encrypted")]
        public Boolean IsEncrypted { get; set; }

    }
}
