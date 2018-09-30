using UnityEngine;
using UnityEngine.Events;

public class ConditionalMultiGameEventHandle : MonoBehaviour {
    public UnityEvent condition; // Condition must take this object as an argument and set ConditionIsTrue property
    public ConditionalGameEventListener[] listeners;

    public bool ConditionIsTrue { get; set; }

    // Each listener is going to call this method to check condition
    private bool CheckCondition() {
        condition.Invoke();
        return ConditionIsTrue;
    }

    private void OnEnable() {
        foreach (var listener in listeners) {
            listener.OnRegister();
            listener.Condition = CheckCondition;
        }
    }

    private void OnDisable() {
        foreach (var listener in listeners) {
            listener.OnUnregister();
        }
    }
}
