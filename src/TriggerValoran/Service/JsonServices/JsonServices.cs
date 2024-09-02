using System.IO;
using Newtonsoft.Json;
using TriggerValoran.Interface.IJsonServices;

namespace TriggerValoran.Service.JsonServices;

public class JsonServices<T> : IJsonServices<T>
{
    public T? Des(string file)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(
                File.ReadAllText(file));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    public bool Ser(List<T> item, string file)
    {
        try
        {
            using StreamWriter streamWriter = File.CreateText(file);
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