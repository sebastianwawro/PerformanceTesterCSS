using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTesterCSS.Entities
{
    [Table("in_app_messages")]
    public class InAppMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //or none
        [Column("id")]
        public Int64 Id { get; set; }

        [ForeignKey("broadcaster_id")]
        public virtual User Broadcaster { get; set; }

        [ForeignKey("receiver_id")]
        public virtual User Receiver { get; set; }

        [Column("date_sent")]
        public DateTime DateSent { get; set; }

        [Column("message_content", TypeName = "varchar(16000)")]
        public String MessageContent { get; set; }

        [Column("is_opened")]
        public DateTime IsOpened { get; set; }

        [Column("is_deleted_for_broadcaster")]
        public DateTime IsDeletedForBroadcaster { get; set; }

        [Column("is_deleted_for_receiver")]
        public DateTime IsDeletedForReceiver { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
