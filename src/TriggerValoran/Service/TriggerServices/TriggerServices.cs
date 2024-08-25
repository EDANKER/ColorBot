using System.Windows.Threading;
using TriggerValoran.Interfase;
using TriggerValoran.Interfase.ITriggerServices;
using TriggerValoran.Interfase.IWorkWithServices;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.TriggerServices;

public class TriggerServices(IWorkWithServices workWithServices) : ITriggerServices
{
    public bool Trigger(TriggerSettings triggerSettings, DispatcherTimer dispatcherTimer)
    {
        while (workWithServices.ClickForStart())
        {
            if (dispatcherTimer.IsEnabled)
                dispatcherTimer.Stop();
            if (workWithServices.Start(triggerSettings))
            {
                if (triggerSettings.WalkStop && triggerSettings.SitDown &&
                    workWithServices.WalkStop() && workWithServices.SitDown())
                    workWithServices.Fire(triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                if (triggerSettings.SitDown && workWithServices.SitDown())
                    workWithServices.Fire(triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                if (triggerSettings.WalkStop && workWithServices.WalkStop())
                    workWithServices.Fire(triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                else
                    workWithServices.Fire(triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
            }
        }

        dispatcherTimer.Start();
        return false;
    }

    public bool Save(TriggerSettings triggerSettings)
    {
        return workWithServices.Save(triggerSettings);
    }

    public TriggerSettings GetSave()
    {
        return workWithServices.GetSave();
    }

    public string GetNameButton()
    {
        return "";
    }
}