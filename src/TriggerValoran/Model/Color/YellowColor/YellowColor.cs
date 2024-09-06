namespace TriggerValoran.Model.Color.YellowColor;

public class YellowColor : Abstract.Color.Color
{
    public override bool SelectColor(System.Drawing.Color color)
    {
        int diff = Math.Abs(color.R - color.G);
        return (color.R >= 128) && (color.G >= 128) && (color.B <= 100) && (diff <= 50);
    }
}