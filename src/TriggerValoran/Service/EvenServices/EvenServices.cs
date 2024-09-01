using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Interfase.IMemoryButtonServices;

namespace TriggerValoran.Service.EvenServices;

public class EvenServices(IButtonServices buttonServices) : IEvenServices
{
    public bool Fire(int count, int sleepRepeatFire, int sleepOneFire)
    {
        return buttonServices.ItemButtonClick();
    }

    public bool WalkStop()
    {
        return buttonServices.ItemButtonClick();
    }

    public bool SitDown()
    {
        return buttonServices.ItemButtonClick();
    }

    public bool ClickForStart()
    {
        return buttonServices.ItemButtonState();
    }
}