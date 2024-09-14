using System.Drawing;
using TriggerValoran.Interface.IColorServices;

namespace TriggerValoran.Service.ColorServices;

public class ColorServices(Abstract.Color.Color purpleColor, Abstract.Color.Color yellowColor, Abstract.Color.Color redColor) : IColorServices
{
    public bool ItemColor(Bitmap? bitmap, int boxSizeX, int boxSizeY, string boxColor)
    {
        try
        {
            bool foundColor = false;
            if (bitmap != null)
            {
                int x = bitmap.Width / 2;
                int y = bitmap.Height / 2;

                for (int i = x - boxSizeX; i < x + boxSizeX; i++)
                {
                    for (int j = y - boxSizeY; j < y + boxSizeY; j++)
                    {
                        Color color = bitmap.GetPixel(i, j);

                        if (purpleColor.SelectColor(color) && boxColor == "Red")
                        {
                            foundColor = true;
                            break;
                        }

                        if (yellowColor.SelectColor(color) && boxColor == "Yellow")
                        {
                            foundColor = true;
                            break;
                        }

                        if (redColor.SelectColor(color) && boxColor == "Purple")
                        {
                            foundColor = true;
                            break;
                        }
                    }
                }
            }

            return foundColor;
        }
        catch(Exception)
        {
            return false;
        }
    }
}