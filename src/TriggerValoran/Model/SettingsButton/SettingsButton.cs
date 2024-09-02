namespace TriggerValoran.Model.SettingsButton;

public class SettingsButton
{
    public int Start { get; set; }
    public byte Fire { get; set; }
    public byte SitDown { get; set; }

    public List<byte> Move { get; set; }
    public byte KeyUp { get; set; }
    public byte KeyDown { get; set; }
}