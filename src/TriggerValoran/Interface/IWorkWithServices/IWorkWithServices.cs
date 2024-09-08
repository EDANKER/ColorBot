using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.Settings.TriggerSettings;

namespace TriggerValoran.Interface.IWorkWithServices;

public interface IWorkWithServices
{
    bool Start(TriggerSettings triggerSettings);
    bool SitDown(TriggerSettings triggerSettings);
    bool WalkStop(TriggerSettings triggerSettings);
    bool Fire(TriggerSettings triggerSettings, int count, int sleepFire);
    bool ClickForStart(TriggerSettings triggerSettings);
    bool SaveSettings(TriggerSettings item);
    bool SaveButton();
    TriggerSettings GetSaveSettings();
    Dictionary<string, byte> GetSaveButton();
    DataStateUser GetState(string path, int idUser);
}