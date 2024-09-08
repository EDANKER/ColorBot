using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.Settings.TriggerSettings;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interface.IWorkWithServices;

public interface IWorkWithServices
{
    bool Start(TriggerSettings triggerSettings);
    bool SitDown(TriggerSettings triggerSettings);
    bool WalkStop(TriggerSettings triggerSettings);
    bool Fire(TriggerSettings triggerSettings, int count, int sleepRepeatFire, int sleepOneFire);
    bool ClickForStart(TriggerSettings triggerSettings);
    bool SaveSettings(TriggerSettings item);
    bool SaveButton();
    TriggerSettings GetSaveSettings();
    Dictionary<string, byte> GetSaveButton();
    DataStateUser GetState(string path, int idUser);
}