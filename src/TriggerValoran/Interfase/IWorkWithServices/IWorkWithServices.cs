using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Interfase.IWorkWithServices;

public interface IWorkWithServices<T>
{
    bool ItemButtonClick();
    bool ItemButtonState();
    List<byte> ItemButtonAll();
    bool Start(TriggerSettings triggerSettings);
    bool SitDown();
    bool WalkStop();
    bool Fire(int count, int sleepRepeatFire, int sleepOneFire);
    bool ClickForStart();
    bool SaveSettings(T triggerSettings);
    T GetSaveSettings();
}