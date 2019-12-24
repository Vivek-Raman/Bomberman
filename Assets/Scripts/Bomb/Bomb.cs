﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public LayerMask mask;
    private List<Vector3> directions;
    private float timeToExplode = 3f;
    private Transform player = null;
    private float distance = 10f;

    // TODO: Refactor
    public void SetPlayer(Transform owner, float bombRange = 10f)
    {
        this.player = owner;
        distance = bombRange;
    }
    
    private void Awake()
    {
        // Populate directions
        directions = new List<Vector3>
        {
            Vector3.forward, Vector3.left, Vector3.back, Vector3.right
        };
        
    }
    
    private void Start()
    {
        // on init, start Explode() after timeToExplode seconds
        Invoke(nameof(Explode), timeToExplode);
    }

    private void Explode()
    {
        foreach (Vector3 direction in directions)
        {
            Ray ray = new Ray(this.transform.position, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, distance))
            {
                if (hit.transform.TryGetComponent(out IExplosionHandler explodedObject))
                {
                    explodedObject.OnExplode();
                }
                //RaycastHitHandler(hit);
            }
        }
        
        Destroy(this.gameObject);
    }
    
    private void OnDestroy()
    {
        // spawn explosion FX
    }
}