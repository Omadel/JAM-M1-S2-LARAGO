using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EndTile : Tile
{
    public static EndTile Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public void DisplayWin()
    {
        UIManager.Instance.WinUI();
    }
}

