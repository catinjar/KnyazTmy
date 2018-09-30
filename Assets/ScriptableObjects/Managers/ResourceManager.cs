using UnityEngine;

[CreateAssetMenu(fileName = "ResourceManager", menuName = "Managers/ResourceManager")]
public class ResourceManager : SingletonScriptableObject<ResourceManager> {
    public int Day { get; set; }

    public int Food { get; set; }
    public int NeedFood { get; set; }

    public int FoodBonus => Food - NeedFood;

    public int Stuff { get; set; }
    public int MaxStuff { get; set; }

    public int Weapons { get; set; }
    public int MaxWeapons { get; set; }

    public int People { get; set; }
    public int MaxPeople { get; set; }
    public int Sick { get; set; }
    public int Refugees { get; set; }

    public int Dead { get; set; }
    public int Gone { get; set; }

    public int RefugeesOnThisDay { get; set; }

    public void NewGame() {
        Day = 0;

        Dead = 0;
        Gone = 0;
    }

    public void OnNextDayStart() {
        ++Day;

        Food = 0;
        NeedFood = 0;

        Stuff = 0;
        MaxStuff = 0;

        Weapons = 0;
        MaxWeapons = 0;

        People = 0;
        MaxPeople = 0;

        Sick = 0;
        Refugees = 0;

        RefugeesOnThisDay = Day >= 8 ? Random.Range(5 + Day, 10 + Day * 2) : 0; // I should change this rule to something more convenient
    }

    public void OnCountMaxResources() {
        MaxStuff = Stuff;
        MaxWeapons = Weapons;
        MaxPeople = People;
    }

    public bool CheckPayFood() => Food > 0;
    public void PayFood() => --Food;

    public bool CheckPayStuff() => Stuff > 0;
    public void PayStuff() => --Stuff;

    public bool CheckPayWeapons() => Weapons > 0;
    public void PayWeapons() => --Weapons;
}
