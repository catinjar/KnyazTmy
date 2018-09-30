using System.Collections.Generic;
using UnityEngine;

public static class RandomHelper {
    public static Type Element<Type>(IList<Type> enumerable)
        => enumerable[Random.Range(0, Mathf.Max(0, enumerable.Count - 1))];

    public static (int, int) Move(int from, int to, int min, int max) {
        int value = Random.Range(Mathf.Min(min, from), Mathf.Min(max, from));
        from -= value;
        to += value;
        return (from, to);
    }
}
