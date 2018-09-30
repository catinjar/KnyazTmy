using UnityEngine;

[CreateAssetMenu(fileName = "GameEventManager", menuName = "Managers/GameEventManager")]
public class GameEventManager : SingletonScriptableObject<GameEventManager> {
    public GameEvent[] gameEvents;

    public void NextDay() {
        foreach (var gameEvent in gameEvents) {
            gameEvent.Raise();
        }
    }
}
