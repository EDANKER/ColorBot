using TriggerValoran.Interfase.IMemoryButtonServices;
using TriggerValoran.Interfase.IWorkWithServices;
using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.SettingsButton;

namespace TriggerValoran.Service.ButtonServices;

public class ButtonServices() : IButtonServices
{
    public bool ItemButtonClick(byte memoryButton, byte state)
    {
        try
        {
            DllServices.DllServices.keybd_event(memoryButton, 0, state, IntPtr.Zero);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool ItemButtonState(byte memoryButton)
    {
        try
        {
            return DllServices.DllServices.GetKeyState(SettingsButton.Start) > 2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<MemoryButton> ItemButtonAll()
    {
        throw new NotImplementedException();
    }
}