﻿using UnityEngine;

public class Attributes : MonoBehaviour
{
    private const float MinimumBombExplosionRange = 1f;
    private const float MaximumBombExplosionRange = 3f;
    private const float MinimumBombCooldown = 1f;
    
    [SerializeField] private float bombCooldown = 3f;

    [HideInInspector] public Health health;
    private float bombExplosionRangeInCells = 1f;
    
    private void Awake()
    {
        this.TryGetComponent(out health);
        BombExplosionRangeInCells = 1f;
    }

    #region Bomb Cooldown

    public float BombCooldown
    {
        get => bombCooldown;
        set => bombCooldown = (value <= MinimumBombCooldown) ? MinimumBombCooldown : value;
    }

    #endregion

    #region Bomb Explosion Range

    public float CellSize { get; set; } = 5f;
    
    public float BombExplosionRange { get; private set; } = 5f;

    public float BombExplosionRangeInCells
    {
        get => bombExplosionRangeInCells;
        set
        {
            bombExplosionRangeInCells = Mathf.Clamp(value, 
                MinimumBombExplosionRange, 
                MaximumBombExplosionRange);
            BombExplosionRange = DistanceFromCellCount(BombExplosionRangeInCells);
        }
    }

    private float DistanceFromCellCount(float cells)
    {
        return cells * CellSize;
    }
    
    #endregion
    
}