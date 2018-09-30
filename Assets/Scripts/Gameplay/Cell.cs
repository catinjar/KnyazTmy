using UnityEngine;

public class Cell : MonoBehaviour {
    public string cellName;
    [TextArea(minLines: 3, maxLines: 5)] public string description;

    public GameObject prefabWindow;
    public CellSelection cellSelection;

    public bool Selected { get; private set; }
    public int Row { get; set; }
    public int Column { get; set; }

    public void OnPointerClick() {
        if (prefabWindow != null) {
            Instantiate(prefabWindow, GameObject.Find("UI").transform);
            cellSelection.Clicked = this;
        }
    }

    public void OnPointerEnter() {
        Selected = true;
        cellSelection.Selected = this;
    }

    public void OnPointerExit() {
        Selected = false;
        cellSelection.Selected = null;
    }

    public (int row, int column) GetCoords() {
        return (Row, Column);
    }
}
