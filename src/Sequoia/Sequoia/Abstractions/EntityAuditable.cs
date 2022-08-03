using Sequoia.Interfaces;

namespace Sequoia.Abstractions
{
    /// <summary>
    /// Entity auditable attributes
    /// </summary>
    /// <typeparam name="TPrimaryKey">Entity primary key type</typeparam>
    /// <typeparam name="TUserId">Auditable user id type</typeparam>
    /// <typeparam name="TDate">Auditable date type</typeparam>
    public abstract class EntityAuditable<TPrimaryKey, TUserId, TDate> : EntityBase<TPrimaryKey>, 
        IEntityAuditable<TPrimaryKey, TUserId, TDate>
    {
        public virtual TUserId CreatedBy { get; set; }
        public virtual TUserId ModifiedBy { get; set; }
        public virtual TDate DateOfCreation { get; set; }
        public virtual TDate DateOfModification { get; set; }
    }

    /// <summary>
    /// Entity auditable attributes with default types
    /// </summary>
    public abstract class EntityAuditable : EntityBase, IEntityAuditable
    {
        public virtual long? CreatedBy { get; set; }
        public virtual long? ModifiedBy { get; set; }
        public virtual DateTimeOffset? DateOfCreation { get; set; }
        public virtual DateTimeOffset? DateOfModification { get; set; }
    }
}
