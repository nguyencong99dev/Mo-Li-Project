using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class ManagerSave : MonoBehaviour
{
    public static ManagerSave Instance { get; private set; }
    const int MAX_SLOTS = 3;
    const string SAVE_FILE_PREFIX = "save_slot_";
    const string SETTINGS_FILE = "settings.json";
    // string SaveDirectory => Application.persistentDataPath;
    // string GetSavePath(int slotIndex) => Path.Combine(SaveDirectory, $"{SAVE_FILE_PREFIX}{slotIndex}.json");
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
        Debug.Log("Manager Data Initialized");
    }
    string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
    }

    public PlayerData Load()
    {
        if (!File.Exists(SavePath)) return null;
        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
