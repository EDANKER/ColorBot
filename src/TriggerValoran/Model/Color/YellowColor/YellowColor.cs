namespace TriggerValoran.Model.Color.YellowColor;

public class YellowColor : Color
{
    public override bool CreateColor(System.Drawing.Color color)
    {
        int diff = Math.Abs(color.R - color.G);
        return (color.R >= 128) && (color.G >= 128) && (color.B <= 100) && (diff <= 50);
    }
}