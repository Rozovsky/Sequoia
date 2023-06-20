namespace Sequoia.Data.Interfaces
{
    public interface ITranslation
    {
        public string Language { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
