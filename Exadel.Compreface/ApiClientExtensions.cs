using System.Text.Json;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Helpers;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;

namespace Exadel.Compreface;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
public static class ApiClientExtensions
{
    public static async Task<TResponse> GetJsonAsync<TResponse>(
        this Url requestUrl, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .GetAsync(completionOption, cancellationToken: cancellationToken)
                .ReceiveJson<TResponse>();

            return response;
        }
        catch(FlurlHttpTimeoutException exception)
        {
            throw await ThrowServiceTimeoutExceptionAsync(exception);
        }
        catch (FlurlHttpException exception)
        {
            throw await ThrowServiceExceptionAsync(exception);
        }
    }
    
    public static async Task<TResponse> GetJsonAsync<TResponse>(
        this string requestUrl, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        var response = await new Url(requestUrl).GetJsonAsync<TResponse>(completionOption, cancellationToken);

        return response;
    }
    
    public static async Task<TResponse> PostJsonAsync<TResponse>(
        this Url requestUrl, 
        object body, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
        where TResponse : class
    {
        try
        {
            var response = await requestUrl
                .PostJsonAsync(body, completionOption, cancellationToken)
                .ReceiveJson<TResponse>();

            return response;
        }
        catch(FlurlHttpTimeoutException exception)
        {
            throw await ThrowServiceTimeoutExceptionAsync(exception);
        }
        catch (FlurlHttpException exception)
        {
            throw await ThrowServiceExceptionAsync(exception);
        }
    }

    public static async Task<TResponse> PostJsonAsync<TResponse>(
        this string requestUrl,
        object body, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var response = await new Flurl.Url(requestUrl).PostJsonAsync<TResponse>(body, completionOption, cancellationToken);
        return response;
    }

    public static async Task<TResponse> PutJsonAsync<TResponse>(
        this Url requestUrl,
        object body, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .PutJsonAsync(body, completionOption, cancellationToken)
                .ReceiveJson<TResponse>();

            return response;
        }
        catch(FlurlHttpTimeoutException exception)
        {
            throw await ThrowServiceTimeoutExceptionAsync(exception);
        }
        catch (FlurlHttpException exception)
        {
            throw await ThrowServiceExceptionAsync(exception);
        }
    }

    public static async Task<TResponse> PutJsonAsync<TResponse>(
        this string requestUrl, 
        object body, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        var response = await new Flurl.Url(requestUrl).PutJsonAsync<TResponse>(body, completionOption, cancellationToken);

        return response;
    }

    public static async Task<TResponse> DeleteJsonAsync<TResponse>(
        this Url requestUrl, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .DeleteAsync(completionOption, cancellationToken)
                .ReceiveJson<TResponse>();

            return response;
        }
        catch(FlurlHttpTimeoutException exception)
        {
            throw await ThrowServiceTimeoutExceptionAsync(exception);
        }
        catch (FlurlHttpException exception)
        {
            throw await ThrowServiceExceptionAsync(exception);
        }
    }

    public static async Task<TResponse> DeleteJsonAsync<TResponse>(
        this string requestUrl, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        var response = await new Flurl.Url(requestUrl).DeleteJsonAsync<TResponse>(completionOption, cancellationToken);

        return response;
    }

    public static async Task<TResponse> PostMultipartAsync<TResponse>(
        this Url requestUrl,
        Action<CapturedMultipartContent> buildContent, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .PostMultipartAsync(buildContent, completionOption, cancellationToken)
                .ReceiveJson<TResponse>();

            return response;
        }
        catch(FlurlHttpTimeoutException exception)
        {
            throw await ThrowServiceTimeoutExceptionAsync(exception);
        }
        catch (FlurlHttpException exception)
        {
            throw await ThrowServiceExceptionAsync(exception);
        }
    }

    public static async Task<TResponse> PostMultipartAsync<TResponse>(
        this string requestUrl,
        Action<CapturedMultipartContent> buildContent, 
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, 
        CancellationToken cancellationToken = default)
    {
        var response = await new Url(requestUrl)
            .PostMultipartAsync<TResponse>(buildContent, completionOption, cancellationToken);

        return response;
    }

    public static async Task<byte[]> GetBytesFromRemoteAsync(
        this Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .GetBytesAsync(completionOption, cancellationToken);

            return response;
        }
        catch (FlurlHttpTimeoutException exception)
        {
            throw await ThrowServiceTimeoutExceptionAsync(exception);
        }
        catch(FlurlHttpException exception)
        {
            throw await ThrowServiceExceptionAsync(exception);
        }
    }

    public static async Task<byte[]> GetBytesFromRemoteAsync(
        this string requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        var response = await new Flurl.Url(requestUrl)
            .GetBytesFromRemoteAsync(completionOption, cancellationToken);

        return response;
    }
    
    private static async Task<ServiceTimeoutException> ThrowServiceTimeoutExceptionAsync(FlurlHttpTimeoutException exception)
    {
        var exceptionMessage = await exception.GetResponseStringAsync();
        return new ServiceTimeoutException(exceptionMessage);
    }
    
    private static async Task<ServiceException> ThrowServiceExceptionAsync(FlurlHttpException exception)
    {
        var exceptionMessage = await exception.GetResponseStringAsync();
        return new ServiceException(exceptionMessage);
    }
}