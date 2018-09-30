[System.Serializable]
public class ConditionalGameEventListener : GameEventListener{
    public delegate bool CheckCondition();

    public CheckCondition Condition; // Condition must be set outside

    public override void OnEventRaised() {
        if (Condition()) {
            response.Invoke();
        }
    }
}
