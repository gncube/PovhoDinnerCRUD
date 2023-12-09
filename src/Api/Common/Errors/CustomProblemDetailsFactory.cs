using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Api.Errors;

/// <summary>
///     A <see cref="ProblemDetailsFactory" /> that adds additional details to the <see cref="ProblemDetails" />.
///     See "https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.Core/src/Infrastructure/DefaultProblemDetailsFactory.cs" for copied factory.
/// </summary>
public class CustomProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;
    private readonly Action<ProblemDetailsContext>? _configure;

    public CustomProblemDetailsFactory(
        IOptions<ApiBehaviorOptions> options,
        IOptions<ProblemDetailsOptions>? problemDetailsOptions = null)
    {
        _options = options.Value;
        _configure = problemDetailsOptions?.Value?.CustomizeProblemDetails;
    }
    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        ArgumentNullException.ThrowIfNull(modelStateDictionary);

        statusCode ??= 400;

        var problemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        if (title != null)
        {
            // For validation problem details, don't overwrite the default title with null.
            problemDetails.Title = title;
        }

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        // TODO: Add custom properties to the ProblemDetails
        problemDetails.Extensions.Add("customProperty", "customValue");

        _configure?.Invoke(new() { HttpContext = httpContext!, ProblemDetails = problemDetails });
    }
}
