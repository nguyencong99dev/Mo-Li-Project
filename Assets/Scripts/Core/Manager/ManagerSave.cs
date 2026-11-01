using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

public enum SaveSlotIndex
{
    One = 1,
    Two = 2,
    Three = 3
}
public class ManagerSave : MonoBehaviour
{
    public static ManagerSave Instance { get; private set; }
    public Dictionary<SaveSlotIndex, SaveData> playerSaveData = new();
    // public SaveData CurrentSaveData = new();
    private List<ISaveable> _saveables = new();
    private string GetSavePath(SaveSlotIndex slotIndex) =>
        Path.Combine(Application.persistentDataPath, $"{ManagerConst.SAVE_FILE_PREFIX}{(int)slotIndex}.json");
    public Action<SaveKey, SaveData> OnSaveDataChanged;
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
        Debug.Log("Manager Save");

    }
    public void Register(ISaveable saveable)
    {
        if (!_saveables.Contains(saveable))
            _saveables.Add(saveable);
    }

    public void Unregister(ISaveable saveable)
        => _saveables.Remove(saveable);

    public void Save(SaveSlotIndex slot)
    {
        Dictionary<SaveKey, ISaveable> saveData = _saveables.ToDictionary(i => i._saveKey, i => i);
        SaveData data = new()
        {
            _lastSave = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            _saveSlot = slot,
            _player = saveData.TryGetValue(SaveKey.PlayerStats, out ISaveable _player) ? _player.ExportSaveData()._player : null,
            _party = saveData.TryGetValue(SaveKey.Party,out ISaveable _party) ? _party.ExportSaveData()._party : null,
            _inventory = saveData.TryGetValue(SaveKey.Inventory, out ISaveable _inventory) ? _inventory.ExportSaveData()._inventory : null
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetSavePath(slot), json);
    }

    public void Load(SaveSlotIndex slot)
    {
        SaveData _data = playerSaveData.TryGetValue(slot, out var save) ? save : null;
        if (_data != null)
        {
            SSaveData sSaveData = new SSaveData{saveData = _data};
            EventBus<SSaveData>.Publish(sSaveData);
            foreach (var _save in _saveables)
            {
                _save.ImportSaveData(sSaveData);
            }
        }
    }
    public void GetSaveData()
    {
        SaveData saveData;
        if (File.Exists(GetSavePath(SaveSlotIndex.One)))
        {
            saveData = new();
            string json = File.ReadAllText(GetSavePath(SaveSlotIndex.One));
            JsonUtility.FromJsonOverwrite(json, saveData);
            playerSaveData.Add(SaveSlotIndex.One, saveData);
        }
        ;
        if (File.Exists(GetSavePath(SaveSlotIndex.Two)))
        {
            saveData = new();
            string json = File.ReadAllText(GetSavePath(SaveSlotIndex.Two));
            JsonUtility.FromJsonOverwrite(json, saveData);
            playerSaveData.Add(SaveSlotIndex.Two, saveData);
        }
        ;
        if (File.Exists(GetSavePath(SaveSlotIndex.Three)))
        {
            saveData = new();
            string json = File.ReadAllText(GetSavePath(SaveSlotIndex.Three));
            JsonUtility.FromJsonOverwrite(json, saveData);
            playerSaveData.Add(SaveSlotIndex.Three, saveData);
        }
        ;
    }
}
