using System.Collections.Generic;
using UnityEngine;


public static class Utility {

    // EXTENSION METHODS

    /// <summary>
    /// Adds the element to the list if it's not already present.
    /// </summary>
    public static void AddUnique<T>(this List<T> list, T element) {
        if (list.Contains(element)) return;
        list.Add(element);
    }

    /// <summary>
    /// Returns a random element from the list.
    /// </summary>
    public static T GetRandom<T>(this List<T> list) {
        int maxIndex = list.Count;

        if (maxIndex <= 0) return default(T);
        return list[Random.Range(0, maxIndex)];
    }

    /// <summary>
    /// Randomizes the order of elements in the list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> list) {
        for (int i = list.Count - 1; i > 0; i--) {
            int swapIndex = Random.Range(0, i + 1);

            T temp = list[swapIndex];
            list[swapIndex] = list[i];
            list[i] = temp;
        }
    }


    /// <summary>
    /// Enables the GameObject if it's inactive and vice-versa.
    /// </summary>
    public static void ToggleActive(this GameObject gameObj) {
        gameObj.SetActive(!gameObj.activeSelf);
    }
}