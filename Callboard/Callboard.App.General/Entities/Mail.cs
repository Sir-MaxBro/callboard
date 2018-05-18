namespace Callboard.App.General.Entities
{
    public class Mail
    {
        public int Id { get; set; }

        //public int UserId { get; set; }

        public User User { get; set; }

        public string Email { get; set; }
    }
}
