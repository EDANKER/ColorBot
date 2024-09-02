using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interface.IMemoryButtonServices;

public interface IButtonServices
{
    bool ItemButtonClick(byte memoryButton, int state, int count, byte up, byte down);
    bool ItemButtonState(byte memoryButton);
    List<MemoryButton> ItemButtonAll();
}