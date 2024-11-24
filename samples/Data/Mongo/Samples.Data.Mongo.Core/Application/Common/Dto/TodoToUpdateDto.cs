using Sequoia.Data.Interfaces;
using Sequoia.Data.Mongo.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.Dto;

public class TodoToUpdateDto : IMultilingual<Translation>
{
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public List<Translation> Translations { get; set; }
}