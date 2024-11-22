﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handler request={Request} - Response={Response} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();   
        var duration = timer.Elapsed;

        if (duration.Seconds > 3) { 
            logger.LogWarning("[PERFORMANCE] The request {Request} took {Duration} seconds.", typeof(TRequest).Name, duration.Seconds);
        }
            
        logger.LogInformation("[END] Handler {Request} with {Response}.", typeof(TRequest).Name, typeof(TResponse).Name); 
        
        return response;    
    }
}
