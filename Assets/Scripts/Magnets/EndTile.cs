using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
        Train.instance.OnMove += CheckCollision;
    }

    private void CheckCollision(bool _, Vector3 __)
    {
        Debug.DrawRay(ray.origin,ray.direction,Color.yellow);
        if (!Physics.Raycast(ray, out RaycastHit hit, 1f, layer_mask, QueryTriggerInteraction.Collide)) return;
        if (!hit.collider.isTrigger) return;
        UIManager.Instance.WinUI();
    }
}

