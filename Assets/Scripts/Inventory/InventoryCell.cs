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
    }
    public void PutDownSequence()
    {
        if (numberLeft > 0)
        {
            Spawnner.instance.SetPositions(PlayerMovement.instance.actualTile,magType);
        }
    }
    void SetText()
    {
        magnetsNumber.SetText(numberLeft.ToString());
    }
}

