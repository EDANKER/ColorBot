using System.Windows.Threading;
using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interface.ITriggerServices;

public interface ITriggerServices
{
    DataStateUser? Trigger();
    bool Save();
    TriggerSettings GetSave();
}