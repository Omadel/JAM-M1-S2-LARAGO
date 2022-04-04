using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : Tile
{
    public static EndTile Instance;

    private void Awake()
    {
        Instance = this;
    }

    
    
    Ray ray;
    [SerializeField]
    LayerMask layer_mask;

    private void Start()
    {
        ray = new Ray(transform.position, Vector3.up);
    }

    private void Update()
    {
        Debug.DrawRay(ray.origin,ray.direction,Color.yellow);
        if (Physics.Raycast(ray, out RaycastHit hit, 1f, layer_mask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider != null && hit.collider.gameObject.TryGetComponent<Train>(out Train train))
            {
                UIManager.Instance.WinUI();
            }
        }
    
    }
}

