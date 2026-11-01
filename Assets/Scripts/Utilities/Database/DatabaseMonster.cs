using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Monsters", menuName = "Character/DatabaseMonsters")]
public class DatabaseMonster : ScriptableObject
{
    public List<SOMonster> allMembers;
    private Dictionary<string, SOMonster> _lookup;
    public void BuildLookup()
    {
        _lookup = allMembers.ToDictionary(m => m.ID, m => m);
    }
    public SOMonster GetById(string id)
    {
        return _lookup.TryGetValue(id, out var monster) ? monster : null;
    }
}
