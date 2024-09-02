using TriggerValoran.Interface.IMemoryButtonServices;
using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.SettingsButton;

namespace TriggerValoran.Service.ButtonServices;

public class ButtonServices() : IButtonServices
{
    private static byte Start { get; set; }
    
    public bool ItemButtonClick(byte memoryButton, int state, int count, byte up, byte down)
    {
        try
        {
            for (int i = 0; i < count; i++)
            {
                if (state == 1)
                {
                    DllServices.DllServices.keybd_event(memoryButton, 0, down, IntPtr.Zero);
                    DllServices.DllServices.keybd_event(memoryButton, 0, up, IntPtr.Zero);
                }
                else
                {
                    DllServices.DllServices.keybd_event(memoryButton, 0, up, IntPtr.Zero);
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
        MemoryButton memoryButton = new MemoryButton("Ctrl", 0x22);
        List<MemoryButton> list = new List<MemoryButton>();
        list.Add(memoryButton);
        return list;
    }
}