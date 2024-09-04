namespace TriggerValoran.Interface.IJsonServices;

public interface IJsonServices<T>
{
    T? Des(string file);
    T? DesInNetwork(string json);
    bool Ser(T item, string file);
}