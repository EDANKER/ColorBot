using TriggerValoran.Interface.IMemoryButtonServices;
using TriggerValoran.Interface.ISleepServices;
using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Service.ButtonServices;

public class ButtonServices(ISleepServices sleepServices) : IButtonServices
{

    private void UseDll(byte memoryButton, int count, byte up, byte down, int state)
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
    }

    public bool ItemButtonClickUpDownFire(byte memoryButton, int count, byte up, byte down, int sleepRepeatFire,
        int sleepOneFire)
    {
        try
        {
            sleepServices.Sleep(sleepOneFire);
            UseDll(memoryButton, count, up, down, 1);
            sleepServices.Sleep(sleepRepeatFire);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool ItemButtonClickUp(byte memoryButton, int count, byte up, byte down)
    {
        try
        {
            UseDll(memoryButton, count, up, down, 2);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool ItemButtonClickUpDownSitDown(byte memoryButton, int count, byte up, byte down, int sleep)
    {
        try
        {
            sleepServices.Sleep(sleep);
            UseDll(memoryButton, count, up, down, 1);
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
            return DllServices.DllServices.GetKeyState(memoryButton) > 2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public Dictionary<string, byte> ItemButtonAll()
    {
        MemoryButton memoryButton = new MemoryButton("Ctrl", 0x22);
        Dictionary<string, byte> dictionary = new Dictionary<string, byte>();
        dictionary.Add(memoryButton.Name, memoryButton.Button);
        return dictionary;
    }
}