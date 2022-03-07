using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TilesNeighbours neighbours = new TilesNeighbours();

    public Vector3 offset = new Vector3(0, 0.5f, 0);
    public Vector3 OffsettedPosition => transform.position + offset;
    public void CheckNeighbours(Tile tileToFind)
    {
        foreach (Tile item in FindObjectsOfType<Tile>())
        {
            if (item != this)
            {
                if (item.neighbours.Contains(this))
                {
                    item.neighbours.Remove(this);
                }
            }
        }
    }
    public void FindNeighbours()
    {


        if (Physics.SphereCast(new Ray(transform.position, Vector3.up), 0.2f, out RaycastHit hit, 0.75f))
        {
            if (hit.collider.GetComponent<Tile>())
            {
                CheckNeighbours(this);
                Debug.Log("Hitted");
                if (Application.isPlaying)
                {
                    Destroy(this);
                }
                else
                {
                    DestroyImmediate(this);
                }
                return;
            }
        }

        neighbours.Clear();
        foreach (Tile item in FindObjectsOfType<Tile>())
        {
            if (item != this)
            {
                float size = 0.2f;
                float dist = 0.75f;
                Vector3[] directions = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
                for (int i = 0; i < directions.Length; i++)
                {
                    if (Physics.SphereCast(new Ray(OffsettedPosition, directions[i]), size, out RaycastHit tileHit, dist))
                    {
                        if (tileHit.collider.GetComponent<Tile>())
                        {
                            neighbours.Add(tileHit.collider.GetComponent<Tile>(), (Direction)i);
                        }
                    }
                }
            }
        }
    }

    private List<Tile> tileDone = new List<Tile>();




    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(offset + transform.position, 0.2f);
    }
    private void OnDrawGizmosSelected()
    {

        foreach (Tile item in neighbours.GetNoNullTiles())
        {
            Debug.DrawLine(transform.position + offset, item.transform.position + item.offset, Color.red);
        }
    }

}
[System.Serializable]
public class TilesNeighbours
{

    public const int NORTH = 0;
    public const int SOUTH = 1;
    public const int EST = 2;
    public const int WEST = 3;

    public Tile[] tiles = new Tile[4];



    public bool Contains(Tile tile)
    {
        bool boolen = false;
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == tile)
            {
                boolen = true;
            }
        }
        return boolen;
    }
    public void Clear()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = null;
        }

    }
    public void Remove(Tile tile)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == tile)
            {
                tiles[i] = null;
            }
        }

    }
    public void Add(Tile tile, Direction dir)
    { 
        tiles[(int)dir] = tile;
    }
    public List<Tile> GetNoNullTiles()
    {
        List<Tile> tempTiles = new List<Tile>();
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                tempTiles.Add(tiles[i]);
            }
        }

        return tempTiles;
    }
}
public enum Direction { North, South, Est, West };