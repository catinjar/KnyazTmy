using UnityEngine.Events;

[System.Serializable]
public class GameEventListener : IGameEventListener {
    public GameEvent gameEvent;
    public UnityEvent response;

    public virtual void OnEventRaised() {
        response.Invoke();
    }

    public void OnRegister() {
        gameEvent.RegisterListener(this);
    }

    public void OnUnregister() {
        gameEvent.UnregisterListener(this);
    }
}
