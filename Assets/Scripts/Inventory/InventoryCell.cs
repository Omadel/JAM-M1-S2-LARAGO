using System;
using UnityEngine;
using UnityEngine.UI;


public class InventoryCell : MonoBehaviour
{
    System.Action OnPressPlate;

    public Image magnetsImage;
    public TMPro.TextMeshProUGUI magnetsNumber;
    MagnetType magType;
    int numberLeft;
    public Etienne.Feedback.GameEvent feebackPressed;

    private void Awake()
    {
        OnPressPlate +=PlayFeedback;
    }
    private void PlayFeedback()
    {
        StartCoroutine(feebackPressed.Execute(magnetsImage.gameObject));
        ;
    }
    public void SetUp(MagnetInInventory magnetIn)
    {
        string key="s_";
        key+=magnetIn.magnet.ToString();
        key += "Magnet";
        var ressource = RessourcesHolder.GetRessources(key);
        magnetsImage.sprite = ressource as Sprite;
        numberLeft = magnetIn.number;
        magType = magnetIn.magnet;
        SetText();
        TestNumber();
    }
    public void PutDownSequence()
    {
        if (numberLeft > 0)
        {
            Spawnner.instance.SetPositions(PlayerMovement.instance.currentTile,magType,this);
        }
    }
    void SetText()
    {
        magnetsNumber.SetText(numberLeft.ToString());
    }
    void TestNumber()
    {
        if(numberLeft<=0)
        {
            OnPressPlate.Invoke();
            magnetsImage.color=new Color(0.5f,0.5f,0.5f);
            GetComponent<Button>().interactable = false;
        }
    }
    public void ReduceNumber()
    {
        numberLeft--;
        SetText();
        TestNumber();
    }
}

