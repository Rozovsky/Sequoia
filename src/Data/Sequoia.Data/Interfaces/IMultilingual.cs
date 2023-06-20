namespace Sequoia.Data.Interfaces
{
    public interface IMultilingual
    {
        public IEnumerable<ITranslation> Translations { get; set; }
    }
}
