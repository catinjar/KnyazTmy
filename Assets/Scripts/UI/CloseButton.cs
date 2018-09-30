using UnityEngine;

public class CloseButton : MonoBehaviour {
    public GameObject windowToClose;

    public void OnPointerClick() {
        Destroy(windowToClose);
    }
}
