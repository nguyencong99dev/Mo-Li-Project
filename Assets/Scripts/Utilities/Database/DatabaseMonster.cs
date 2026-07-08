using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Monsters", menuName = "Character/DatabaseMonsters")]
public class DatabaseMonster : ScriptableObject
{
    public List<DataMonster> allMembers;
    private Dictionary<string, DataMonster> _lookup;
    public void BuildLookup()
    {
        _lookup = allMembers.ToDictionary(m => m.ID, m => m);
    }
    public DataMonster GetById(string id)
    {
        return _lookup.TryGetValue(id, out var monster) ? monster : null;
    }
}
