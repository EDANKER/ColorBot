using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interface.IWorkWithServices;

public interface IWorkWithServices
{
    bool Start(TriggerSettings triggerSettings);
    bool SitDown(TriggerSettings triggerSettings);
    bool WalkStop(TriggerSettings triggerSettings);
    bool Fire(TriggerSettings triggerSettings, int count, int sleepRepeatFire, int sleepOneFire);
    bool ClickForStart(TriggerSettings triggerSettings);
    bool SaveSettings(List<TriggerSettings> item, string file);
    bool SaveButton(string file);
    TriggerSettings GetSaveSettings(string file);
    MemoryButton GetSaveButton(string file);
}