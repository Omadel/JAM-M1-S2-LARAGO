using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class Bridge : Activable
    {
        [SerializeField]
        bool isActivOnBase;
        [SerializeField]
        GameObject CellBridge;
        void Start()
        {
            CellBridge.SetActive(isActivOnBase);
        }
        public override void Activate(bool isEntering)
        {
            Debug.Log("Bridge");
            if(isEntering)
            {
                CellBridge.SetActive(!isActivOnBase);
            }
            else
            {
                CellBridge.SetActive(isActivOnBase);
            }
            ExecuteAllCubeFindNeighbours.ExecuteOrder66();
        } 
    }
}
