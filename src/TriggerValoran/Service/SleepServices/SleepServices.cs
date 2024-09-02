using TriggerValoran.Interfase.ISleepServices;

namespace TriggerValoran.Service.SleepServices;

public class SleepServices : ISleepServices
{
    public void Sleep(int sleep)
    {
        Thread.Sleep(sleep);
    }
}