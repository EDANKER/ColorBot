using System.Drawing;
using System.Windows;
using TriggerValoran.Interface.IScreenServices;
using Point = System.Drawing.Point;

namespace TriggerValoran.Service.ScreenServices;

public class ScreenServices : IScreenServices
{
    private readonly Bitmap _bitmap;
    private readonly double _primaryScreenWidth = SystemParameters.PrimaryScreenWidth;
    private readonly double _primaryScreenHeight = SystemParameters.PrimaryScreenHeight;
    public ScreenServices()
    {
        _bitmap = new Bitmap((int)_primaryScreenWidth, (int)_primaryScreenHeight);
    }
    
    public Bitmap? GetScreen()
    {
        try
        {
            Graphics graphics = Graphics.FromImage(_bitmap);
            graphics.CopyFromScreen(Point.Empty, Point.Empty, _bitmap.Size);
            return _bitmap;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}