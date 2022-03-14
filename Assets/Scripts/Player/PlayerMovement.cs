using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MovableObject
{
    public static PlayerMovement instance;

    private void Awake()
    {
        if(PlayerMovement.instance != null)
        {
            Debug.LogError("There is more than One PlayerMovement");
        }
        PlayerMovement.instance = this;
    }



    public InputActionReference mouseClick;
    public InputActionReference mousePos;
    public DirectionCadrant pointer;

    private Vector2 startPosition = new Vector2();
    private Vector2 endPosition = Vector2.zero;
    private bool isNotMovable = false;

    private void OnEnable()
    {
        mouseClick.action.Enable();
        mousePos.action.Enable();
    }

    private void Start()
    {
        GetCurrentTile();

        mouseClick.action.started += StartMoveClick;
        mouseClick.action.canceled += CaluculateDirection;
    }

    private void StartMoveClick(InputAction.CallbackContext obj)
    {
        if(EventSystem.current.IsPointerOverGameObject(0) || Spawnner.instance.isPuttingMagnet)
        {
            isNotMovable = true;
            return;
        }
        startPosition = mousePos.action.ReadValue<Vector2>();
        pointer.gameObject.SetActive(true);
        pointer.startPoint = startPosition;
        pointer.GetComponent<RectTransform>().localPosition = startPosition - new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    public void CaluculateDirection(InputAction.CallbackContext obj)
    {
        if(isNotMovable == false)
        {
            pointer.gameObject.SetActive(false);
            endPosition = mousePos.action.ReadValue<Vector2>();

            Vector2 delta = (endPosition - startPosition).normalized;

            float radian = math.atan2(delta.x, delta.y);

            Direction direction = Direction.Forward;
            const float PIQuart = Mathf.PI / 4f;

            if(radian > PIQuart && radian < (3 * PIQuart))
            {
                direction = Direction.Left;
            }

            if(radian < -PIQuart && radian > (-3 * PIQuart))
            {
                direction = Direction.Right;
            }

            if(radian > -PIQuart && radian < PIQuart)
            {
                direction = Direction.Back;
            }

            Move(direction);
        } else
        {
            isNotMovable = false;
        }
    }

}