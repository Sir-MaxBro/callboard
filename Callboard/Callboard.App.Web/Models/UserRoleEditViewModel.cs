using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class UserRoleEditViewModel
    {
        public int UserId { get; set; }

        public IReadOnlyCollection<Role> Roles { get; set; }
    }
}