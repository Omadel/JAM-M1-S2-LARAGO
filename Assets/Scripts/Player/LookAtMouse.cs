using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


    public class LookAtMouse : MonoBehaviour
{
        [SerializeField]InputActionReference mousePosition;
        void Update()
        {
        Vector3 direction = (mousePosition.action.ReadValue<Vector2>() - GetComponent<RectTransform>().rect.position);
            float deg =Mathf.Atan2(direction.x,direction.y)*Mathf.Rad2Deg;
        GetComponent<RectTransform>().rotation=Quaternion.Euler(0,0,deg);
        }
    }

