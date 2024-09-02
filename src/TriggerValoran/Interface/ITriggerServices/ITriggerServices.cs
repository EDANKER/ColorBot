using System.Windows.Threading;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interfase.ITriggerServices;

public interface ITriggerServices
{
    bool Trigger(TriggerSettings triggerSettings, DispatcherTimer dispatcherTimer);
    bool Save(TriggerSettings triggerSettings);
    TriggerSettings GetSave();
}