using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject {
    private List<IGameEventListener> listeners = new List<IGameEventListener>();

    public void Raise() {
        foreach (var listener in listeners) {
            listener.OnEventRaised();
        }
    }

    public void RegisterListener(IGameEventListener listener) {
        listeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener listener) {
        listeners.Remove(listener);
    }
}
