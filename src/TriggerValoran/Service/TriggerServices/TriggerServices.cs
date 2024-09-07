using TriggerValoran.Interface.ITriggerServices;
using TriggerValoran.Interface.IWorkWithServices;
using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.TriggerSettings;

namespace TriggerValoran.Service.TriggerServices;

public class TriggerServices(IWorkWithServices workWithServices) : ITriggerServices
{
    private void ItemTriggerWork(TriggerSettings triggerSettings)
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

    public void Trigger(TriggerSettings triggerSettings)
    {
        if (triggerSettings.StateStart == "По нажатию" && workWithServices.ClickForStart(triggerSettings) &&
            workWithServices.Start(triggerSettings))
            ItemTriggerWork(triggerSettings);
        else if (triggerSettings.StateStart == "Постоянно" && workWithServices.Start(triggerSettings))
            ItemTriggerWork(triggerSettings);
    }

    public bool Save(TriggerSettings triggerSettings)
    {
        return workWithServices.SaveSettings(triggerSettings, "dataTrigger.json");
    }

    public TriggerSettings GetSave()
    {
        return workWithServices.GetSaveSettings("dataTrigger.json");
    }

    public DataStateUser GetState(TriggerSettings triggerSettings)
    {
        DataStateUser dataStateUser = workWithServices.GetState("https://localhost:8080", 1);
        return dataStateUser;
    }
}