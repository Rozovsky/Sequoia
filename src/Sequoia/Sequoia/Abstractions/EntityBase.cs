using Sequoia.Interfaces;

namespace Sequoia.Abstractions
{
    public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    public abstract class EntityBase : IEntityBase
    {
        public virtual long Id { get; set; }
    }
}
