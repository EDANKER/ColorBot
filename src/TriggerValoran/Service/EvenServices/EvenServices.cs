using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IMemoryButtonServices;
using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Service.EvenServices;

public class EvenServices(IButtonServices buttonServices) : IEvenServices
{
    public bool Fire(int count, byte memoryButton, int sleepRepeatFire, int sleepOneFire, byte up, byte down)
    {
        return buttonServices.ItemButtonClickUpDownFire(memoryButton, count, up, down, sleepRepeatFire, sleepOneFire);
    }

    public bool WalkStop(int count, List<byte> memoryButton, byte up, byte down)
    {
        for (int i = 0; i < memoryButton.Count; i++)
            buttonServices.ItemButtonClickUp(memoryButton[i], count, up, down);
        return true;
    }

    public bool SitDown(int count, byte memoryButton, int sleep, byte up, byte down)
    {
        return buttonServices.ItemButtonClickUpDownSitDown(memoryButton, count, up, down, sleep);
    }

    public bool ClickForStart(byte memoryButton)
    {
        return buttonServices.ItemButtonState(memoryButton);
    }

    public List<MemoryButton> ItemButtonAll()
    {
        return buttonServices.ItemButtonAll();
    }
}