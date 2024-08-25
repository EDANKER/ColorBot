using System.Drawing;
using System.Windows;
using TriggerValoran.Interfase.IColorServices;
using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Interfase.IJsonServices;
using TriggerValoran.Interfase.IScreenServices;
using TriggerValoran.Interfase.IWorkWithServices;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.WorkWithServices;

public class WorkWithServices(
    IColorServices colorServices,
    IEvenServices evenServices,
    IScreenServices screenServices,
    IJsonServices<TriggerSettings> jsonServices) : IWorkWithServices
{
    private IJsonServices<TriggerSettings> _jsonServices = jsonServices;
    private IColorServices ColorServices { get; } = colorServices;
    private IEvenServices EvenServices { get; } = evenServices;
    private IScreenServices ScreenServices { get; } = screenServices;

    public bool Start(TriggerSettings triggerSettings)
    {
        Bitmap? bitmap = ScreenServices.GetScreen();
        if (bitmap != null)
            return ColorServices.ItemColor(bitmap,
                triggerSettings.BoxSizeX, triggerSettings.BoxSizeY, triggerSettings.BoxColor);
        return false;
    }

    public bool SitDown()
    {
        return EvenServices.SitDown();
    }

    public bool WalkStop()
    {
        return EvenServices.WalkStop();
    }

    public bool Fire(int count, int sleepRepeatFire, int sleepOneFire)
    {
        return EvenServices.Fire(count, sleepRepeatFire, sleepOneFire);
    }
    
    public bool ClickForStart()
    {
        return EvenServices.ClickForStart();
    }

    public bool Save(TriggerSettings triggerSettings)
    {
        bool isSave = _jsonServices.Ser(triggerSettings);
        if (!isSave)
            throw new NullReferenceException();
        
        return _jsonServices.Ser(triggerSettings);
    }

    public TriggerSettings GetSave()
    {
        TriggerSettings? triggerSettings = _jsonServices.Des();
        if (triggerSettings == null)
            throw new NullReferenceException();
        
        return triggerSettings;
    }
}