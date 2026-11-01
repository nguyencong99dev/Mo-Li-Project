using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Skill", menuName = "Character/Database Skill")]
public class DatabaseSkill : ScriptableObject
{
    public List<SOSkill> allSkills;
    private Dictionary<string, SOSkill> _lookup;
    public void BuildLookup()
    {
        _lookup = allSkills.ToDictionary(s => s.ID, s => s);
    }
    public SOSkill GetByID(string skillID)
    {
        return _lookup.TryGetValue(skillID, out var skill) ? skill : null;
    }
}