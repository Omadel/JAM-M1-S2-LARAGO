using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LaraGoLike
{
    public class ShowMenu : MonoBehaviour
    {
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ShowMenuMethod);
        }

        private void ShowMenuMethod()
        {
            UIManager.Instance.Pause();
        }
    }
}
