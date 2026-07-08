using System.Collections.Generic;
using Unity.AppUI.UI;
using UnityEngine;

public class HUDInGame : MonoBehaviour
{
    [SerializeField] private BuildSlotToolbarItems UIToolbar;
    [SerializeField] private StatBar HPBar;
    [SerializeField] private StatBar MPBar;
    [SerializeField] private StatBar SPBar;
    [SerializeField] private StatText Currency;
    void OnEnable()
    {  
        EventBus<SPlayerStats>.Subscribe(InitPlayerStats);
        EventBus<SPlayerToolbar>.Subscribe(InitToolbarItem);
    }
    void OnDisable()
    {
        EventBus<SPlayerStats>.Unsubscribe(InitPlayerStats);
        EventBus<SPlayerToolbar>.Unsubscribe(InitToolbarItem);
    }
    void Start()
    {
        
    }
    void InitPlayerStats(SPlayerStats stats)
    {
        HPBar.SetValue(stats.CurrentHP, stats.MaxHP);
        MPBar.SetValue(stats.CurrentMP, stats.MaxMP);
        SPBar.SetValue(stats.CurrentSP, stats.MaxSP);
        Currency.SetCurrecy(stats.Currency);
    }

    public void InitToolbarItem(SPlayerToolbar list)
    {
        if(UIToolbar == null) return;
        UIToolbar.BuildSlots();
        UIToolbar.InitItem(list.Toolbar);
    }
}