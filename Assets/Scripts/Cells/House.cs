using UnityEngine;
using UnityEngine.UI;

public class House : CellType {
    public Image imageSick;

    public const int MaxPeople = 50;

    public int People { get; set; }
    public int Sick { get; set; }

    private Bonus bonus;

    private void OnEnable() {
        bonus = GetComponent<Bonus>();
    }

    public bool HasPeople() {
        return People > 0;
    }

    public void OnDraw() {
        imageSick.enabled = Sick > 0;
    }

    public void OnDemand() {
        rm.NeedFood += 1;
    }

    public void OnBonus() {
        var cell = GetComponent<Cell>();
        bonus.Value = bm.HasReadyNeighbor<Church>(cell.Row, cell.Column) ? 1 : 0;
    }

    public void OnCountHumanResources() {
        rm.People += People;
        rm.Sick += Sick;
    }

    public void OnRefugeePopulate() {
        if (People + Sick >= 50) {
            return;
        }

        int newPeopleMin = 5;
        int newPeopleMax = 25;

        if (bonus.Value != 0) {
            newPeopleMin = 10;
            newPeopleMax = 45;
        }

        if (TurnManager.Instance.EasyMode) {
            newPeopleMin += 10;
            newPeopleMax += 5;
        }

        newPeopleMin = Mathf.Min(newPeopleMin, MaxPeople - People - Sick);
        newPeopleMax = Mathf.Min(newPeopleMax, MaxPeople - People - Sick);

        var camps = FindObjectsOfType<RefugeeCamp>();

        if (camps.Length != 0 && Sick == 0) {
            var camp = RandomHelper.Element(camps);
            (camp.Refugees, People) = RandomHelper.Move(camp.Refugees, People, newPeopleMin, newPeopleMax);
        }
    }

    public void OnSpreadSickness() {
        if (People + Sick == 0 || rm.Day < 15 || Random.Range(0, 100) < 50) {
            return;
        }

        if (Sick != 0) {
            int minDead = 5;
            int maxDead = 10;

            if (TurnManager.Instance.EasyMode) {
                minDead = 0;
                maxDead = 5;
            }

            (Sick, rm.Dead) = RandomHelper.Move(Sick, rm.Dead, minDead, maxDead);
        }

        if (People > 0) {
            int minSick = 10;
            int maxSick = 20;

            if (TurnManager.Instance.EasyMode) {
                minSick = 5;
                maxSick = 10;
            }

            (People, Sick) = RandomHelper.Move(People, Sick, minSick, maxSick);
        }
    }
}
