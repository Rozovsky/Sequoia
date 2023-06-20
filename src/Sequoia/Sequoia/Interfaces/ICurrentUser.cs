namespace Sequoia.Interfaces
{
    public interface ICurrentUser
    {
        public string Id { get; set; }
        public string ProfileId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Language { get; set; }
        public List<string> Roles { get; set; }
    }
}
