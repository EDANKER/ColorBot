using System.Drawing;
using TriggerValoran.Interfase.IColorServices;
using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Interfase.IJsonServices;
using TriggerValoran.Interfase.IScreenServices;
using TriggerValoran.Interfase.IWorkWithServices;
using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.WorkWithServices;

public class WorkWithServices(
    IColorServices colorServices,
    IEvenServices evenServices,
    IScreenServices screenServices,
    IJsonServices<TriggerSettings> TjsonServices,
    IJsonServices<MemoryButton> BjsonServices) : IWorkWithServices
{
    private TriggerSettings _triggerSettings;
    
    public bool Start(TriggerSettings triggerSettings)
    {
        _triggerSettings = triggerSettings;
        Bitmap? bitmap = screenServices.GetScreen();
        if (bitmap != null)
            return colorServices.ItemColor(bitmap,
                _triggerSettings.BoxSizeX, _triggerSettings.BoxSizeY, _triggerSettings.BoxColor);
        return false;
    }

    public bool SitDown()
    {
        return evenServices.SitDown(1, _triggerSettings.SettingsButton.SitDown, 50);
    }

    public bool WalkStop()
    {
        return evenServices.WalkStop(1, _triggerSettings.SettingsButton.Move, 0);
    }

    public bool Fire(int count, int sleepRepeatFire, int sleepOneFire)
    {
        return evenServices.Fire(1, _triggerSettings.SettingsButton.Fire, sleepRepeatFire, sleepOneFire);
    }

    public bool ClickForStart()
    {
        return evenServices.ClickForStart(_triggerSettings.SettingsButton.Fire);
    }

    public bool SaveSettings(List<TriggerSettings> item, string file)
    {
        bool isSave = TjsonServices.Ser(item, file);
        if (!isSave)
            throw new NullReferenceException();
        return isSave;
    }

    public TriggerSettings GetSaveSettings(string file)
    {
        TriggerSettings? triggerSettings = TjsonServices.Des(file);
        if (triggerSettings == null)
            throw new NullReferenceException();
        return triggerSettings;
    }

    public bool SaveButton(string file)
    {
        bool isSave = BjsonServices.Ser(evenServices.ItemButtonAll(), file);
        if (!isSave)
            throw new NullReferenceException();
        return isSave;
    }

    public MemoryButton GetSaveButton(string file)
    {
        MemoryButton? memoryButton = BjsonServices.Des(file);
        if (memoryButton == null)
            throw new NullReferenceException();
        return memoryButton;
    }
}