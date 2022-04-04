using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public static InventoryDisplay instance;
    void Awake()
    {
        if (InventoryDisplay.instance != null)
        {
            Debug.LogError("This is more than One InventoryDisplay");
        }
        InventoryDisplay.instance = this;
    }
    
    public GameObject content;

    public void Initiate(InventoryLevel levelInventory)
    {
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(100 * levelInventory.magnets.Count, 100);
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
    public bool HitInventory(Vector2 pos)
    {
        List<RaycastResult> results = new List<RaycastResult>();

        PointerEventData input = new PointerEventData(EventSystem.current);
        input.position = pos;
        GetComponent<GraphicRaycaster>().Raycast(input, results);
        foreach (RaycastResult item in results)
        {
            Debug.Log(item.gameObject.name);
        }
        if (results.Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}