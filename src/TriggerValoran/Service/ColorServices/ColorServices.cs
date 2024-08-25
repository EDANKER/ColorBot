using System.Drawing;
using TriggerValoran.Interfase.IColorServices;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.ColorServices;

public class ColorServices : IColorServices
{
    private bool Red(Color color)
    {
        int diffRedG = Math.Abs(color.R - color.G);
        int diffRedB = Math.Abs(color.R - color.B);

        return (color.R >= 200) && (color.G <= 50) && (color.B <= 50) && (diffRedG >= 100) && (diffRedB >= 100);
    }

    private bool Purple(Color color)
    {
        int diff = Math.Abs(color.R - color.B);

        return (color.B >= 128) && (color.G <= 100) && (diff <= 50);
    }

    private bool Yellow(Color color)
    {
        int diff = Math.Abs(color.R - color.G);

        return (color.R >= 128) && (color.G >= 128) && (color.B <= 100) && (diff <= 50);
    }

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

                        if (Red(color) && boxColor == "Red")
                        {
                            foundColor = true;
                            break;
                        }

                        if (Yellow(color) && boxColor == "Yellow")
                        {
                            foundColor = true;
                            break;
                        }

                        if (Purple(color) && boxColor == "Purple")
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
        catch
        {
            return false;
        }
    }
}