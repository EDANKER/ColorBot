using TriggerValoran.Interface.IHttpServices;
using TriggerValoran.Interface.IHttpServicesRequest;
using TriggerValoran.Model.DataStateUser;

namespace TriggerValoran.Service.HttpServices;

public class HttpServices(IHttpServicesRequest httpServicesRequest) : IHttpServices
{
    public string? Get(string path, int idUser)
    {
        return httpServicesRequest.GetState(path, $"/user/{idUser}", idUser);
    }
}