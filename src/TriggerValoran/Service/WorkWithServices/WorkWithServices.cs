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
    IJsonServices<MemoryButton> bJsonServices) : IWorkWithServices
{

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
        return evenServices.SitDown(1, triggerSettings.SettingsButton.SitDown, 50,
            triggerSettings.SettingsButton.KeyUp, triggerSettings.SettingsButton.KeyUp);
    }

    public bool WalkStop(TriggerSettings triggerSettings)
    {
        return evenServices.WalkStop(1, triggerSettings.SettingsButton.Move, 0, triggerSettings.SettingsButton.KeyUp,
            triggerSettings.SettingsButton.KeyUp);
    }

    public bool Fire(TriggerSettings triggerSettings, int count, int sleepRepeatFire, int sleepOneFire)
    {
        return evenServices.Fire(1, triggerSettings.SettingsButton.Fire, sleepRepeatFire, sleepOneFire,
            triggerSettings.SettingsButton.KeyUp, triggerSettings.SettingsButton.KeyUp);
    }

    public bool ClickForStart(TriggerSettings triggerSettings)
    {
        return evenServices.ClickForStart(triggerSettings.SettingsButton.Start);
    }

    public bool SaveSettings(List<TriggerSettings> item, string file)
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

    public MemoryButton GetSaveButton(string file)
    {
        MemoryButton? memoryButton = bJsonServices.Des(file);
        if (memoryButton == null)
            throw new NullReferenceException();
        return memoryButton;
    }
}