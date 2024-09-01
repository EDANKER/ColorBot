using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interfase.IMemoryButtonServices;

public interface IButtonServices
{
    bool ItemButtonClick(byte memoryButton, byte state);
    bool ItemButtonState(byte memoryButton);
    List<MemoryButton> ItemButtonAll();
}