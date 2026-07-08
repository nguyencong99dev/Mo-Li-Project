using System;
using System.Collections.Generic;
using System.Numerics;

[Serializable]
public class PlayerData
{
    // === BASIC INFOMATION === //
    public string playerName = "Player 1";
    public int level = 1;
    public int exp = 0;
    public int currrency = 0;

    // === STATUS === //
    public float currentHP = 75;
    public float currentMP = 75;
    public float currentSP = 50;

    // === POSITION === //
    public Vector3 playerPosition;
    public string currentScene = "Test";
    
    public List<string> Inventory = new();
    public List<string> Toolbar = new();
    public List<MonsterData> PartyMembers = new();
}