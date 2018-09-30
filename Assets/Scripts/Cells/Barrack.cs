public class Barrack : CellType {
    private Bonus bonus;

    private void OnEnable() {
        bonus = GetComponent<Bonus>();
    }

    public void OnProduce() {
        rm.Weapons += 1 + bonus.Value;
    }

    public void OnBonus() {
        var cell = GetComponent<Cell>();
        bonus.Value = bm.GetReadyNeighbors<Workshop>(cell.Row, cell.Column).Count;
    }
}
