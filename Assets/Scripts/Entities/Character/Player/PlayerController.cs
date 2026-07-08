using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public PlayerToolbar playerToolbar;
    public PlayerStats playerStats;
    public PlayerParty playerParty;
    [SerializeField] private PlayerData playerData;

    void Awake()
    {
        playerInventory.SetInventory(playerData.Inventory);
        playerToolbar.SetToolbar(playerData.Toolbar);
        playerStats.SetPlayerStats(playerData);
        playerParty.SetPartyMembers(playerData.PartyMembers);
    }
    void Start()
    {

    }

    void Update()
    {

    }
    void FixedUpdate()
    {

    }
    public PlayerData GetPlayerData()
    {
        return playerData;
    }
}
