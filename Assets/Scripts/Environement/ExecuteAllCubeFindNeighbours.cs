using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAllCubeFindNeighbours : MonoBehaviour
{
    [ContextMenu("ExecuteOrder66")]
    void ExecuteOrder66()
    {
        foreach (var item in FindObjectsOfType<Tile>())
        {
            item.FindNeighbours();
        }
    }
}
