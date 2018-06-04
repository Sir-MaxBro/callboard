using System.Collections.Generic;

namespace Callboard.App.General.Entities.Auth
{
    public class MembershipUser
    {
        public MembershipUser() { }

        public MembershipUser(int id, string name)
            : this(id, name, null) { }

        public MembershipUser(int id, string name, IReadOnlyCollection<Role> roles)
        {
            this.UserId = id;
            this.Name = name;
            this.Roles = roles;
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        public byte[] PhotoData { get; set; }

        public string PhotoExtension { get; set; }

        public IReadOnlyCollection<Role> Roles { get; set; }
    }
}
