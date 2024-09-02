using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interfase.IEvenClickServices;

public interface IEvenServices
{
    bool Fire(int count, byte memoryButton, int sleepRepeatFire, int sleepOneFire);
    bool WalkStop(int count, List<byte> memoryButtons, int sleep);
    bool SitDown(int count, byte memoryButton, int sleep);
    bool ClickForStart(byte memoryButton);
    List<MemoryButton> ItemButtonAll();
}