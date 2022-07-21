namespace Sequoia.Interfaces
{
    internal interface IAuditableEntity<T>
    {
        public T CreatedBy { get; set; }
        public T? ModifiedBy { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }        
        public DateTimeOffset? DateOfModification { get; set; }
    }
}
