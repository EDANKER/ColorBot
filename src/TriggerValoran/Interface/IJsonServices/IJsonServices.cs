namespace TriggerValoran.Interface.IJsonServices;

public interface IJsonServices<T>
{
    T? Des(string file);
    bool Ser(List<T> item, string file);
}