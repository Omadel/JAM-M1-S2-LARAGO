using DG.Tweening;
using UnityEngine;
public abstract class MovableObject : MonoBehaviour
{

    public System.Action<bool> OnMove;

    [SerializeField] private float moveDuration = 0.2f;

    public Tile currentTile;

    private bool isMoving = false;

    protected void Move(Direction direction)
    {
        if (isMoving == false)
        {
            if (currentTile.neighbours.tiles[(int)direction] != null)
            {
                isMoving = true;
                transform.DOMove(currentTile.neighbours.tiles[(int)direction].OffsettedPosition, moveDuration).OnComplete(CompleteMove);
                currentTile = currentTile.neighbours.tiles[(int)direction];
                OnMove?.Invoke(true);
            }
            else
            {
                OnMove?.Invoke(false);
            }
        }
    }

    public void GetCurrentTile()
    {
        Ray ray = new Ray(transform.position + (Vector3.up * .5f), Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction, Color.black, 10f);
        if (Physics.Raycast(ray, out RaycastHit hit, 1f))
        {
            if (hit.collider.TryGetComponent<Tile>(out currentTile))
            {
                Debug.Log("Collide with" + hit.collider.name);
            }
        }
    }

    protected void CompleteMove()
    {
        isMoving = false;
    }
}

