using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Interfase.IMemoryButtonServices;
using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Service.EvenServices;

public class EvenServices(IButtonServices buttonServices) : IEvenServices
{
    public bool Fire(int count, byte memoryButton, int sleepRepeatFire, int sleepOneFire)
    {
        return buttonServices.ItemButtonClick(memoryButton, 1, 1);
    }

    public bool WalkStop(int count, List<byte> memoryButton, int sleep)
    {
        for (int i = 0; i < memoryButton.Count; i++)
            buttonServices.ItemButtonClick(memoryButton[i], 0, count);
        return true;
    }

    public bool SitDown(int count, byte memoryButton, int sleep)
    {
        return buttonServices.ItemButtonClick(memoryButton, 1, count);
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