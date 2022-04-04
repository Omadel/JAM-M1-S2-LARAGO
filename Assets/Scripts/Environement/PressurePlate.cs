using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PressurePlate : NoneSpawnnableTile
{
    System.Action<bool> OnEnterPlate;
    public List<Activable> activable = new List<Activable>();
    public List<AlternMagnet> magnets;
    [SerializeField] GameObject mesh;
    [SerializeField] float downOffset=0.46f;
    public Etienne.Feedback.GameEvent feebackPressed;

    private void PlayFeedback(bool arg1)
    {
        StartCoroutine(feebackPressed.Execute(mesh));
    }

    void Start()
    {
        Debug.Log("TakePressurePlateAvtivable");
        foreach (var item in activable)
        {
            OnEnterPlate +=item.Activate;
        }
        foreach (var item in magnets)
        {
            if(!item.isPlayer)
            OnEnterPlate += item.SwitchDir;
        }

        OnEnterPlate += PlayFeedback;
    }
    public override void ExecuteEnterCode()
    {
        base.ExecuteEnterCode();
        Debug.Log("Enter pressur plate");
        mesh.transform.DOLocalMoveY(downOffset,0.5f);
        OnEnterPlate?.Invoke(true);
    }
    public override void ExecuteExitCode()
    {
        base.ExecuteExitCode();
        Debug.Log("Exit pressur plate");
        mesh.transform.DOLocalMoveY(OffsettedPosition.y, 0.5f);
        OnEnterPlate?.Invoke(false);
    }
}

