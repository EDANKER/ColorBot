namespace TriggerValoran.Model.TriggerSettings;

public class TriggerSettings(int count, int boxSizeX, int boxSizeY, int sleepTimeRepeatFire, int sleepTimeOneFire, string boxColor, bool sitDown, bool walkStop, SettingsButton.SettingsButton settingsButton)
{
    public int Count { get; set; } = count;
    public int BoxSizeX { get; set; } = boxSizeX;
    public int BoxSizeY { get; set; } = boxSizeY;
    public int SleepTimeRepeatFire { get; set; } = sleepTimeRepeatFire;
    public int SleepTimeOneFire { get; set; } = sleepTimeOneFire;
    public string BoxColor { get; set; } = boxColor;
    public bool SitDown { get; set; } = sitDown;
    public bool WalkStop { get; set; } = walkStop;
    public SettingsButton.SettingsButton SettingsButton { get; set; } = settingsButton;
}