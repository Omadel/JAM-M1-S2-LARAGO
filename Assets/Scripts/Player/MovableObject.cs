using UnityEngine;
using DG.Tweening;

public abstract class MovableObject : MonoBehaviour
{
    public int dir;
    public Tile actualTile;
    public float timeMove = 0.2f;
    public bool onMove = false;
    public Vector3[] V3Dir = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };

    public void Move()
    {
        if (onMove == false)
        {
            if (actualTile.neighbours.tiles[dir] != null)
            {
                SuccesfullMove(dir);
            }
            else
            {
                NotSuccesfullMove(dir);
            }
        }
    }
    public void GetActualTile()
    {
        if (Physics.SphereCast(new Ray(transform.position + (Vector3.up * 0.5f), Vector3.down), 0.2f, out RaycastHit hit, 0.75f))
        {
            if (hit.collider.GetComponent<Tile>())
            {
                actualTile = hit.collider.GetComponent<Tile>();
            }
        }
    }

    public virtual void SuccesfullMove(int i)
    {
        onMove = true;
        transform.DOMove(actualTile.neighbours.tiles[i].OffsettedPosition, timeMove).OnComplete(() => { onMove = false; });
        actualTile = actualTile.neighbours.tiles[i];
    }
    public virtual void NotSuccesfullMove(int i)
    {
    }
}

