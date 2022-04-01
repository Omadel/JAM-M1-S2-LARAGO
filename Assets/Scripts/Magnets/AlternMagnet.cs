using UnityEngine;


public class AlternMagnet : Magnet
{
    [Header("SwapDirections")]
    public Direction firstDirection;
    public Direction secondDirection;
    [Header("SwapDuration")]
    public int Duration = 1;
    [Header("SwapBePlayer")]
    public bool isPlayer;
    
    private Ray firstRay;
    private Vector3[] directions = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
    private float _timer;
    private bool IsFirst;

    private void Start()
    {
        firstRay = new Ray(transform.position, directions[(int)firstDirection]);
        direction = firstDirection;
        SetDeathDirection(direction);
        Alternate();
    }

    private void FixedUpdate()
    {
        //_timer += Time.deltaTime;
        //if (_timer > Duration)
        //{
        //    _timer = 0;
        //    Alternate();
        //    SetDeathDirection(direction);
        //}
    }

    public void Alternate()
    {
        if (isPlayer==true)
        {
            PlayerMovement.instance.OnMove += AlternPlayer;
        }
        //else
        //{
        //    PlayerMovement.instance.OnMove += AlternPlate;
        //}
    }
    public void SwitchDir(bool fistDir)
    {
        Debug.Log("isWorking");
        if (fistDir)
        {
            SetDir(secondDirection);
        }
        else
        {
            SetDir(firstDirection);
        }
    }
    private void AlternPlate(bool arg1, Vector3 arg2)
    {
        if (IsFirst)
        {
            SetDir(firstDirection);
            IsFirst = false;
        }
        else
        {
            SetDir(secondDirection);
            IsFirst = true;
        }
    }

    private void AlternPlayer(bool arg1, Vector3 arg2)
    {
        if (arg1 == true)
        {
            if (IsFirst)
            {
                SetDir(firstDirection);
                IsFirst = false;
            }
            else
            {
                SetDir(secondDirection);
                IsFirst = true;
            }
        }
    }




}

