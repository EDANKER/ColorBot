using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interface.IEvenClickServices;

public interface IEvenServices
{
    bool Fire(int count, byte memoryButton, int sleepRepeatFire, int sleepOneFire, byte up, byte down);
    bool WalkStop(int count, List<byte> memoryButtons, byte up, byte down);
    bool SitDown(int count, byte memoryButton, int sleep, byte up, byte down);
    bool ClickForStart(byte memoryButton);
    List<MemoryButton> ItemButtonAll();
}