using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawnner : MonoBehaviour
{
    public static Spawnner instance;
    void Awake()
    {
        if (Spawnner.instance != null)
        {
            Debug.LogError("This is more than One Spawnner");
        }
        Spawnner.instance = this;
    }
    public bool isPuttingMagnet = false;
    List<Tile> tiles = new List<Tile>();

    public void SetPositions(Tile tile, MagnetType type)
    {
        transform.position = tile.OffsettedPosition;
        foreach (var item in tile.neighbours.tiles)
        {
            item.GetComponent<MeshRenderer>().material.color = Color.red;
            tiles.Add(item);
        }
        isPuttingMagnet = true;
        PlayerMovement.instance.mouseClick.action.started += TestClick;
    }
    public void TestClick(InputAction.CallbackContext obj)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(PlayerMovement.instance.mousePos.action.ReadValue<Vector2>()), out RaycastHit hit))
        {
            if(hit.collider!=null)
            {
                if(tiles.Contains(hit.collider.GetComponent<Tile>()))
                {
                    SetMagnetAt(hit.collider.GetComponent<Tile>());
                }
            }
            isPuttingMagnet = false;
            foreach (var item in tiles)
            {
                item.GetComponent<MeshRenderer>().material.color = Color.white;

            }
            tiles.Clear();
        }
        PlayerMovement.instance.mouseClick.action.started -= TestClick;
    }
    public void SetMagnetAt(Tile tile)
    {
        Debug.Log("valide Place");

    }
}

