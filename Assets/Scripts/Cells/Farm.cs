public class Farm : CellType {
    private Bonus bonus;

    private void OnEnable() {
        bonus = GetComponent<Bonus>();
    }

    public void OnProduce() {
        rm.Food += 1 + bonus.Value;
    }

    public void OnBonus() {
        var cell = GetComponent<Cell>();

        bonus.Value = 0;

        if (!bm.HasNeighbor<House>(cell.Row, cell.Column, (house) => house.HasPeople())) {
            return;
        }

        bonus.Value = bm.GetReadyNeighbors<Farm>(cell.Row, cell.Column).Count;
    }
}
