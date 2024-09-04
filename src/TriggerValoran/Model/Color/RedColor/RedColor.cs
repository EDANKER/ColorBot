namespace TriggerValoran.Model.Color.RedColor;

public class RedColor : Color
{
    public override bool CreateColor(System.Drawing.Color color)
    {
        int diffRedG = Math.Abs(color.R - color.G);
        int diffRedB = Math.Abs(color.R - color.B);
        return (color.R >= 200) && (color.G <= 50) && (color.B <= 50) && (diffRedG >= 100) && (diffRedB >= 100);
    }
}