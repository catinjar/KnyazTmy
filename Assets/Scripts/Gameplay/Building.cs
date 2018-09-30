using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour {
    public Image image;
    public Image imageFire;
    public TextMeshProUGUI numberText;

    public int daysLeftMax;

    public int DaysLeft { get; set; }
    public int DaysBroken { get; set; }

    private void Awake() {
        DaysLeft = daysLeftMax;
        OnDraw();
    }

    public void OnDraw() {
        float alpha = DaysLeft == 0 ? 1.0f : 0.5f;
        image.color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if (DaysLeft != 0) {
            numberText.text = DaysLeft.ToString();
        }
        else if (DaysBroken != 0) {
            numberText.text = $"<color=red>-{DaysBroken}</color>";
        }
        else {
            numberText.text = "";
        }

        imageFire.enabled = DaysBroken > 0;
    }

    public void OnBuild() {
        if (DaysLeft > 0) {
            --DaysLeft;
        }

        if (DaysBroken > 0) {
            --DaysBroken;
        }
    }

    public bool IsReady() {
        return DaysLeft == 0 && DaysBroken == 0;
    }

    // This stuff can be done in some better way
    public void IsReady(ConditionalGameEventHandle listener) {
        listener.ConditionIsTrue = IsReady();
    }

    public void IsReady(ConditionalMultiGameEventHandle listener) {
        listener.ConditionIsTrue = IsReady();
    }
}
