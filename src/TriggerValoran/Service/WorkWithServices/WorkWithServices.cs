using System.Drawing;
using System.Windows;
using TriggerValoran.Interfase.IColorServices;
using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Interfase.IJsonServices;
using TriggerValoran.Interfase.IScreenServices;
using TriggerValoran.Interfase.IWorkWithServices;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.WorkWithServices;

public class WorkWithServices<T>(
    IColorServices colorServices,
    IEvenServices evenServices,
    IScreenServices screenServices,
    IJsonServices<T> jsonServices) : IWorkWithServices<T>
{
    private IJsonServices<T> _jsonServices = jsonServices;
    private IColorServices ColorServices { get; } = colorServices;
    private IEvenServices EvenServices { get; } = evenServices;
    private IScreenServices ScreenServices { get; } = screenServices;

    public bool ItemButtonClick()
    {
        throw new NotImplementedException();
    }

    public bool ItemButtonState()
    {
        throw new NotImplementedException();
    }

    public List<byte> ItemButtonAll()
    {
        throw new NotImplementedException();
    }

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

    public bool SaveSettings(T item)
    {
        bool isSave = _jsonServices.Ser(item, "dataTrigger.json");
        if (!isSave)
            throw new NullReferenceException();
        return isSave;
    }

    public T GetSaveSettings()
    {
        T? triggerSettings = _jsonServices.Des("dataTrigger.json");
        if (triggerSettings == null)
            throw new NullReferenceException();
        return triggerSettings;
    }
}