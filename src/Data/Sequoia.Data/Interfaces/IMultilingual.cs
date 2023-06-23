namespace Sequoia.Data.Interfaces
{
    public interface IMultilingual<TTranslation> where TTranslation : ITranslation
    {
        public List<TTranslation> Translations { get; set; }
    }
}
