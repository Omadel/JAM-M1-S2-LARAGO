using UnityEngine;
using UnityEngine.UI;


public class InventoryCell : MonoBehaviour
{
    public Image magnetsImage;
    public TMPro.TextMeshProUGUI magnetsNumber;
    MagnetType magType;
    int numberLeft;
    public void SetUp(MagnetInInventory magnetIn)
    {
        magnetsImage.sprite = RessourcesHolder.instance.GetMagSprite(magnetIn.magnet);
        numberLeft = magnetIn.number;
        SetText();
        TestNumber();
    }
    public void PutDownSequence()
    {
        if (numberLeft > 0)
        {
            Spawnner.instance.SetPositions(PlayerMovement.instance.actualTile,magType,this);
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

