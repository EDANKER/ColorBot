using System.Drawing;
using TriggerValoran.Interfase.IColorServices;
using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Interfase.IJsonServices;
using TriggerValoran.Interfase.IMemoryButtonServices;
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
    IJsonServices<MemoryButton> BjsonServices,
    IButtonServices buttonServices) : IWorkWithServices
{
    public bool Start(TriggerSettings triggerSettings)
    {
        Bitmap? bitmap = screenServices.GetScreen();
        if (bitmap != null)
            return colorServices.ItemColor(bitmap,
                triggerSettings.BoxSizeX, triggerSettings.BoxSizeY, triggerSettings.BoxColor);
        return false;
    }

    public bool SitDown()
    {
        return evenServices.SitDown();
    }

    public bool WalkStop()
    {
        return evenServices.WalkStop();
    }

    public bool Fire(int count, int sleepRepeatFire, int sleepOneFire)
    {
        return evenServices.Fire(count, sleepRepeatFire, sleepOneFire);
    }

    public bool ClickForStart()
    {
        return evenServices.ClickForStart();
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
        throw new NotImplementedException();
    }

    public MemoryButton GetSaveButton(string file)
    {
        throw new NotImplementedException();
    }
}