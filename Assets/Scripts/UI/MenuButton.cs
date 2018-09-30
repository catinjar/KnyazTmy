using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {
    public GameObject prefabMenu;

    public void OpenMenu() {
        SoundManager.Instance.PlaySound();
        Instantiate(prefabMenu, transform.parent);
    }

    public void ToMainMenu() {
        SoundManager.Instance.PlaySound();
        SceneManager.LoadScene("MainMenuScene");
    }
}
