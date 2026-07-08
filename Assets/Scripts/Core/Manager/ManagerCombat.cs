using System;
using UnityEngine;
public enum BattleState
{
    BattleStart,
    PlayerTurn,
    EnemyTurn,
    ExecuteAction,
    CheckBattleEnd,
    BattleEnd
}
public class ManagerCombat : MonoBehaviour
{
    public static ManagerCombat Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
        Debug.Log("Manager Combat Initialized");
    }
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
