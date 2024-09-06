using TriggerValoran.Interface.ITriggerServices;
using TriggerValoran.Interface.IWorkWithServices;
using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.TriggerServices;

public class TriggerServices(IWorkWithServices workWithServices, TriggerSettings triggerSettings) : ITriggerServices
{
    public void Trigger()
    {
        while (GetState().Time > 0)
        {
            if (workWithServices.ClickForStart(triggerSettings) && workWithServices.Start(triggerSettings))
            {
                if (triggerSettings.WalkStop && triggerSettings.SitDown &&
                    workWithServices.WalkStop(triggerSettings) && workWithServices.SitDown(triggerSettings))
                    workWithServices.Fire(triggerSettings, triggerSettings.Count,
                        triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                if (triggerSettings.SitDown && workWithServices.SitDown(triggerSettings))
                    workWithServices.Fire(triggerSettings, triggerSettings.Count,
                        triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                if (triggerSettings.WalkStop && workWithServices.WalkStop(triggerSettings))
                    workWithServices.Fire(triggerSettings, triggerSettings.Count,
                        triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
                else
                    workWithServices.Fire(triggerSettings, triggerSettings.Count,
                        triggerSettings.SleepTimeRepeatFire, triggerSettings.SleepTimeOneFire);
            }
        }
    }

    public bool Save()
    {
        return workWithServices.SaveSettings(triggerSettings, @"C:\Users\Rider666\Downloads\dataTrigger.json");
    }

    public TriggerSettings GetSave()
    {
        return workWithServices.GetSaveSettings(@"C:\Users\Rider666\Downloads\dataTrigger.json");
    }

    public DataStateUser GetState()
    {
        DataStateUser? dataStateUser = workWithServices.GetState("https://localhost:8080", 1);
        if (dataStateUser != null) return dataStateUser;
        throw new NullReferenceException();
    }
}