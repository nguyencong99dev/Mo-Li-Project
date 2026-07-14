using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public struct SPlayerParty
{
    public List<MonsterData> _Party;
}

public class PlayerParty : MonoBehaviour
{
    [SerializeField] private List<MonsterData> _Party;

    void Start()
    {
        EventBus<SPlayerParty>.Publish(new SPlayerParty
        {
            _Party = _Party
        });
    }
    public void AddPartyMembers(MonsterData _monster)
    {
        if (_monster != null)
        {
            _Party.Add(_monster);
            EventBus<SPlayerParty>.Publish(new SPlayerParty
            {
                _Party = _Party
            });
        }
    }
    public void RemovePartyMember()
    {

    }
    public List<MonsterData> GetPartyMembers()
    {
        return _Party;
    }
    public void SetPartyMembers(List<MonsterData> newParty)
    {
        _Party = newParty;
    }
}
