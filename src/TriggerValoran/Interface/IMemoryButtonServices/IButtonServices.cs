using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interface.IMemoryButtonServices;

public interface IButtonServices
{
    bool ItemButtonClickFire(byte memoryButton, int count, byte up, byte down,
        int sleepFire);

    bool ItemButtonClickWalk(List<byte> memoryButtons, int count, byte up, byte down);
    bool ItemButtonClickSitDown(byte memoryButton, int count, byte up, byte down, int sleep);
    bool ItemButtonState(byte memoryButton);
    Dictionary<string, byte> ItemButtonAll();
}