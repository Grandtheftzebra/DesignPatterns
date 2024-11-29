using System.Collections;
using UnityEngine;

public class SunnyState : State
{
    protected WeatherSM stateMachine;

    public SunnyState(WeatherSM sm) => stateMachine = sm;

    public override IEnumerator Enter()
    {
        Manager.Instance.DayToNight();
        yield break;
    }

    public override void CheckState()
    {
        if (Manager.Instance.daylight.intensity == 0.25f) stateMachine.ChangeStateTo(stateMachine.Cloudy);
    }
}
