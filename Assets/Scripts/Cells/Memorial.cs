using System.Linq;
using UnityEngine;

public class Memorial : CellType {
    public void OnHelpBuild() {
        const int chance = 66;

        if (Random.Range(0, 100) < chance) {
            return;
        }

        var buildings = FindObjectsOfType<Building>().Where(b => !b.IsReady()).ToList();

        if (buildings.Count != 0) {
            --RandomHelper.Element(buildings).DaysLeft;
        }
    }
}
