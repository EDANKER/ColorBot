using System.Drawing;
using TriggerValoran.Interface.IColorServices;
using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IJsonServices;
using TriggerValoran.Interface.IScreenServices;
using TriggerValoran.Interface.IWorkWithServices;
using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.WorkWithServices;

public class WorkWithServices(
    IColorServices colorServices,
    IEvenServices evenServices,
    IScreenServices screenServices,
    IJsonServices<TriggerSettings> tJsonServices,
    IJsonServices<List<MemoryButton>> bJsonServices) : IWorkWithServices
{
    private readonly string _file = "dataButton.json";

    public bool Start(TriggerSettings triggerSettings)
    {
        Bitmap? bitmap = screenServices.GetScreen();
        if (bitmap != null)
            return colorServices.ItemColor(bitmap,
                triggerSettings.BoxSizeX, triggerSettings.BoxSizeY, triggerSettings.BoxColor);
        return false;
    }

    public bool SitDown(TriggerSettings triggerSettings)
    {
        return evenServices.SitDown(1, GetSaveButton(_file)[0].Button, 50,
            0x21, 0x22);
    }

    public bool WalkStop(TriggerSettings triggerSettings)
    {
        List<byte> bytesButton = new List<byte>();
        for (int i = 2; i < GetSaveButton(_file).Count; i++)
            bytesButton.Add(GetSaveButton(_file)[i].Button);
        return evenServices.WalkStop(1, bytesButton, 0x22,
            0x21);
    }

    public bool Fire(TriggerSettings triggerSettings, int count, int sleepRepeatFire, int sleepOneFire)
    {
        return evenServices.Fire(1, GetSaveButton(_file)[1].Button, sleepRepeatFire, sleepOneFire,
            0x21, 0x22);
    }

    public bool ClickForStart(TriggerSettings triggerSettings)
    {
        return evenServices.ClickForStart(0x22);
    }

    public bool SaveSettings(TriggerSettings item, string file)
    {
        bool isSave = tJsonServices.Ser(item, file);
        if (!isSave)
            throw new NullReferenceException();
        return isSave;
    }

    public TriggerSettings GetSaveSettings(string file)
    {
        TriggerSettings? triggerSettings = tJsonServices.Des(file);
        if (triggerSettings == null)
            throw new NullReferenceException();
        return triggerSettings;
    }

    public bool SaveButton(string file)
    {
        bool isSave = bJsonServices.Ser(evenServices.ItemButtonAll(), file);
        if (!isSave)
            throw new NullReferenceException();
        return isSave;
    }

    public List<MemoryButton> GetSaveButton(string file)
    {
        List<MemoryButton>? memoryButton = bJsonServices.Des(file);
        if (memoryButton == null)
            throw new NullReferenceException();
        return memoryButton;
    }
}