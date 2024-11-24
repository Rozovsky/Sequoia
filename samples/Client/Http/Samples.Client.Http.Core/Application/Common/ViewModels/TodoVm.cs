using AutoMapper;
using Samples.Client.Http.Core.Domain.Entities;

namespace Samples.Client.Http.Core.Application.Common.ViewModels;

[AutoMap(typeof(Todo))]
public class TodoVm
{
    public long UserId { get; set; }
    public long Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
}