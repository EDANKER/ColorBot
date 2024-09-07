using System.Drawing;
using TriggerValoran.Interface.IColorServices;
using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IHttpServices;
using TriggerValoran.Interface.IJsonServices;
using TriggerValoran.Interface.IScreenServices;
using TriggerValoran.Interface.IWorkWithServices;
using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.TriggerSettings;
using NullReferenceException = System.NullReferenceException;

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
    private readonly string _fileButton = "dataButton.json";
    private readonly string _fileSettings = "dataTrigger.json";

    private byte ByteButton(string button)
    {
        GetSaveButton().TryGetValue(button, out byte value);
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
        for (int i = 2; i < GetSaveButton().Count; i++)
            bytesButton.Add(ByteButton(triggerSettings.SettingsButton.Move[i]));
        return evenServices.WalkStop(1, bytesButton, 0x22,
            0x21);
    }

    public bool Fire(TriggerSettings triggerSettings, int count, int sleepRepeatFire, int sleepOneFire)
    {
        return evenServices.Fire(count, ByteButton(triggerSettings.SettingsButton.Fire), sleepRepeatFire, sleepOneFire,
            0x21, 0x22);
    }

    public bool ClickForStart(TriggerSettings triggerSettings)
    {
        return evenServices.ClickForStart(0x22);
    }

    public bool SaveSettings(TriggerSettings item)
    {
        bool isSave = tJsonServices.Ser(item, _fileSettings);
        if (!isSave)
            throw new NullReferenceException();
        return isSave;
    }

    public TriggerSettings GetSaveSettings()
    {
        TriggerSettings? triggerSettings = tJsonServices.Des(_fileSettings);
        if (triggerSettings == null)
            throw new NullReferenceException();
        return triggerSettings;
    }

    public bool SaveButton()
    {
        bool isSave = bJsonServices.Ser(evenServices.ItemButtonAll(), _fileButton);
        if (!isSave)
            throw new NullReferenceException();
        return isSave;
    }

    public Dictionary<string, byte> GetSaveButton()
    {
        Dictionary<string, byte>? memoryButton = bJsonServices.Des(_fileButton);
        if (memoryButton == null)
            throw new NullReferenceException();
        return memoryButton;
    }

    public DataStateUser GetState(string path, int idUser)
    {
        string? json = httpServices.Get(path, idUser);
        if (json != null)
        {
            DataStateUser? dataStateUser = gJsonServices.DesInNetwork(json);
            if (dataStateUser != null)
                return dataStateUser;
        }
        throw new NullReferenceException();
    }
}