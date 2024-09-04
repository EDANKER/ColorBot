using System.Drawing;
using TriggerValoran.Interface.IColorServices;
using TriggerValoran.Model.Color.RedColor;
using TriggerValoran.Model.Color.YellowColor;

namespace TriggerValoran.Service.ColorServices;

public class ColorServices(Model.Color.Color purpleColor, YellowColor yellowColor, RedColor redColor) : IColorServices
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

                for (int i = x - boxSizeX; i < x + boxSizeX;)
                {
                    for (int j = y - boxSizeY; j < y + boxSizeY; j++)
                    {
                        Color color = bitmap.GetPixel(i, j);

                        if (purpleColor.CreateColor(color) && boxColor == "Red")
                        {
                            foundColor = true;
                            break;
                        }

                        if (yellowColor.CreateColor(color) && boxColor == "Yellow")
                        {
                            foundColor = true;
                            break;
                        }

                        if (redColor.CreateColor(color) && boxColor == "Purple")
                        {
                            foundColor = true;
                            break;
                        }
                    }

                    break;
                }

                return foundColor;
            }

            return false;
        }
        catch(Exception)
        {
            return false;
        }
    }
}