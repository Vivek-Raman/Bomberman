﻿using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    // [SerializeField] private float duration;
    protected Attributes player;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out player))
        {
            Modify();
            DestroyOnPickup();
        }
    }

    private void DestroyOnPickup()
    {
        Destroy(this.gameObject);
    }
    
    protected abstract void Modify();
    // protected abstract void Revert();
    
}