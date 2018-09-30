using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingManager", menuName = "Managers/BuildingManager")]
public class BuildingManager : SingletonScriptableObject<BuildingManager> {
    public GameEvent addAvailableCells; // We raise this event each time when something is built or destroyed

    private Dictionary<(int row, int column), GameObject> city;
    private Dictionary<(int row, int column), GameObject> availableCellsForPlayer;
    private Dictionary<(int row, int column), GameObject> availableCellsForRefugees;

    public void NewGame() {
        city = new Dictionary<(int row, int column), GameObject>();

        availableCellsForPlayer = new Dictionary<(int row, int column), GameObject>();
        availableCellsForRefugees = new Dictionary<(int row, int column), GameObject>();

        // Init cells with nothing
        const int size = 9;

        for (int row = 0; row < size; ++row) {
            for (int column = 0; column < size; ++column) {
                Build<None>(row, column);
            }
        }

        // Add random forest
        const int forestCount = 10;

        for (int i = 0; i < forestCount; ++i) {
            Build<Forest>(Random.Range(0, size - 1), Random.Range(0, size - 1));
        }

        // Create default buildings
        Build<Castle>(4, 4);
        Build<House>(5, 3);
        Build<Farm>(4, 3);
        Build<Workshop>(5, 4);

        // Set start parameters
        // This doesn't look very nice but it's the simplest thing that we can do
        city[(5, 3)].GetComponent<Building>().DaysLeft = 0;
        city[(5, 3)].GetComponent<House>().People = 42;
        city[(4, 3)].GetComponent<Building>().DaysLeft = 0;
        city[(5, 4)].GetComponent<Building>().DaysLeft = 0;
    }

    public void Build(GameObject prefab, Cell cell)
        => Build(prefab, cell.Row, cell.Column);

    public void Build<Type>(Cell cell)
        where Type : CellType
        => Build<Type>(cell.Row, cell.Column);

    public void Build<Type>(GameObject gameObject)
        where Type : CellType {

        if (gameObject.GetComponent<Cell>() is var cell) {
            Build<Type>(cell);
        }
    }

    public void Build<Type>(int row, int column)
        where Type : CellType {

        var buildings = Resources.LoadAll<GameObject>("Prefabs/Buildings"); // We need to store all building prefabs in this folder
        var building = ArrayUtility.Find(buildings, b => b.GetComponent<Type>() != null);

        Build(building, row, column);
    }

    public void Build(GameObject prefab, int row, int column) {
        var building = Instantiate(prefab, GameObject.Find("Origin").transform);

        const float offset = 10.31f;
        building.transform.localPosition = new Vector3(offset * column, offset * -row, 0.0f);

        var coords = (row, column);

        if (city.ContainsKey(coords)) {
            Destroy(city[coords].gameObject);
        }

        building.GetComponent<Cell>().Row = row;
        building.GetComponent<Cell>().Column = column;

        city[coords] = building;

        // Reset available cells for building after changing something
        ClearAvailableCells();
        addAvailableCells.Raise();
    }

    public void AddAvailableForPlayer(GameObject gameObject)
        => AddAvailable(availableCellsForPlayer, gameObject);

    public void AddAvailableForRefugees(GameObject gameObject)
        => AddAvailable(availableCellsForRefugees, gameObject);

    private void AddAvailable(Dictionary<(int row, int column), GameObject> availableCells, GameObject gameObject) {
        var coords = gameObject.GetComponent<Cell>().GetCoords();
        availableCells[coords] = city[coords];
    }

    public bool IsAvailableForPlayer(int row, int column)
        => availableCellsForPlayer.ContainsKey((row, column));

    public bool IsAvailableForRefugees(int row, int column)
        => availableCellsForRefugees.ContainsKey((row, column));

    public Dictionary<(int row, int column), GameObject> GetAvailableCellsForPlayer()
        => availableCellsForPlayer;

    public Dictionary<(int row, int column), GameObject> GetAvailableCellsForRefugees()
        => availableCellsForRefugees;

    public List<GameObject> GetNeighbors(int row, int column) {
        var neighbors = new List<GameObject>();

        void AddNeighbor(int r, int c) {
            var coords = (r, c);

            if (city.ContainsKey(coords)) {
                neighbors.Add(city[coords]);
            }
        }

        AddNeighbor(row - 1, column);
        AddNeighbor(row + 1, column);
        AddNeighbor(row, column - 1);
        AddNeighbor(row, column + 1);

        return neighbors;
    }

    public List<GameObject> GetNeighbors<Type>(int row, int column)
        where Type : CellType
        => GetNeighbors(row, column).Where(n => n.GetComponent<Type>() != null).ToList();

    public List<GameObject> GetReadyNeighbors<Type>(int row, int column)
        where Type : CellType
        => GetNeighbors<Type>(row, column).Where(n => n.GetComponent<Type>() != null && n.GetComponent<Building>().IsReady()).ToList();

    public bool HasNeighbor<Type>(int row, int column)
        where Type : CellType {

        var neighbors = GetNeighbors(row, column);
        var neighbor = neighbors.Find(n => n.GetComponent<Type>() != null);

        return neighbor != null;
    }

    public bool HasNeighbor<Type>(int row, int column, System.Func<Type, bool> predicate)
        where Type : CellType {

        var neighbors = GetNeighbors(row, column);
        var neighbor = neighbors.Find(n => n.GetComponent<Type>() != null);

        if (neighbor == null) {
            return false;
        }

        var component = neighbor.GetComponent<Type>();

        return predicate(component);
    }

    public bool HasReadyNeighbor<Type>(int row, int column)
        where Type : CellType
        => HasNeighbor<Type>(row, column, n => n.GetComponent<Building>().IsReady());

    public void ClearAvailableCells() {
        availableCellsForPlayer.Clear();
        availableCellsForRefugees.Clear();
    }
}
