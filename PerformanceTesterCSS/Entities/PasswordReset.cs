using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("password_resets")]
    public class PasswordReset
    {
        /*
         * NO ID IN THIS TABLE
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }
        */

        [Column("email", TypeName = "varchar(255)")]
        public String Email { get; set; }

        [Column("token", TypeName = "varchar(255)")]
        public String Token { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
