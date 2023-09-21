using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.Dto
{
    public class TodoToCreateDto
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Translation> Translations { get; set; }
    }
}
