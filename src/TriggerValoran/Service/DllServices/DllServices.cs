using System.Runtime.InteropServices;

namespace TriggerValoran.Service.DllServices;

public static class DllServices
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(int dwFlags, uint dx, uint by, uint uButton, uint info);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void keybd_event(byte bu, byte scan, uint by, IntPtr uButton);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetKeyState(int key);
}