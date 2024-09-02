using System.Drawing;

namespace TriggerValoran.Interface.IColorServices;

public interface IColorServices
{
    bool ItemColor(Bitmap? bitmap, int boxSizeX, int boxSizeY, string boxColor);
}