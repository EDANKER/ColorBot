namespace TriggerValoran.Interfase.IEvenClickServices;

public interface IEvenServices
{
    bool Fire(int count, int sleepRepeatFire, int sleepOneFire);
    bool WalkStop();
    bool SitDown();
    bool ClickForStart();
}