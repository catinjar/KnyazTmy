using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour {
    public TurnManager tm;

    public TextMeshProUGUI description;

    public void SimpleMode() {
        SoundManager.Instance.PlaySound();
        SceneManager.LoadScene("GameScene");
        tm.EasyMode = true;
    }

    public void KnyazTmiMode() {
        SoundManager.Instance.PlaySound();
        SceneManager.LoadScene("GameScene");
        tm.EasyMode = false;
    }

    public void SimpleModeDescription() {
        description.text = "Этот режим подходит для того, чтобы без больших трудностей увидеть всю игру";
    }

    public void KnyazTmiModeDescription() {
        description.text = "Основной режим игры";
    }

    public void ExitDescription() {
        description.text = "";
    }
}
