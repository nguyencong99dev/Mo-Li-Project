using System.Collections.Generic;
using UnityEngine;

public class HUDGamePlay : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private BuildSlotItem UIToolbar;
    [SerializeField] private StatBar HPBar;
    [SerializeField] private StatBar MPBar;
    [SerializeField] private StatBar SPBar;
    [SerializeField] private StatText Currency;
    void Start()
    {
        RegisterEvent();
        InitPlayerStats();
    }
    void RegisterEvent()
    {
        _player.playerStats.OnHealthChanged += HPBar.SetValue;
        _player.playerStats.OnManaChanged += MPBar.SetValue;
        _player.playerStats.OnStaminaChanged += SPBar.SetValue;
        _player.playerStats.OnCurrencyChanged += Currency.SetCurrecy;
        _player.playerToolbar.OnToolbarChanged += InitToolbarItem;
    }
    void InitPlayerStats()
    {
        HPBar.SetValue(_player.playerStats.CurrentHP, _player.playerStats.MaxHP);
        MPBar.SetValue(_player.playerStats.CurrentMP, _player.playerStats.MaxMP);
        SPBar.SetValue(_player.playerStats.CurrentSP, _player.playerStats.MaxSP);
        Currency.SetCurrecy(_player.playerStats.currrency);
        InitToolbarItem(_player.playerToolbar.GetToolbarItems());
    }

    public void InitToolbarItem(List<string> list)
    {
        if (UIToolbar == null) return;
        UIToolbar.BuildSlots();
        UIToolbar.InitItem(list);
    }
}