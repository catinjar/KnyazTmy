using System.Linq;

public class Hospital : CellType {
    private Bonus bonus;

    private void OnEnable() {
        bonus = GetComponent<Bonus>();
    }

    public void OnHeal() {
        int newSickMin = 5;
        int newSickMax = 25;

        if (bonus.Value != 0) {
            newSickMin = 10;
            newSickMax = 45;
        }

        var houses = FindObjectsOfType<House>().Where(h => h.Sick > 0).ToList();

        if (houses.Count != 0) {
            var house = RandomHelper.Element(houses);
            (house.Sick, house.People) = RandomHelper.Move(house.Sick, house.People, newSickMin, newSickMax);
        }
    }

    public void OnBonus() {
        var cell = GetComponent<Cell>();

        if (bm.HasReadyNeighbor<Church>(cell.Row, cell.Column)) {
            bonus.Value = 1;
        }
    }
}
