namespace Sequoia.Authentication.Models
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string ProfileId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
