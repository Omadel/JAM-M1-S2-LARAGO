using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject content;

    public void Initiate(InventoryLevel levelInventory)
    {
        content.GetComponent<RectTransform>().sizeDelta=new Vector2(100*levelInventory.magnets.Count,100);
        for (int c = 0; c < content.transform.childCount; c++)
        {
            Destroy(content.transform.GetChild(c).gameObject);
        }
        foreach (MagnetInInventory item in levelInventory.magnets)
        {
            var ressource = RessourcesHolder.GetRessources(ObjectKey.go_InventoryCell);
            GameObject instance = Instantiate(ressource as GameObject);
            instance.transform.parent = content.transform;
            instance.GetComponent<RectTransform>().localScale = Vector3.one;
            instance.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
            instance.GetComponent<InventoryCell>().SetUp(item);

        }
    }
}