using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Model.MemoryIntButton;

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
                DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardV, 0, ButtonMemory.KeyDown, IntPtr.Zero);
                DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardV, 0, ButtonMemory.KeyUp, IntPtr.Zero);
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
            DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardW, 0, ButtonMemory.KeyUp, IntPtr.Zero);
            DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardA, 0, ButtonMemory.KeyUp, IntPtr.Zero);
            DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardD, 0, ButtonMemory.KeyUp, IntPtr.Zero);
            DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardS, 0, ButtonMemory.KeyUp, IntPtr.Zero);

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
            DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardCtrl, 0, ButtonMemory.KeyDown, IntPtr.Zero);
            Thread.Sleep(500);
            DllServices.DllServices.keybd_event(ButtonMemory.KeyBoardCtrl, 0, ButtonMemory.KeyUp, IntPtr.Zero);

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
            if (DllServices.DllServices.GetKeyState(ButtonMemory.KeyLeftShift) > 2)
                return true;

            return false;
        }
        catch
        {
            return false;
        }
    }
}