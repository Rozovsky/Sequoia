using AutoMapper;
using Samples.Data.Mongo.Core.Domain;
using Samples.Data.Mongo.Core.Domain.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.ViewModels;

[AutoMap(typeof(Todo))]
public class TodoHeaderVm
{
    public string Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
}