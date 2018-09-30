using UnityEngine;

public class GameManager : MonoBehaviour {
    // We need to keep references to singletons to have access to them in this scene
    public GameEventManager gameEventManager;
    public BuildingManager buildingManager;
    public ResourceManager resourceManager;
    public TurnManager turnManager;

    private void Awake() {
        TurnManager.Instance.NewGame();
    }

    private void Start() {
        GameEventManager.Instance.NextDay();
    }
}