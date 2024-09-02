namespace TriggerValoran.Model.MemoryButton;

public class MemoryButton(string name, byte button)
{
    public string Name { get; set; } = name;
    public byte Button { get; set; } = button;
}