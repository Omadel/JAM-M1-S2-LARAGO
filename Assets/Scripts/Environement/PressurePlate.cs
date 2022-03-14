using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PressurePlate : NoneSpawnnableTile
{
    public List<GameObject> activable = new List<GameObject>();
    [SerializeField] GameObject mesh;
    [SerializeField] float downOffset=0.46f;

    public override void ExecuteEnterCode()
    {
        base.ExecuteEnterCode();
        Debug.Log("Enter pressur plate");
        mesh.transform.DOLocalMoveY(downOffset,0.5f);
    }
    public override void ExecuteExitCode()
    {
        base.ExecuteExitCode();
        Debug.Log("Exit pressur plate");
        mesh.transform.DOLocalMoveY(OffsettedPosition.y, 0.5f);
    }
}

