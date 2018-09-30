public class Sawmill : CellType {
    private Bonus bonus;

    private void OnEnable() {
        bonus = GetComponent<Bonus>();
    }

    public void OnProduce() {
        rm.Stuff += bonus.Value;
    }

    public void OnBonus() {
        var cell = GetComponent<Cell>();

        bonus.Value = 0;

        if (bm.HasNeighbor<Forest>(cell.Row, cell.Column)) {
            bonus.Value += 2;
        }
    }
}
