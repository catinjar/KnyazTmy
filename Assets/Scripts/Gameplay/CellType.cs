using UnityEngine;

public class CellType : MonoBehaviour {
    // Store these to make code shorter
    protected BuildingManager bm;
    protected ResourceManager rm;

    private void Awake() {
        bm = BuildingManager.Instance;
        rm = ResourceManager.Instance;
    }
}
