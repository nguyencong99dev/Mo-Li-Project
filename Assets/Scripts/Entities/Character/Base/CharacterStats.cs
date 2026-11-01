using System;
using UnityEngine;

public abstract class CharacterStats : IHasHealth, IHasMana, IHasStamina
{
    public abstract float MaxHP { get; }
    public abstract float MaxSP { get; }
    public abstract float MaxMP { get; }
    protected float currentHP;
    protected float currentMP;
    protected float currentSP;
    public float CurrentHP
    {
        get => currentHP;
        set { currentHP = Mathf.Clamp(value, 0, MaxHP); OnHPChanged?.Invoke(currentHP, MaxHP); }
    }
    public float CurrentMP
    {
        get => currentMP;
        set { currentMP = Mathf.Clamp(value, 0, MaxMP); OnMPChanged?.Invoke(currentMP, MaxMP); }
    }
    public float CurrentSP
    {
        get => currentSP;
        set { currentSP = Mathf.Clamp(value, 0, MaxSP); OnSPChanged?.Invoke(currentSP, MaxSP); }
    }
    public event Action<float, float> OnHPChanged;
    public event Action<float, float> OnMPChanged;
    public event Action<float, float> OnSPChanged;
    
}