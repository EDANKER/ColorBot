using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.Settings.TriggerSettings;

namespace TriggerValoran.Interface.ITriggerServices;

public interface ITriggerServices
{
    void Trigger(TriggerSettings triggerSettings);
    bool SaveSettings(TriggerSettings triggerSettings);
    TriggerSettings GetSaveSettings();
    DataStateUser GetState(TriggerSettings triggerSettings);
    Dictionary<string, byte> GetSaveButton();
    bool SaveButton();
    string SelectButton();
}