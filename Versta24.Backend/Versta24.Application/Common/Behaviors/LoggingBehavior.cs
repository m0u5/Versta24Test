using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            Log.Information("Orders Request: {Name},{@Request}", requestName, request);
            var response = await next();
            return response;
        }
    }
}
