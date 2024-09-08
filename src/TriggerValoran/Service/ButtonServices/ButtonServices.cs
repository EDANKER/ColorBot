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

    public bool ItemButtonClickFire(byte memoryButton, int count, byte up, byte down, int sleepRepeatFire,
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

    public bool ItemButtonClickWalk(List<byte> memoryButtons, int count, byte up, byte down)
    {
        try
        {
            for (int i = 0; i < memoryButtons.Count; i++)
                UseDll(memoryButtons[i], count, up, down, 2);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool ItemButtonClickSitDown(byte memoryButton, int count, byte up, byte down, int sleep)
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
        MemoryButton memoryButton = new MemoryButton("V", 0x56);
        Dictionary<string, byte> dictionary = new Dictionary<string, byte>();
        dictionary.Add("V", 0x56);
        dictionary.Add("Ctrl", 0x11);
        dictionary.Add("Shift", 0xA0);
        return dictionary;
    }
}