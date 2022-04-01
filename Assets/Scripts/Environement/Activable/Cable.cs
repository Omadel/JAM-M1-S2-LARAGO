using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Cable : Activable
    {
        [SerializeField]
        bool isActivOnBase;
        [SerializeField]
        Material unActiveMat;
        [SerializeField]
        Material activeMat;

        public GameObject CalbeMesh;
        
    void Start()
    {
        if (isActivOnBase)
        {
            CalbeMesh.GetComponent<MeshRenderer>().material = activeMat;
        }
        else
        {
            CalbeMesh.GetComponent<MeshRenderer>().material = unActiveMat;
        }
    }

    public override void Activate(bool isEntering)
    {
        if(isEntering)
        {
            if(isActivOnBase)
            {
                CalbeMesh.GetComponent<MeshRenderer>().material =unActiveMat;
            }
            else
            {
                CalbeMesh.GetComponent<MeshRenderer>().material =activeMat;
            }
        }
        else
        {
            if (isActivOnBase)
            {
                CalbeMesh.GetComponent<MeshRenderer>().material = activeMat ;
            }
            else
            {
                CalbeMesh.GetComponent<MeshRenderer>().material = unActiveMat;
            }
        }
    }
}

