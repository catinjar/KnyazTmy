using UnityEngine;

public class KillButton : MonoBehaviour {
    public CellSelection cellSelection;

    public void OnPointerClick() {
        if (ResourceManager.Instance.CheckPayWeapons()) {
            BuildingManager.Instance.Build<None>(cellSelection.Clicked);
            Destroy(transform.parent.gameObject);
            ResourceManager.Instance.PayWeapons();
        }
    }
}
