using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawnner : MonoBehaviour
{
    public static Spawnner instance;
    public Material redMat;
    Material[] tilesMaterial = new Material[4];
    Tile[] tempList;
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
    public InventoryCell cell;
    public MagnetType magType;

    public void SetPositions(Tile tile, MagnetType type,InventoryCell _cell)
    {
        transform.position = tile.OffsettedPosition;
        cell=_cell;
       
        Tile[] tempList = tile.neighbours.GetPossableTiles().ToArray();
        for (int i = 0; i < tempList.Length; i++)
        {
            tilesMaterial[i] = tempList[i].GetComponent<MeshRenderer>().material;
            tempList[i].GetComponent<MeshRenderer>().material=redMat;
            tiles.Add(tempList[i]);
        }
        isPuttingMagnet = true;
        PlayerMovement.instance.mouseClick.action.started += TestClick;
        magType = type;
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
            for (int i = 0; i < tiles.Count; i++)
            {

                tiles[i].GetComponent<MeshRenderer>().material=tilesMaterial[i];
            }
            tiles.Clear();
            cell = null;
        }
        else
        {
            isPuttingMagnet = false;
            for (int i = 0; i < tiles.Count; i++)
            {

                tiles[i].GetComponent<MeshRenderer>().material = tilesMaterial[i];
            }

            tiles.Clear();
            cell = null;
        }
        PlayerMovement.instance.mouseClick.action.started -= TestClick;
    }
    public void SetMagnetAt(Tile tile)
    {
        Debug.Log("valide Place");
        string magSpec = magType==MagnetType.Omni?"Omni":"";
        Debug.Log(magSpec);
        string key = "go_" +magSpec+"Magnet";
        var ressource=RessourcesHolder.GetRessources(key);
        GameObject magnet = Instantiate(ressource as GameObject);
        if (magType != MagnetType.Omni)
        {
            magnet.GetComponent<Magnet>().SetDir((Direction)((int)magType - 1));
        }
        magnet.transform.position =tile.OffsettedPosition+new Vector3(0,0.5f,0);
        cell.ReduceNumber();
        Destroy(tile);
    }
}

