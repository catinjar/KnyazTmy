using UnityEngine;

public class DayPointer : MonoBehaviour {
    public GameObject[] points;

    private void Update() {
        if (ResourceManager.Instance.Day > 27) {
            return;
        }

        transform.position = points[ResourceManager.Instance.Day - 1].transform.position;
    }
}
