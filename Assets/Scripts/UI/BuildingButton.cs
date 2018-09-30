using TMPro;
using UnityEngine;

public class BuildingButton : MonoBehaviour {
    public GameObject prefabBuilding;
    public CellSelection cellSelection;
    public TextMeshProUGUI text;

    private ResourceManager resourceManager;

    private void Start() {
        resourceManager = ResourceManager.Instance;

        if (prefabBuilding == null) {
            return;
        }

        var cell = prefabBuilding.GetComponent<Cell>();

        int daysLeftMax = prefabBuilding.GetComponent<Building>().daysLeftMax;

        if (resourceManager.FoodBonus > 0) {
            --daysLeftMax;
        }
        else if (resourceManager.FoodBonus < 0) {
            ++daysLeftMax;
        }

        string turn;

        switch (daysLeftMax % 10) {
            case 1:
                turn = "ход";
                break;
            case 2: case 3: case 4:
                turn = "хода";
                break;
            default:
                turn = "ходов";
                break;
        }

        text.text = $"{cell.cellName} ({daysLeftMax} {turn})";
    }

    public void OnPointerClick() {
        if (resourceManager.CheckPayStuff()) {
            BuildingManager.Instance.Build(prefabBuilding, cellSelection.Clicked);
            Destroy(transform.parent.gameObject);
            resourceManager.PayStuff();
        }
    }

    public void OnPointerEnter() {
        cellSelection.Selected = prefabBuilding.GetComponent<Cell>();
    }

    public void OnPointerExit() {
        cellSelection.Selected = null;
    }
}
