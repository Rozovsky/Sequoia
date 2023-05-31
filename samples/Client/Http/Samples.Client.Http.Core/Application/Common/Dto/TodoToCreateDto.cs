namespace Samples.Client.Http.Core.Application.Common.Dto
{
    public class TodoToCreateDto
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
