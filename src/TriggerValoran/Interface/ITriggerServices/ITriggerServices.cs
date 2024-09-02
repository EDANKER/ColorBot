using System.Windows.Threading;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interface.ITriggerServices;

public interface ITriggerServices
{
    bool Trigger(DispatcherTimer dispatcherTimer);
    bool Save();
    TriggerSettings GetSave();
}