using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interface.IMemoryButtonServices;

public interface IButtonServices
{
    bool ItemButtonClickUpDownFire(byte memoryButton, int count, byte up, byte down, int sleepRepeatFire,
        int sleepOneFire);

    bool ItemButtonClickUp(byte memoryButton, int count, byte up, byte down);
    bool ItemButtonClickUpDownSitDown(byte memoryButton, int count, byte up, byte down, int sleep);
    bool ItemButtonState(byte memoryButton);
    List<MemoryButton> ItemButtonAll();
}