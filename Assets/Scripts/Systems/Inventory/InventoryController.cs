using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, ISaveable
{
    [SerializeField] private List<ItemData> _toolbar;
    [SerializeField] private List<ItemData> _inventory;
    public List<ItemData> Inventory
    {
        get { return _inventory; }
        private set
        {
            _inventory = value;
            EventBus<SInventory>.Publish(new SInventory { Inventory = _inventory });
        }
    }
    public List<ItemData> Toolbar
    {
        get { return _toolbar; }
        private set
        {
            _toolbar = value;
            EventBus<SToolbar>.Publish(new SToolbar { Toolbar = _toolbar });
        }
    }
    public SaveKey _saveKey => SaveKey.Inventory;
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
            _inventory = new()
            {
                Toolbar = Toolbar,
                Inventory = Inventory
            }
        };
        return saveData;
    }
    public void ImportSaveData(SSaveData data)
    {
        Inventory = data.saveData._inventory.Inventory;
        Toolbar   = data.saveData._inventory.Toolbar;
    }
}