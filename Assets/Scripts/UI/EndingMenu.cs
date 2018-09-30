using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour {
    public void NewGame() {
        SoundManager.Instance.PlaySound();
        SceneManager.LoadScene("GameScene");
    }

    public void ToMainMenu() {
        SoundManager.Instance.PlaySound();
        SceneManager.LoadScene("MainMenuScene");
    }
}
