using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MovableObject
{
    
    
    public InputActionReference mouseClick;
    public InputActionReference mousePos;
    public DirectionCadrant pointer;
    public Vector2 startPosition = new Vector2();
    public Vector2 endPosition = Vector2.zero;
    public AudioClip[] audioClips;
    AudioSource audioSource;
    //public  feedback;

    private void OnEnable()
    {
        mouseClick.action.Enable();
        mousePos.action.Enable();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetActualTile();

        mouseClick.action.started += (ctr) =>
        {
            startPosition = mousePos.action.ReadValue<Vector2>();
            pointer.gameObject.SetActive(true);
            pointer.startPoint = startPosition;
            pointer.GetComponent<RectTransform>().localPosition = startPosition - new Vector2(Screen.width / 2f, Screen.height / 2f);

        };

        mouseClick.action.canceled += CaluculateDirection;
    }
    public void CaluculateDirection(InputAction.CallbackContext obj)
    {
        pointer.gameObject.SetActive(false);
        endPosition = mousePos.action.ReadValue<Vector2>();
        int i = -1;

        Vector2 delta = (endPosition-startPosition).normalized;

        float radian = math.atan2(delta.x, delta.y);

        if (radian > Mathf.PI / 4f && radian < (3 * Mathf.PI / 4f))
        {
            dir=3;
        }

        if (radian < -Mathf.PI / 4f && radian > (-3 * Mathf.PI / 4f))
        {
            dir = 2;
        }

        if (Mathf.Abs(radian) > (3 * Mathf.PI / 4f) && Mathf.Abs(radian) < (5 * Mathf.PI / 4f))
        {
            dir = 0;
        }

        if (radian > -Mathf.PI / 4f && radian < Mathf.PI / 4f)
        {
            dir = 1; 
        }
        Move(dir);
    }

    public override void NotSuccesfullMove(int i)
    {
        base.NotSuccesfullMove(i);
        audioSource.PlayOneShot(audioClips[1]);
        
    }
    public override void SuccesfullMove(int i)
    {
        base.SuccesfullMove(i);
        audioSource.PlayOneShot(audioClips[0]);
    }

}
