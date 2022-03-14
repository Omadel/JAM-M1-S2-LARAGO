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
        if(isMoving == false)
        {
            if(currentTile.neighbours.tiles[(int)direction] != null)
            {
                isMoving = true;
                transform.DOMove(currentTile.neighbours.tiles[(int)direction].OffsettedPosition, moveDuration).OnComplete(CompleteMove);
                currentTile = currentTile.neighbours.tiles[(int)direction];
                OnMove?.Invoke(true);
            } else
            {
                OnMove?.Invoke(false);
            }
        }
    }

    public void GetCurrentTile()
    {
        
        if(Physics.Raycast(new Ray(transform.position + (Vector3.up * 0.5f), Vector3.down), out RaycastHit hit, 1f))
        {
            hit.collider.TryGetComponent<Tile>(out currentTile);
        }
    }

    protected void CompleteMove()
    {
        isMoving = false;
    }
}

