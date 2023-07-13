using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;

public class ElasticsearchMiddleware
{
    private readonly RequestDelegate _next;

    public ElasticsearchMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        var elasticserarch = context.RequestServices.GetRequiredService<IElasticsearchService>();
        var requestObj = GetBodyAsync(context.Request.Body).Result;
        var responseObj = GetBodyAsync(context.Response.Body).Result;

        var controllerActionDescriptor = context.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();

        var requestType = GetRequestType(controllerActionDescriptor);

        var objectRequestClass = Activator.CreateInstance(requestType); // Aqui está criando classe do parametro do controller  corretamente

        objectRequestClass = JsonConvert.DeserializeObject(requestObj,requestType);

        var indexName = requestType?.Name.ToLower();

        elasticserarch.IndexRequestResponse(objectRequestClass, responseObj, indexName);
    }

    private async Task<string> GetBodyAsync(Stream bodyStream)
    {
        bodyStream.Seek(0, SeekOrigin.Begin);
        using (StreamReader reader = new StreamReader(bodyStream, Encoding.UTF8))
        {
            string body = await reader.ReadToEndAsync();
            return body;
        }
    }

    private Type GetRequestType(ControllerActionDescriptor actionDescriptor)
    {
        var parameters = actionDescriptor?.MethodInfo.GetParameters();

        var requestParameter = parameters?.FirstOrDefault();

        return requestParameter?.ParameterType;
    }

    //TO DO

    // Não funciona , verificar
    //private Type GetResponseType (ControllerActionDescriptor actionDescriptor)
    //{
    //    var returnType = actionDescriptor?.MethodInfo.ReturnType;
    //    var methodInfo = actionDescriptor?.MethodInfo;

    //    if (returnType == typeof(ObjectResult))
    //    {
    //        var objectResultType = methodInfo.GetGenericArguments()[0];

    //        return objectResultType;
    //    }
    //    return null;

    //}
}