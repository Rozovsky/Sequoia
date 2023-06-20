using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Models
{
    public class Translation : ITranslation
    {
        public string Language { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
