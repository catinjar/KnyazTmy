using System.Linq;
using UnityEngine;

public class RefugeeCamp : CellType {
    public const int MaxRefugees = 50;

    public int Refugees { get; set; }

    private void OnEnable() {
        AddRefugees();
    }

    private void AddRefugees() {
        if (Refugees < MaxRefugees) {
            int minRefugees = 5;
            int maxRefugees = 50;

            (ResourceManager.Instance.RefugeesOnThisDay, Refugees) = RandomHelper.Move(ResourceManager.Instance.RefugeesOnThisDay, Refugees, minRefugees, maxRefugees);
        }
    }

    public void OnDemand() {
        rm.NeedFood += 1;
    }

    public void OnSpreadRefugees() {
        AddRefugees();
    }

    public void OnCountHumanResources() {
        rm.Refugees += Refugees;
    }

    public void OnCreateRaiderCamps() {
        if (rm.Day < 22) {
            return;
        }

        if (TurnManager.Instance.EasyMode && Random.Range(0, 100) < 50) {
            return;
        }

        if (bm.GetAvailableCellsForRefugees().Count > 0) {
            var cells = bm.GetAvailableCellsForRefugees().Values.ToList();
            var cell = RandomHelper.Element(cells);

            bm.Build<RaiderCamp>(cell);
        }
    }
}
