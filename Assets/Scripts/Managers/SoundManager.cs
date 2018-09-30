using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance = null;

    public AudioSource sound;
    public AudioSource music;

    public AudioClip[] clicks;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (ResourceManager.Instance == null) {
            return;
        }

        int day = ResourceManager.Instance.Day;

        // Make music faster with game progress
        if (day > 7) {
            music.pitch = 1.05f;
        }
        if (day > 14) {
            music.pitch = 1.1f;
        }
        if (day > 21) {
            music.pitch = 1.15f;
        }
        else {
            music.pitch = 1.0f;
        }
    }

    public void PlaySound() {
        sound.clip = clicks[Random.Range(0, clicks.Length - 1)];
        sound.Play();
    }
}
