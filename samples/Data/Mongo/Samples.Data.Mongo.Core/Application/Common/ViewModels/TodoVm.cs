using AutoMapper;
using Samples.Data.Mongo.Core.Domain;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.ViewModels;

[AutoMap(typeof(Todo))]
public class TodoVm
{
    public string Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public virtual string CreatedBy { get; set; }
    public virtual DateTimeOffset? CreatedAt { get; set; }
    public virtual string UpdatedBy { get; set; }
    public virtual DateTimeOffset? UpdatedAt { get; set; }
    public List<Translation> Translations { get; set; }
}