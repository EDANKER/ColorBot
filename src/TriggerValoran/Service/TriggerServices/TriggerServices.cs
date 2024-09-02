using System.Windows.Threading;
using TriggerValoran.Interface.ITriggerServices;
using TriggerValoran.Interface.IWorkWithServices;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.TriggerServices;

public class TriggerServices(IWorkWithServices workWithServices, TriggerSettings triggerSettings) : ITriggerServices
{
    public bool Trigger(DispatcherTimer dispatcherTimer)
    {
        workWithServices.SaveButton("dataButton.json");
        
        while (workWithServices.ClickForStart(triggerSettings))
        {
            if (dispatcherTimer.IsEnabled)
                dispatcherTimer.Stop();
            if (workWithServices.Start(triggerSettings))
            {
                if (triggerSettings.WalkStop && triggerSettings.SitDown &&
                    workWithServices.WalkStop(triggerSettings) && workWithServices.SitDown(triggerSettings))
                    workWithServices.Fire(triggerSettings, triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                if (triggerSettings.SitDown && workWithServices.SitDown(triggerSettings))
                    workWithServices.Fire(triggerSettings, triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                if (triggerSettings.WalkStop && workWithServices.WalkStop(triggerSettings))
                    workWithServices.Fire(triggerSettings, triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                else
                    workWithServices.Fire(triggerSettings, triggerSettings.Count, triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
            }
        }

        dispatcherTimer.Start();
        return false;
    }

    public bool Save()
    {
        return workWithServices.SaveSettings(new List<TriggerSettings>(), "dataTrigger.json");
    }

    public TriggerSettings GetSave()
    {
        return workWithServices.GetSaveSettings("dataTrigger.json");
    }
}