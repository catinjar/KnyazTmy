using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "TurnManager", menuName = "Managers/TurnManager")]
public class TurnManager : SingletonScriptableObject<TurnManager> {
    public bool EasyMode { get; set; }

    // Game progress messages
    public GameObject startMessagePrefab;
    public GameObject refugeeMessagePrefab;
    public GameObject sicknessMessagePrefab;
    public GameObject raidersMessagePrefab;

    // Just for shorter code
    public ResourceManager rm;
    public BuildingManager bm;

    private void OnEnable() {
        rm = ResourceManager.Instance;
        bm = BuildingManager.Instance;
    }

    public void NewGame() {
        rm.NewGame();
        bm.NewGame();
    }

    public void OnCheckGameOver() {
        // If everyone are dead or gone, you lose
        if (rm.People == 0 && rm.Sick == 0) {
            SceneManager.LoadScene("LoseScene");
        }

        // If at the and of 4th week you have 5 barracks, you win
        if (rm.Day == 28) {
            int barracksCount = FindObjectsOfType<Barrack>().Length;

            if (barracksCount >= 5) {
                SceneManager.LoadScene("WinScene");
            }
            else {
                SceneManager.LoadScene("KnyazTmiScene");
            }
        }
    }

    public void OnSendMessage() {
        var ui = GameObject.Find("UI").transform;

        switch (rm.Day) {
            case 1:
                Instantiate(startMessagePrefab, ui); // Start message
                break;
            case 8:
                Instantiate(refugeeMessagePrefab, ui); // Refugees start coming
                break;
            case 15:
                Instantiate(sicknessMessagePrefab, ui); // People going sick
                break;
            case 22:
                Instantiate(raidersMessagePrefab, ui); // Refugees start to become raiders
                break;
            default:
                break;
        }
    }

    public void OnCreateRefugeeCamps() {
        var availableCells = bm.GetAvailableCellsForRefugees();

        while (rm.RefugeesOnThisDay > 0 && availableCells.Count > 0) {
            var cells = availableCells.Values.ToList();
            var cell = RandomHelper.Element(cells);

            bm.Build<RefugeeCamp>(cell);
        }
    }

    public void OnDestroyEmptyCamps() {
        var camps = FindObjectsOfType<RefugeeCamp>().Where(c => c.Refugees == 0).ToList();

        foreach (var camp in camps) {
            bm.Build<None>(camp.gameObject);
        }
    }
}
