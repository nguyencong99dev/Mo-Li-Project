using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public SaveSlotIndex _saveSlot;
    public PlayerSaveData _player;
    public InventorySaveData _inventory;
    public PartySaveData _party;
    public string _timeStamp;
    public string _lastSave;
}
public struct SSaveData
{
    public SaveData saveData;
}

