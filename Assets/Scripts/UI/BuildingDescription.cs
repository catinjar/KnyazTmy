using TMPro;
using UnityEngine;

public class BuildingDescription : MonoBehaviour {
    public CellSelection cellSelection;
    public string defaultMessage;
    public bool showFullInfo;
    
    private TextMeshProUGUI descriptionText;

    private void Start() {
        descriptionText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        var cell = cellSelection.Selected;

        if (cell != null) {
            string info = "";

            // Show specific current values
            if (showFullInfo) {
                var house = cell.GetComponent<House>();
                var camp = cell.GetComponent<RefugeeCamp>();

                if (house != null) {
                    info = $"\nЛюди {house.People}/{House.MaxPeople}";
                    info += $"\nБольные {house.Sick}";
                }

                if (camp != null) {
                    info = $"\nБеженцы {camp.Refugees}/{RefugeeCamp.MaxRefugees}";
                }
            }

            descriptionText.text = $"{cell.cellName}\n{info}\n{cell.description}";
        }
        else {
            descriptionText.text = defaultMessage;
        }
    }
}
