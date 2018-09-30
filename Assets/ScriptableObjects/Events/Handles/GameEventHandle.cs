using UnityEngine;

public class GameEventHandle : MonoBehaviour, IGameEventListener {
    public GameEventListener listener;

    public void OnEventRaised() {
        listener.OnEventRaised();
    }

    private void OnEnable() {
        listener.OnRegister();
    }

    private void OnDisable() {
        listener.OnUnregister();
    }
}
