using TriggerValoran.Interfase.IMemoryButtonServices;
using TriggerValoran.Interfase.IWorkWithServices;
using TriggerValoran.Model.MemoryButton;

namespace TriggerValoran.Service.MemoryButtonServices;

public class ButtonServices(IWorkWithServices<MemoryButton> workWithServices) : IButtonServices
{
    private IWorkWithServices<MemoryButton> _workWithServices = workWithServices;

    public bool Save()
    {
        try
        {
            _workWithServices.SaveSettings();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public MemoryButton GetButton()
    {
        return _workWithServices.GetSaveSettings();
    }

    public bool ItemButtonClick(byte memoryButton, byte up, byte down)
    {
        throw new NotImplementedException();
    }

    public bool ItemButtonState(byte memoryButton)
    {
        throw new NotImplementedException();
    }

    public List<byte> ItemButtonAll()
    {
        throw new NotImplementedException();
    }
}