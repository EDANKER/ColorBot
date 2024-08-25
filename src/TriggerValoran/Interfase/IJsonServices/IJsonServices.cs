namespace TriggerValoran.Interfase.IJsonServices;

public interface IJsonServices<T>
{
    T? Des();
    bool Ser(T item);
}