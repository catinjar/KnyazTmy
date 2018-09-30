using UnityEngine;

public class MultiGameEventHandle : MonoBehaviour {
    public GameEventListener[] listeners; 

    private void OnEnable() {
        foreach (var listener in listeners) {
            listener.OnRegister();
        }
    }

    private void OnDisable() {
        foreach (var listener in listeners) {
            listener.OnUnregister();
        }
    }
}
