using System.Linq;
using System.Security.Principal;

namespace Callboard.App.General.Entities.Auth
{
    public class UserPrinciple : IPrincipal
    {
        private string[] _roles;
        public UserPrinciple(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string[] Roles
        {
            get => _roles;
            set => _roles = value.Select(x => x.ToLower()).ToArray();
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (_roles == null)
            {
                return false;
            }
            return _roles.Contains(role.ToLower());
        }
    }
}
