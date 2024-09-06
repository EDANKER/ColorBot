namespace TriggerValoran.Model.Color.RedColor;

public class RedColor : Abstract.Color.Color
{
    public override bool SelectColor(System.Drawing.Color color)
    {
        int diff = Math.Abs(color.R - color.B);
        return (color.B >= 128) && (color.G <= 100) && (diff <= 50);
    }
}