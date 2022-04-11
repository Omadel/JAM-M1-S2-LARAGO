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
    Animator animator;
    public GameObject DownFx;
    public GameObject RigthFx;
    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        firstRay = new Ray(transform.position, directions[(int)firstDirection]);
        direction = firstDirection;
        SetDeathDirection(direction);
        Alternate();
        PlayerMovement.instance.OnMove += UpdatePossibleTrain;

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
        if (isPlayer == true)
        {
            PlayerMovement.instance.OnMove += AlternPlayer;
        }
        //else
        //{
        //    PlayerMovement.instance.OnMove += AlternPlate;
        //}

        if (firstDirection == Direction.Down || secondDirection == Direction.Down)
        {
            transform.GetChild(0).transform.localScale = new Vector3(transform.GetChild(0).transform.localScale.x, transform.GetChild(0).transform.localScale.y, -1);

        }
        if (firstDirection == Direction.Right || secondDirection == Direction.Right)
        {
            transform.GetChild(0).transform.localScale = new Vector3(-1, transform.GetChild(0).transform.localScale.y, transform.GetChild(0).transform.localScale.z);
        }
        if (firstDirection == Direction.Down || firstDirection == Direction.Up)
        {
            RigthFx.SetActive(false);
            animator.SetTrigger("Back");
        }
        else
        {
            DownFx.SetActive(false);
            animator.SetTrigger("Right");
        }
        SetDeathDirection(direction);
    }

    public void SwitchDir(bool fistDir)
    {
        if (IsFirst)
        {
            SetDir(firstDirection);
            if (firstDirection == Direction.Left || firstDirection == Direction.Right)
            {
                animator.SetTrigger("Switch");
                animator.SetTrigger("Right");
                DownFx.SetActive(false);
                RigthFx.SetActive(true);

            }
            else
            {
                animator.SetTrigger("Switch");
                animator.SetTrigger("Back");
                DownFx.SetActive(true);
                RigthFx.SetActive(false);
            }

            IsFirst = false;
        }
        else
        {
            SetDir(secondDirection);
            if (secondDirection == Direction.Left || secondDirection == Direction.Right)
            {
                animator.SetTrigger("Switch");
                animator.SetTrigger("Right");
                DownFx.SetActive(false);
                RigthFx.SetActive(true);
            }
            else
            {
                animator.SetTrigger("Switch");
                animator.SetTrigger("Back");
                DownFx.SetActive(true);
                RigthFx.SetActive(false);

            }
            IsFirst = true;
        }
        SetDeathDirection(direction);


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
                if (firstDirection == Direction.Left || firstDirection == Direction.Right)
                {
                    animator.SetTrigger("Switch");
                    animator.SetTrigger("Right");
                    DownFx.SetActive(false);
                    RigthFx.SetActive(true);

                }
                else
                {
                    animator.SetTrigger("Switch");
                    animator.SetTrigger("Back");
                    DownFx.SetActive(true);
                    RigthFx.SetActive(false);
                }

                IsFirst = false;
            }
            else
            {
                SetDir(secondDirection);
                if (secondDirection == Direction.Left || secondDirection == Direction.Right)
                {
                    animator.SetTrigger("Switch");
                    animator.SetTrigger("Right");
                    DownFx.SetActive(false);
                    RigthFx.SetActive(true);
                }
                else
                {
                    animator.SetTrigger("Switch");
                    animator.SetTrigger("Back");
                    DownFx.SetActive(true);
                    RigthFx.SetActive(false);

                }
                IsFirst = true;
            }
            SetDeathDirection(direction);

        }
    }




}

