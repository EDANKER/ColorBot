using TriggerValoran.Model.DataStateUser;

namespace TriggerValoran.Interface.IHttpServicesRequest;

public interface IHttpServicesRequest
{
    DataStateUser GetState(string path, string point, int idUser);
}