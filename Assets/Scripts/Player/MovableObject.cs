using DG.Tweening;
using UnityEngine;
using Etienne;
public abstract class MovableObject : MonoBehaviour
{

    public System.Action<bool,Vector3> OnMove;

    [SerializeField] private float moveDuration = 0.2f;
    public Tile currentTile;
    private bool isMoving = false;
    Vector3 currentVectorDirection;

    protected void Move(Direction direction)
    {
        if (isMoving == false)
        {
            if (currentTile.neighbours.tiles[(int)direction] != null)
            {
                isMoving = true;
                Vector3 endPosition = currentTile.neighbours.tiles[(int)direction].OffsettedPosition;
                transform.DOMove(endPosition, moveDuration).OnComplete(CompleteMove);
                currentTile.ExecuteExitCode();
                currentTile = currentTile.neighbours.tiles[(int)direction];
                currentTile.ExecuteEnterCode();
                currentVectorDirection = transform.position.Direction(endPosition);
                OnMove?.Invoke(true,currentVectorDirection);
            }
            else
            {
                OnMove?.Invoke(false,currentVectorDirection);
            }
        }
    }

    public void GetCurrentTile()
    {
        Ray ray = new Ray(transform.position + (Vector3.up * .5f), Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction, Color.black, 10f);
        if (!Physics.Raycast(ray, out RaycastHit hit, 1f, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore)) return;
        Debug.DrawLine(ray.origin, hit.point, Color.green, 10f);
        if (hit.collider.TryGetComponent<Tile>(out currentTile)) { };
    }

    protected void CompleteMove()
    {
        isMoving = false;
    }
}

