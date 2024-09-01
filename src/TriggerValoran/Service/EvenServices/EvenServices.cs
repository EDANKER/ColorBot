using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Service.EvenServices;

public class EvenServices : IEvenServices
{
    public bool Fire(int count, int sleepRepeatFire, int sleepOneFire)
    {
        try
        {
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(sleepOneFire);
                DllServices.DllServices.keybd_event(MemoryButton.Fire, 0, MemoryButton.KeyDown, IntPtr.Zero);
                DllServices.DllServices.keybd_event(MemoryButton.Fire, 0, MemoryButton.KeyUp, IntPtr.Zero);
                Thread.Sleep(sleepRepeatFire);
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool WalkStop()
    {
        try
        {
            DllServices.DllServices.keybd_event(MemoryButton.Move[0], 0, MemoryButton.KeyUp, IntPtr.Zero);
            DllServices.DllServices.keybd_event(MemoryButton.Move[1], 0, MemoryButton.KeyUp, IntPtr.Zero);
            DllServices.DllServices.keybd_event(MemoryButton.Move[2], 0, MemoryButton.KeyUp, IntPtr.Zero);
            DllServices.DllServices.keybd_event(MemoryButton.Move[3], 0, MemoryButton.KeyUp, IntPtr.Zero);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool SitDown()
    {
        try
        {
            DllServices.DllServices.keybd_event(MemoryButton.SitDown, 0, MemoryButton.KeyDown, IntPtr.Zero);
            Thread.Sleep(500);
            DllServices.DllServices.keybd_event(MemoryButton.SitDown, 0, MemoryButton.KeyUp, IntPtr.Zero);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool ClickForStart()
    {
        try
        {
            if (DllServices.DllServices.GetKeyState(MemoryButton.Start) > 2)
                return true;
            return false;
        }
        catch(Exception)
        {
            return false;
        }
    }
}