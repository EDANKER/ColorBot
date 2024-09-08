using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IMemoryButtonServices;

namespace TriggerValoran.Service.EvenServices;

public class EvenServices(IButtonServices buttonServices) : IEvenServices
{
    public bool Fire(int count, byte memoryButton, int sleepRepeatFire, int sleepOneFire, byte up, byte down)
    {
        return buttonServices.ItemButtonClickFire(memoryButton, count, up, down, sleepRepeatFire, sleepOneFire);
    }

    public bool WalkStop(int count, List<byte> memoryButton, byte up, byte down)
    {
        return buttonServices.ItemButtonClickWalk(memoryButton, count, up, down);
    }

    public bool SitDown(int count, byte memoryButton, int sleep, byte up, byte down)
    {
        return buttonServices.ItemButtonClickSitDown(memoryButton, count, up, down, sleep);
    }

    public bool ClickForStart(byte memoryButton)
    {
        return buttonServices.ItemButtonState(memoryButton);
    }

    public Dictionary<string, byte> ItemButtonAll()
    {
        return buttonServices.ItemButtonAll();
    }
}