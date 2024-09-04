using TriggerValoran.Model.DataStateUser;

namespace TriggerValoran.Interface.IHttpServices;

public interface IHttpServices
{
    string? Get(string path, int idUser);
}