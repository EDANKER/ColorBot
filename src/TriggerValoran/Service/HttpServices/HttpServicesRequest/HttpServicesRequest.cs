using System.Net;
using System.Net.Http;
using TriggerValoran.Interface.IHttpServicesRequest;

namespace TriggerValoran.Service.HttpServices.HttpServicesRequest;

public class HttpServicesRequest(
    HttpClient httpClient,
    HttpRequestMessage httpRequestMessage,
    HttpResponseMessage httpResponseMessage)
    : IHttpServicesRequest
{
    public string? GetState(string path, string point, int idUser)
    {
        try
        {
            httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, path + point);
            httpClient.Send(httpRequestMessage);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                return httpResponseMessage.Content.ReadAsStringAsync().Result;
            return null;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}