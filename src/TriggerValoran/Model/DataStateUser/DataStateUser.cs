namespace TriggerValoran.Model.DataStateUser;

public class DataStateUser(string name, int time, string day, string versionCheat, string nameCheat)
{
    public string Name { get; set; } = name;
    public int Time { get; set; } = time;
    public string Day { get; set; } = day;
    public string VersionCheat { get; set; } = versionCheat;
    public string NameCheat { get; set; } = nameCheat;
}