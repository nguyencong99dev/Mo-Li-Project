using System;
using UnityEngine;
using UnityEngine.UI;

public class UIHandleTabButton : MonoBehaviour
{
    [SerializeField] private Button[] tabBtns;
    [SerializeField] private GameObject[] tabPanels;
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
    void OnEnable()
    {
        ManagerGame.Instance.SetState(GameState.Paused);
    }
    void OnDisable()
    {
        ManagerGame.Instance.SetState(GameState.Playing);
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