using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDMenu : MonoBehaviour
{
    [SerializeField] private Button[] tabBtns;
    [SerializeField] private GameObject[] tabPanels;
    [SerializeField] private HUDInventory _hudInventory;
    [SerializeField] private HUDStats _hudStats;
    [SerializeField] private HUDParty _hudParty;
    void OnEnable()
    {
        ManagerGame.Instance.SetState(GameState.Paused);
        EventBus<SPlayerInventory>.Subscribe(_hudInventory.InitInventoryItem);
        EventBus<SPlayerToolbar>.Subscribe(_hudInventory.InitToolbarItem);
        EventBus<SPlayerStats>.Subscribe(_hudStats.SetStatsValue);
        EventBus<SPlayerParty>.Subscribe(_hudParty.InitPartyMember);
    }
    void OnDisable()
    {
        ManagerGame.Instance.SetState(GameState.Playing);
        EventBus<SPlayerInventory>.Unsubscribe(_hudInventory.InitInventoryItem);
        EventBus<SPlayerToolbar>.Unsubscribe(_hudInventory.InitToolbarItem);
        EventBus<SPlayerStats>.Unsubscribe(_hudStats.SetStatsValue);
        EventBus<SPlayerParty>.Unsubscribe(_hudParty.InitPartyMember);
    }
    void Awake()
    {
        foreach (Button button in tabBtns)
        {
            int idx = Array.IndexOf(tabBtns, button);
            if (button == null) continue;
            button.onClick.AddListener(() => OnTabButtonClicked(idx));
        }
        OnTabButtonClicked(0);
    }
    public void OnTabButtonClicked(int index)
    {
        foreach (GameObject panel in tabPanels)
        {
            if (panel == null) continue;
            panel.SetActive(false);
        }
        tabPanels[index].SetActive(true);
    }

}