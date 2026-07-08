using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDStats : MonoBehaviour
{
    [SerializeField] private GameObject HPBar;
    [SerializeField] private GameObject MPBar;
    [SerializeField] private GameObject SPBar;
    [SerializeField] private StatText Currency;
    public void SetStatsValue(SPlayerStats data)
    {
        HPBar.GetComponent<StatBar>().SetValue(data.CurrentHP, data.MaxHP);
        HPBar.GetComponent<StatText>().SetValue(data.CurrentHP, data.MaxHP);
        MPBar.GetComponent<StatBar>().SetValue(data.CurrentMP, data.MaxMP);
        MPBar.GetComponent<StatText>().SetValue(data.CurrentMP, data.MaxMP);
        SPBar.GetComponent<StatBar>().SetValue(data.CurrentSP, data.MaxSP);
        SPBar.GetComponent<StatText>().SetValue(data.CurrentSP, data.MaxSP);
        Currency.SetCurrecy(data.Currency);
    }
}