namespace TriggerValoran.Model.MemoryButton;

public class MemoryButton(byte name, byte button)
{
    public byte Name { get; set; } = name;
    public byte Button { get; set; } = button;
}