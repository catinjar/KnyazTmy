using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {
    private void Start() {
        StartCoroutine(ChangeToMainMenu());
    }

    private IEnumerator ChangeToMainMenu() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
