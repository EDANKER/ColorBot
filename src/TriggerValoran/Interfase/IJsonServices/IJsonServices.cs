namespace TriggerValoran.Interfase.IJsonServices;

public interface IJsonServices<T>
{
    T? Des(string file);
    bool Ser(T item, string file);
}