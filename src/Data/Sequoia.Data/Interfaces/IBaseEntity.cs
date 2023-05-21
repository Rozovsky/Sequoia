namespace Sequoia.Data.Interfaces
{
    public interface IBaseEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
