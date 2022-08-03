namespace Sequoia.Interfaces
{
    /// <summary>
    /// Entity auditable attributes
    /// </summary>
    /// <typeparam name="TPrimaryKey">Entity primary key type</typeparam>
    /// <typeparam name="TUserId">Auditable user id type</typeparam>
    /// <typeparam name="TDate">Auditable date type</typeparam>
    public interface IEntityAuditable<TPrimaryKey, TUserId, TDate> : IEntityBase<TPrimaryKey>
    {
        public TUserId CreatedBy { get; set; }
        public TUserId ModifiedBy { get; set; }
        public TDate DateOfCreation { get; set; }
        public TDate DateOfModification { get; set; }
    }

    /// <summary>
    /// Entity auditable attributes with default types
    /// </summary>
    public interface IEntityAuditable : IEntityBase
    {
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTimeOffset? DateOfCreation { get; set; }
        public DateTimeOffset? DateOfModification { get; set; }
    }
}
