using UnityEngine;

public class PlayerController : MonoBehaviour,ISaveable
{
    private PlayerStats _stats = new();
    public SaveKey _saveKey => SaveKey.PlayerStats;
    void Awake()
    {
        EventBus<SSaveData>.Subscribe(ImportSaveData);
    }
    void OnDestroy()
    {
        EventBus<SSaveData>.Unsubscribe(ImportSaveData);
    }
    void OnEnable()
    {
        ManagerSave.Instance.Register(this);
    }
    void OnDisable()
    {
        ManagerSave.Instance.Unregister(this);
    }
    public SaveData ExportSaveData()
    {
        SaveData saveData = new()
        {
            _player = _stats.GetPlayerSaveData()
        };
        return saveData;
    }
    public void ImportSaveData(SSaveData data)
    {
        _stats.SetPlayerStats(JsonUtility.ToJson(data.saveData._player));
    }
}
