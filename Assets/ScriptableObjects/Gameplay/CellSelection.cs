using UnityEngine;

[CreateAssetMenu(fileName = "CellSelection", menuName = "Gameplay/CellSelection")]
public class CellSelection : ScriptableObject {
    public Cell Selected { get; set; }
    public Cell Clicked { get; set; }
}
