using DG.Tweening;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MovableObject
{
    public static PlayerMovement instance;
    public Etienne.Feedback.GameEvent feebackMove;
    public Canvas[] canvasPointer;

    private void Awake()
    {
        if (PlayerMovement.instance != null)
        {
            Debug.LogError("There is more than One PlayerMovement");
        }
        PlayerMovement.instance = this;
        OnMove += PlayFeedback;
    }

    private void PlayFeedback(bool arg1, Vector3 arg2)
    {
        if (!feebackMove)
            return;
        StartCoroutine(feebackMove?.Execute(gameObject));
    }

    public InputActionReference mouseClick;
    public InputActionReference mousePos;
    public DirectionCadrant pointer;

    [SerializeField] private LayerMask TrainLayer;

    private Vector2 startPosition = new Vector2();
    private Vector2 endPosition = Vector2.zero;
    private bool isNotMovable = false;

    private void OnEnable()
    {
        mouseClick.action.Enable();
        mousePos.action.Enable();
    }

    private void OnDisable()
    {
        mouseClick.action.Disable();
        mousePos.action.Disable();
    }

    private void Start()
    {
        GetCurrentTile();
        mouseClick.action.started += StartMoveClick;
        mouseClick.action.canceled += CaluculateDirection;

    }

    public void OnDestroy()
    {
        PlayerMovement.instance = null;
        mouseClick.action.started -= StartMoveClick;
        mouseClick.action.canceled -= CaluculateDirection;
        transform.DOKill();
    }
    bool TestForUI(Vector2 pos)
    {
        bool result=false;
        foreach (var canva in canvasPointer)
        {
            List<RaycastResult> results = new List<RaycastResult>();

            PointerEventData input = new PointerEventData(EventSystem.current);
            input.position = pos;
            canva.GetComponent<GraphicRaycaster>().Raycast(input, results);
            foreach (RaycastResult item in results)
            {
                Debug.Log(item.gameObject.name);
            }
            if (results.Count == 0)
            {
                result= false;
            }
            else
            {
                result= true;
                break;
            }
        }
        return result;
    }
    private void StartMoveClick(InputAction.CallbackContext obj)
    {
        if (TestForUI(mousePos.action.ReadValue<Vector2>()) || Spawnner.instance.isPuttingMagnet)
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
        if (isNotMovable == false)
        {
            pointer.gameObject.SetActive(false);
            endPosition = mousePos.action.ReadValue<Vector2>();

            Vector2 delta = (endPosition - startPosition).normalized;

            float radian = math.atan2(delta.x, delta.y);

            Direction direction = Direction.Up;
            const float PIQuart = Mathf.PI / 4f;

            if (radian > PIQuart && radian < (3 * PIQuart))
            {
                direction = Direction.Left;
            }

            if (radian < -PIQuart && radian > (-3 * PIQuart))
            {
                direction = Direction.Right;
            }

            if (radian > -PIQuart && radian < PIQuart)
            {
                direction = Direction.Down;
            }

            Move(direction);
        }
        else
        {
            isNotMovable = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UIManager.Instance.LooseTrainUI();
    }



}