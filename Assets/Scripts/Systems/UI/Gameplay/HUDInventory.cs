using System.Collections.Generic;
using UnityEngine;

public class HUDInventory : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private BuildSlotItem UIToolbar;
    [SerializeField] private BuildSlotItem UIInventory;
    [SerializeField] private GameObject HPBar;
    [SerializeField] private GameObject MPBar;
    [SerializeField] private GameObject SPBar;
    [SerializeField] private StatText Currency;
    void Start()
    {
        RegisterEvent();
        InitPlayerStats();
    }
    void RegisterEvent()
    {
        _player.playerStats.OnHealthChanged += SetHPValue;
        _player.playerStats.OnManaChanged += SetMPValue;
        _player.playerStats.OnStaminaChanged += SetSPValue;
        _player.playerStats.OnCurrencyChanged += Currency.SetCurrecy;
        _player.playerToolbar.OnToolbarChanged += InitToolbarItem;
        _player.playerInventory.OnInventoryChanged += InitInventoryItem;
    }
    void InitPlayerStats()
    {
        SetHPValue(_player.playerStats.CurrentHP, _player.playerStats.MaxHP);
        SetMPValue(_player.playerStats.CurrentMP, _player.playerStats.MaxMP);
        SetSPValue(_player.playerStats.CurrentSP, _player.playerStats.MaxSP);
        Currency.SetCurrecy(_player.playerStats.currrency);
        InitToolbarItem(_player.playerToolbar.GetToolbarItems());
        InitInventoryItem(_player.playerInventory.GetInventoryItems());
    }

    public void InitToolbarItem(List<string> list)
    {
        if (UIToolbar == null) return;
        UIToolbar.BuildSlots();
        UIToolbar.InitItem(list);
    }
    public void InitInventoryItem(List<string> list)
    {
        if (UIInventory == null) return;
        UIInventory.BuildSlots();
        UIInventory.InitItem(list);
    }
    public void SetHPValue(float current, float max)
    {
        HPBar.GetComponent<StatBar>().SetValue(current, max);
        HPBar.GetComponent<StatText>().SetValue(current, max);
    }
    public void SetMPValue(float current, float max)
    {
        MPBar.GetComponent<StatBar>().SetValue(current, max);
        MPBar.GetComponent<StatText>().SetValue(current, max);
    }
    public void SetSPValue(float current, float max)
    {
        SPBar.GetComponent<StatBar>().SetValue(current, max);
        SPBar.GetComponent<StatText>().SetValue(current, max);
    }
}