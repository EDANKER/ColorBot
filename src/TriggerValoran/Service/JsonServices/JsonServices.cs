using System.IO;
using Newtonsoft.Json;
using TriggerValoran.Interfase.IJsonServices;

namespace TriggerValoran.Service.JsonServices;

public class JsonServices<T> : IJsonServices<T>
{
    public T? Des()
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(
                File.ReadAllText("dataTrigger.json"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    public bool Ser(T item)
    {
        try
        {
            using StreamWriter streamWriter = File.CreateText("dataTrigger.json");
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(streamWriter, item);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}