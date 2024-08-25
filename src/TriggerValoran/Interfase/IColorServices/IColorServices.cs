using System.Drawing;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interfase.IColorServices;

public interface IColorServices
{
    bool ItemColor(Bitmap? bitmap, int boxSizeX, int boxSizeY, string boxColor);
}