using MediatR;
using Microsoft.AspNetCore.Http;

namespace Sequoia.Behaviours
{
    internal class AuditBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly HttpContext _httpContext;

		public AuditBehaviour(IHttpContextAccessor httpContextAccessor)
		{
			_httpContext = httpContextAccessor.HttpContext;
		}

		public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			Console.WriteLine(request);
			Console.WriteLine(_httpContext.Request.Method);

            return next();
		}
	}
}
