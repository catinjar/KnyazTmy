using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void NewGame() {
        SoundManager.Instance.PlaySound();
        SceneManager.LoadScene("SelectModeScene");
    }

    public void ExitGame() {
        SoundManager.Instance.PlaySound();
        Application.Quit();
    }
}
