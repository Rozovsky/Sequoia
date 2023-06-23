namespace Sequoia.Data.Interfaces
{
    public interface IAuditable : IBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
