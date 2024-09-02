using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IMemoryButtonServices;
using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Service.EvenServices;

public class EvenServices(IButtonServices buttonServices) : IEvenServices
{
    public bool Fire(int count, byte memoryButton, int sleepRepeatFire, int sleepOneFire, byte up, byte down)
    {
        return buttonServices.ItemButtonClick(memoryButton, 1, 1, up, down);
    }

    public bool WalkStop(int count, List<byte> memoryButton, int sleep, byte up, byte down)
    {
        for (int i = 0; i < memoryButton.Count; i++)
            buttonServices.ItemButtonClick(memoryButton[i], 0, count, up, down);
        return true;
    }

    public bool SitDown(int count, byte memoryButton, int sleep, byte up, byte down)
    {
        return buttonServices.ItemButtonClick(memoryButton, 1, count, up, down);
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