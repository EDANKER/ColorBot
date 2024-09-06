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

    public T? DesInNetwork(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    public bool Ser(T item, string file)
    {
        try
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(item));
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}