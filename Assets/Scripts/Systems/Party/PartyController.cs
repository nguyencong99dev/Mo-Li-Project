using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PartyController : MonoBehaviour, ISaveable
{
    [SerializeField] private List<MonsterData> _party;
    public List<MonsterData> Party
    {
        get { return _party; }
        private set
        {
            _party = value;
            EventBus<SPlayerParty>.Publish(new SPlayerParty
            {
                Party = _party
            });
        }
    }
    public SaveKey _saveKey => SaveKey.Party;
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
            _party = new()
            {
                PartyMembers = Party
            }
        };
        return saveData;
    }
    public void ImportSaveData(SSaveData data)
    {
        Party = data.saveData._party.PartyMembers;
    }
}
