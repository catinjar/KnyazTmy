using UnityEngine;

public class AddAvailableCellsEventHandle : MonoBehaviour, IGameEventListener {
    public GameEvent gameEvent;

    public bool forPlayer;
    public bool forRefugees;

    public void OnEventRaised() {
        var cell = GetComponent<Cell>();
        var neighbors = BuildingManager.Instance.GetNeighbors<None>(cell.Row, cell.Column);

        foreach (var neighbor in neighbors) {
            if (forPlayer) {
                BuildingManager.Instance.AddAvailableForPlayer(neighbor);
            }
            if (forRefugees) {
                BuildingManager.Instance.AddAvailableForRefugees(neighbor);
            }
        }
    }

    private void OnEnable() {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable() {
        gameEvent.UnregisterListener(this);
    }
}
