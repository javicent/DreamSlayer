using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCollection : MonoBehaviour
{
    private Dictionary<string, int> lootCounts = new Dictionary<string, int>();

    // Increment the loot count for a specific enemy type.
    public void IncrementLootCount(string enemyType)
    {
        if (lootCounts.ContainsKey(enemyType))
        {
            lootCounts[enemyType]++;
        }
        else
        {
            lootCounts[enemyType] = 1;
        }
    }

    // Get the loot count for a specific enemy type.
    public int GetLootCount(string enemyType)
    {
        if (lootCounts.ContainsKey(enemyType))
        {
            return lootCounts[enemyType];
        }
        return 0; // Default to 0 if there is no count for the specified enemy type.
    }
}
