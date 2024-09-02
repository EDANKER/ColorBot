using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interfase.IMemoryButtonServices;

public interface IButtonServices
{
    bool ItemButtonClick(byte memoryButton, int state, int count);
    bool ItemButtonState(byte memoryButton);
    List<MemoryButton> ItemButtonAll();
}