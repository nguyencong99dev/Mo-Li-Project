using System;
using System.Collections.Generic;

[Serializable]
public class PlayerSaveData
{
    // === BASIC INFOMATION === //
    public string _playerName;
    public int _level;
    public int _exp;
    public int _currency;

    // === STATUS === //
    public float _currentHP;
    public float _currentMP;
    public float _currentSP;
}

public struct SPlayerSaveData
{
    public PlayerSaveData _data;
}