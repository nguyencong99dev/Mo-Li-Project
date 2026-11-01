using System.Collections.Generic;
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private BuildSlot UIToolbar;
    [SerializeField] private HPBinder HPBar;
    [SerializeField] private MPBinder MPBar;
    [SerializeField] private SPBinder SPBar;
    [SerializeField] private TextMeshProUGUI Currency;
    void Awake()
    {
        if (UIToolbar == null) return;
        UIToolbar.BuildSlots();
    }
    void OnEnable()
    {
        EventBus<SPlayerStats>.Subscribe(InitPlayerStats);
        EventBus<SToolbar>.Subscribe(InitPlayerToolbar);
    }
    void OnDisable()
    {
        EventBus<SPlayerStats>.Unsubscribe(InitPlayerStats);
        EventBus<SToolbar>.Unsubscribe(InitPlayerToolbar);
    }
    void InitPlayerStats(SPlayerStats stats)
    {
        if (stats.player is IHasHealth) HPBar.Bind(stats.player);
        if (stats.player is IHasMana) MPBar.Bind(stats.player);
        if (stats.player is IHasStamina) SPBar.Bind(stats.player);
        Currency.text = stats.player.GetCurrency().ToString();
    }
    void InitPlayerToolbar(SToolbar stats)
    {
        UIToolbar.InitItemData(stats.Toolbar);
    }
}