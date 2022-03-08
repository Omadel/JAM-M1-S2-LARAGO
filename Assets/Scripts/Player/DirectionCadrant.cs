using UnityEngine;
using UnityEngine.InputSystem;


public class DirectionCadrant : MonoBehaviour
{
    [SerializeField] InputActionReference mousePosition;
    public GameObject[] directionOBJ = new GameObject[4];
    public Vector2 startPoint;
    int dir = -1;
    int seteddir = -1;
    private void Start()
    {
        foreach (var item in directionOBJ)
        {
            item.SetActive(false);
        }
    }
    void Update()
    {
        Vector2 actualPos = startPoint - mousePosition.action.ReadValue<Vector2>();
        Debug.Log(dir);
        float radian = Mathf.Atan2(actualPos.x, actualPos.y);

        if (radian > Mathf.PI / 4f && radian < (3 * Mathf.PI / 4f))
        {
            dir = 3;
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
        SetDirection();
    }
    void SetDirection()
    {
            if (seteddir != dir)
            {

                foreach (var item in directionOBJ)
                {
                    item.SetActive(false);
                }

                directionOBJ[dir].SetActive(true);
                Debug.Log(dir + " " + seteddir);
            }
        
    }
    }


