namespace Sequoia.Interfaces
{
    public interface IEntityBase<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public interface IEntityBase
    {
        public long Id { get; set; }
    }
}
