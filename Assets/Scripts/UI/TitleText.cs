using TMPro;
using UnityEngine;

public class TitleText : MonoBehaviour {
    public TextMeshProUGUI titleText;
    public CellSelection cellSelection;

    private void Start() {
        if (titleText != null) {
            titleText.text = cellSelection.Clicked.cellName;
        }
    }
}
