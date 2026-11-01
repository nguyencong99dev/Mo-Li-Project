using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private Slider EXPBar;
    [SerializeField] private TextMeshProUGUI EXPStat;
    [SerializeField] private Slider HPBar;
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private Slider MPBar;
    [SerializeField] private TextMeshProUGUI MPText;
    [SerializeField] private Slider SPBar;
    [SerializeField] private TextMeshProUGUI SPText;
    
    public void SetStatsValue(SPlayerStats data)
    {

    }
}