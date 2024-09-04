using TriggerValoran.Model.DataStateUser;

namespace TriggerValoran.Interface.IHttpServicesRequest;

public interface IHttpServicesRequest
{
    string? GetState(string path, string point, int idUser);
}