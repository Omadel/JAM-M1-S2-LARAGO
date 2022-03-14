using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PressurePlate : NoneSpawnnableTile
{
    public List<GameObject> activable = new List<GameObject>();
    [SerializeField] GameObject mesh;


    public override void ExecuteEnterCode()
    {
        base.ExecuteEnterCode();
        Debug.Log("Enter pressur plate");
        mesh.transform.DOLocalMoveY(0.3f,1f);
    }
    public override void ExecuteExitCode()
    {
        base.ExecuteExitCode();
        Debug.Log("Exit pressur plate");
        mesh.transform.DOLocalMoveY(0.5f, 0.5f);
    }
}

