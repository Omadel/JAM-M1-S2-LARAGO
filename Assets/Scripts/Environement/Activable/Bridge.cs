using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Bridge : Activable
{
    [SerializeField]
    private bool isActivOnBase;
    [SerializeField]
    private GameObject CellBridge;

    private void Start()
    {
        if (!isActivOnBase)
        {
            CellBridge.transform.DOMoveY(-1f, Time.deltaTime*2f).SetEase(Ease.Linear).OnComplete(() => { StartCoroutine(LaunchExecute()); });
        }
        else
        {
            ExecuteAllCubeFindNeighbours.ExecuteOrder66();
        }
    }
    public override void Activate(bool isEntering)
    {
        if (isEntering)
        {

            if (!isActivOnBase)
            {
                Debug.Log("Bridge down1");
                Move(false);
            }
            else
            {
                Debug.Log("Bridge up1");
                Move(true);
            }
        }
        else
        {
            if (isActivOnBase)
            {
                Debug.Log("Bridge up2");
                Move(false);
            }
            else
            {
                Debug.Log("Bridge down2");
                Move(true);
            }
        }
    }
    void Move(bool down)
    {
        if (down)
            CellBridge.transform.DOMoveY(-1f, 0.5f).SetEase(Ease.Linear).OnComplete(() => { StartCoroutine(LaunchExecute()); });
        else
            CellBridge.transform.DOMoveY(0f, 0.5f).SetEase(Ease.Linear).OnComplete(()=> { StartCoroutine(LaunchExecute()); });
    }    
    
    IEnumerator LaunchExecute()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        ExecuteAllCubeFindNeighbours.ExecuteOrder66();
    }
}

