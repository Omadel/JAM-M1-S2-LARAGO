using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelInventory",menuName ="Inventory/New Level inventory")]
public class InventoryLevel : ScriptableObject
{
    public List<MagnetInInventory> magnets = new List<MagnetInInventory>();
}
[System.Serializable]
public struct MagnetInInventory
{
    public Magnet magnet;
    public int number;
}

