using UnityEngine;
using TMPro;

public class StatsText : MonoBehaviour {
    public TextMeshProUGUI dayText;

    public TextMeshProUGUI foodText;
    public TextMeshProUGUI stuffText;
    public TextMeshProUGUI weaponsText;

    public TextMeshProUGUI peopleText;
    public TextMeshProUGUI sickText;
    public TextMeshProUGUI refugeesText;

    public TextMeshProUGUI deadText;
    public TextMeshProUGUI goneText;

    private ResourceManager rm;

    private void Start() {
        rm = ResourceManager.Instance;
    }

    private void Update() {
        dayText.text = $"День {rm.Day}";

        foodText.text = $"Еда {rm.Food}/{rm.NeedFood}";

        int foodBonus = rm.FoodBonus;
        if (foodBonus > 0) {
            foodText.text += $"<color=green>(+{Mathf.Abs(foodBonus)})";
        }
        else if (foodBonus < 0) {
            foodText.text += $"<color=red>(-{Mathf.Abs(foodBonus)})";
        }

        stuffText.text = $"Рабочая сила {rm.Stuff}/{rm.MaxStuff}";
        weaponsText.text = $"Военная сила {rm.Weapons}/{rm.MaxWeapons}";

        peopleText.text = $"Люди {rm.People}/{rm.MaxPeople}";
        sickText.text = $"Больные {rm.Sick}";
        refugeesText.text = $"Беженцы {rm.Refugees}";

        deadText.text = $"Мертвы {rm.Dead}";
        goneText.text = $"Ушли {rm.Gone}";
    }
}
