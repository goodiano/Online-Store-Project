using TemplateProjectOne.Domain.Entities.Common;

namespace TemplateProjectOne.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public int Id { get; set; }
        public virtual User Users { get; set; }
        public int UserId { get; set; }
        public virtual Role Roles { get; set; }
        public int? RoleId { get; set; }
    }
}
