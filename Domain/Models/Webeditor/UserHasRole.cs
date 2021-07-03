using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Webeditor
{
    [Table("webeditor_users_has_webeditor_roles")]
    public class UserHasRole
    {
        [Column("id_webeditor_users")]
        public int UserId { get; set; }

        [Column("id_webeditor_roles")]
        public int RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
