namespace TriggerValoran.Model.Color.PurpleColor;

public class PurpleColor : Abstract.Color.Color
{
    public override bool SelectColor(System.Drawing.Color color)
    {
        int diffRedG = Math.Abs(color.R - color.G);
        int diffRedB = Math.Abs(color.R - color.B);
        return (color.R >= 200) && (color.G <= 50) && (color.B <= 50) && (diffRedG >= 100) && (diffRedB >= 100);
    }
}