using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    [RequireComponent(typeof(BetterButton))]
    public class TEMPENDLVL : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<BetterButton>().OnClick += () =>
            {
                Debug.Log("Should Save");
                Save.HasPlayed = true;
            };
        }
    }
}
