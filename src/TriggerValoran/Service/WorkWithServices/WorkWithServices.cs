using System.Drawing;
using TriggerValoran.Interface.IColorServices;
using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IHttpServices;
using TriggerValoran.Interface.IJsonServices;
using TriggerValoran.Interface.IScreenServices;
using TriggerValoran.Interface.IWorkWithServices;
using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.WorkWithServices;

public class WorkWithServices(
    IColorServices colorServices,
    IEvenServices evenServices,
    IScreenServices screenServices,
    IJsonServices<TriggerSettings> tJsonServices,
    IJsonServices<Dictionary<string, byte>> bJsonServices,
    IJsonServices<DataStateUser?> gJsonServices,
    IHttpServices httpServices) : IWorkWithServices
{
    private readonly string _file = "dataButton.json";

    private byte ByteButton(string button)
    {
        GetSaveButton(_file).TryGetValue(button, out byte value);
        return value;
    }

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
        return evenServices.SitDown(1, ByteButton(triggerSettings.SettingsButton.SitDown), 50,
            0x21, 0x22);
    }

    public bool WalkStop(TriggerSettings triggerSettings)
    {
        List<byte> bytesButton = new List<byte>();
        for (int i = 2; i < GetSaveButton(_file).Count; i++)
            bytesButton.Add(ByteButton(triggerSettings.SettingsButton.Move[i]));
        return evenServices.WalkStop(1, bytesButton, 0x22,
            0x21);
    }

    public bool Fire(TriggerSettings triggerSettings, int count, int sleepRepeatFire, int sleepOneFire)
    {
        return evenServices.Fire(1, ByteButton(triggerSettings.SettingsButton.Fire), sleepRepeatFire, sleepOneFire,
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

    public Dictionary<string, byte> GetSaveButton(string file)
    {
        Dictionary<string, byte>? memoryButton = bJsonServices.Des(file);
        if (memoryButton == null)
            throw new NullReferenceException();
        return memoryButton;
    }

    public DataStateUser? GetState(string path, int idUser)
    {
        string? json = httpServices.Get(path, idUser);
        if (json != null) return gJsonServices.DesInNetwork(json) ?? throw new NullReferenceException();
        return null;
    }
}