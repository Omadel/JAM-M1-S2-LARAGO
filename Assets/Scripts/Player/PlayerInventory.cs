using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class PlayerInventory : MonoBehaviour
    {
        public InventoryLevel magnetsList;
        public InventoryDisplay inventory;
        void Start()
        {
            inventory.Initiate(magnetsList);
            
        }

    }
}
