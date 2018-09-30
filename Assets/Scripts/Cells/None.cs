using UnityEngine;
using UnityEngine.UI;

public class None : CellType {
    public Image image;

    private Cell cell;

    private void OnEnable() {
        cell = GetComponent<Cell>();
    }

    private void Update() {
        bool available = bm.IsAvailableForPlayer(cell.Row, cell.Column);

        if (available) {
            image.color = cell.Selected ? new Color(0.0f, 1.0f, 0.0f, 0.5f) : new Color(0.0f, 1.0f, 0.0f, 0.25f);
        }
        else {
            image.color = cell.Selected ? new Color(1.0f, 0.0f, 0.0f, 0.5f) : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    public void OnPointerClick() {
        bool available = bm.IsAvailableForPlayer(cell.Row, cell.Column);

        if (cell.prefabWindow != null && available) {
            Instantiate(cell.prefabWindow, GameObject.Find("UI").transform);
            cell.cellSelection.Clicked = cell;
        }
    }
}
