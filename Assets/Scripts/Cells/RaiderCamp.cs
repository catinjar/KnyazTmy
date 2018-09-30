using System.Linq;
using UnityEngine;

public class RaiderCamp : CellType {
    public void OnRaids() {
        if (TurnManager.Instance.EasyMode && Random.Range(0, 100) < 50) {
            return;
        }

        var buildings = FindObjectsOfType<Building>().Where(b => b.IsReady()).ToList();

        if (buildings.Count > 0) {
            ++RandomHelper.Element(buildings).DaysBroken;
        }
    }
}
