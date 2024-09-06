using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interface.ITriggerServices;

public interface ITriggerServices
{
    void Trigger(TriggerSettings triggerSettings);
    bool Save(TriggerSettings triggerSettings);
    TriggerSettings GetSave();
    DataStateUser GetState(TriggerSettings triggerSettings);
}