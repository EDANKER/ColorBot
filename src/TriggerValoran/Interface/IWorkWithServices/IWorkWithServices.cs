using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interfase.IWorkWithServices;

public interface IWorkWithServices
{
    bool Start(TriggerSettings triggerSettings);
    bool SitDown();
    bool WalkStop();
    bool Fire(int count, int sleepRepeatFire, int sleepOneFire);
    bool ClickForStart();
    bool SaveSettings(List<TriggerSettings> item, string file);
    bool SaveButton(string file);
    TriggerSettings GetSaveSettings(string file);
    MemoryButton GetSaveButton(string file);
}