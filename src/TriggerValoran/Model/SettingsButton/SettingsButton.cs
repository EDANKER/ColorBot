namespace TriggerValoran.Model.SettingsButton;

public class SettingsButton(string start, string fire, string sitDown, List<string> move)
{
    public string Start { get; set; } = start;
    public string Fire { get; set; } = fire;
    public string SitDown { get; set; } = sitDown;

    public List<string> Move { get; set; } = move;
}