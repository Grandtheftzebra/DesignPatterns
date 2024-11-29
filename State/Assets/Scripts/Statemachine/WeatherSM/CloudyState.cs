using System.Collections;
using UnityEngine;

public class CloudyState : State
{
    protected WeatherSM stateMachine;

    public CloudyState(WeatherSM sm) => stateMachine = sm;

    public override IEnumerator Enter()
    {
        Manager.Instance.NightToDay();
        yield break;
    }

    public override void CheckState()
    {
        if (Manager.Instance.daylight.intensity == 1f) stateMachine.ChangeStateTo(stateMachine.Sunny);
    }
}
