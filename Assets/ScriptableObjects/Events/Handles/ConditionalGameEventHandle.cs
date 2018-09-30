using UnityEngine;
using UnityEngine.Events;

public class ConditionalGameEventHandle : MonoBehaviour {
    public UnityEvent condition; // Condition must take this object as an argument and set ConditionIsTrue property
    public ConditionalGameEventListener listener;

    public bool ConditionIsTrue { get; set; }

    // Listener is going to call this method to check condition
    private bool CheckCondition() {
        condition.Invoke();
        return ConditionIsTrue;
    }

    private void OnEnable() {
        listener.OnRegister();
        listener.Condition = CheckCondition;
    }

    private void OnDisable() {
        listener.OnUnregister();
    }
}
