using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Interfase.IMemoryButtonServices;

public interface IButtonServices
{
    bool Save();
    MemoryButton GetButton();
    bool ItemButtonClick(byte memoryButton, byte up, byte down);
    bool ItemButtonState(byte memoryButton);
    List<byte> ItemButtonAll();
}