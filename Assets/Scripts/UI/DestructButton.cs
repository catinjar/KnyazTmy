using UnityEngine;

public class DestructButton : MonoBehaviour {
    public CellSelection cellSelection;

    public void OnPointerClick() {
        if (ResourceManager.Instance.CheckPayStuff()) {
            BuildingManager.Instance.Build<None>(cellSelection.Clicked);
            Destroy(transform.parent.gameObject);
            ResourceManager.Instance.PayStuff();
        }
    }
}
