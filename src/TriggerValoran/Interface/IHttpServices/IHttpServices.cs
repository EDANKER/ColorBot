using TriggerValoran.Model.DataStateUser;

namespace TriggerValoran.Interface.IHttpServices;

public interface IHttpServices
{
    DataStateUser Get(string path, int idUser);
}