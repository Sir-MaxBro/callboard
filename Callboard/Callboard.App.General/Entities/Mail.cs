using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    public class Mail
    {
        public int Id { get; set; }

        //public int UserId { get; set; }

        [ForeignKey("UserId", tableName: "User")]
        public User User { get; set; }

        public string Email { get; set; }
    }
}
