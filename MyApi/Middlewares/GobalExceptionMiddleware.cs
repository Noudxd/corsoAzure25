namespace MyApi.Middlewares;

public class GobalExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<GobalExceptionMiddleware> logger;

    public GobalExceptionMiddleware(RequestDelegate next, ILogger<GobalExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            {
                logger.LogError("Eccezione non gestita");
                await HandleException(context, ex);

            }
        }

    }

    //restituisce un oggetto che fornisce tutti i dettagli dell'errore
    private static Task HandleException(HttpContext context, Exception ex) 
    {
        var (statusCode, title) = ex switch
        {
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource not found"),
            InvalidProgramException => (StatusCodes.Status406NotAcceptable, "Invalid Operation"),
            ValidationException => (StatusCodes.Status400BadRequest,"Bad Request"),
            _=> (StatusCodes.Status500InternalServerError, "Server Error")

        };

        var traceId = Activity.Current?.Id ?? context.TraceIdentifier;


        var problemDetails = new ProblemDetails()
        {
            Detail = ex.Message,
            Status = statusCode,
            Title = title,
            Instance = context.Request.Path
        };

        problemDetails.Extensions["TraceId"] = traceId;
        return context.Response.WriteAsJsonAsync(problemDetails);
    }
}
