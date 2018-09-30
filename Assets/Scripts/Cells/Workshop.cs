public class Workshop : CellType {
    private Bonus bonus;

    private void OnEnable() {
        bonus = GetComponent<Bonus>();
    }

    public void OnProduce() {
        rm.Stuff += 1 + bonus.Value;
    }

    public void OnBonus() {
        var cell = GetComponent<Cell>();

        bonus.Value = 0;

        if (bm.HasReadyNeighbor<Farm>(cell.Row, cell.Column) &&
            bm.HasNeighbor<House>(cell.Row, cell.Column, h => h.HasPeople() && h.GetComponent<Building>().IsReady())) {

            ++bonus.Value;
        }
    }
}
