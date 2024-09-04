namespace TriggerValoran.Model.Color.PurpleColor;

public class PurpleColor : Color
{
    public override bool CreateColor(System.Drawing.Color color)
    {
        int diff = Math.Abs(color.R - color.B);
        return (color.B >= 128) && (color.G <= 100) && (diff <= 50);
    }
}