using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour {
    public TextMeshProUGUI numberText;

    public int Value { get; set; }

    public void OnDrawBonus() {
        if (Value != 0) {
            numberText.text = $"<color=green>+{Value}</color>";
        }
    }
}
