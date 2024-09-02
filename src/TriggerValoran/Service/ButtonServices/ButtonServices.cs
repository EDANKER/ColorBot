using TriggerValoran.Interfase.IMemoryButtonServices;
using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.SettingsButton;

namespace TriggerValoran.Service.ButtonServices;

public class ButtonServices() : IButtonServices
{
    private static byte Start { get; set; }
    
    public bool ItemButtonClick(byte memoryButton, int state, int count)
    {
        try
        {
            for (int i = 0; i < count; i++)
            {
                if (state == 1)
                {
                    DllServices.DllServices.keybd_event(memoryButton, 0, 0x20, IntPtr.Zero);
                    DllServices.DllServices.keybd_event(memoryButton, 0, 0x21, IntPtr.Zero);
                }
                else
                {
                    DllServices.DllServices.keybd_event(memoryButton, 0, 0x20, IntPtr.Zero);
                }
            }
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
            return DllServices.DllServices.GetKeyState(Start) > 2;
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