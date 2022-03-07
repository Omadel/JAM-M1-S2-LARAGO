using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Tile actualTile;
    public bool onMove = false;
    public float timeMove = 0.2f;
    public InputActionReference InputsDir;
    public InputActionReference mousePos;
    public Vector2 startPosition=new Vector2();
    public Vector3[] V3Dir = new Vector3[4] { Vector3.forward,Vector3.back, Vector3.right, Vector3.left };
    public AudioClip[] audioClips;

    private void Start()
    {
        if (Physics.SphereCast(new Ray(transform.position + (Vector3.up * 0.5f), Vector3.down), 0.2f, out RaycastHit hit, 0.75f))
        {
            if (hit.collider.GetComponent<Tile>())
            {
                actualTile = hit.collider.GetComponent<Tile>();
            }
        }
        InputsDir.action.started += (ctr) => {startPosition= mousePos.action.ReadValue<Vector2>(); };
        InputsDir.action.canceled += (ctr) => {};


    }
    private void Update()
    {


    }
    public void CaluculateDirection(Vector2 endPos)
    {
        int i = -1;

        Vector2 delta =(endPos-startPosition).normalized;
        = math.atan2(delta.x, delta.y);



        Move(i);

    }
    private void Move(int i)
    {
        if (onMove == false)
        {
            if (actualTile.neighbours.tiles[i] != null)
            {
                onMove = true;
                transform.DOMove(actualTile.neighbours.tiles[i].OffsettedPosition, timeMove).OnComplete(() => { onMove = false; });
                actualTile = actualTile.neighbours.tiles[i];
                GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            }
            else
            {
                transform.DOPunchPosition(V3Dir[i] * 0.1f, 0.1f);
                GetComponent<AudioSource>().PlayOneShot(audioClips[1]);

            }
        }
    }
}
