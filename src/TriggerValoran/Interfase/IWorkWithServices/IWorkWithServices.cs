using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interfase.IWorkWithServices;

public interface IWorkWithServices
{
    bool Start(TriggerSettings triggerSettings);
    bool SitDown();
    bool WalkStop();
    bool Fire(int count, int sleepRepeatFire, int sleepOneFire);
    bool ClickForStart();
    bool Save(TriggerSettings triggerSettings);
    TriggerSettings GetSave();
}